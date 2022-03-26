using DevOpsDataJob.StoredProcedures;
using Microsoft.TeamFoundation.SourceControl.WebApi;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevOpsDataJob.DAL
{
    public class PullRequestDetails
    {
        public static DataTable Pullcount(string Repoid)//Calling Previous PullRequest Count
        {
            DataTable dt = new DataTable();
            dt = SPCalls.PrevPullReqCount(Repoid);
            return dt;
        }
        public static void InsertDataintoPullrequestData(GitPullRequest gitPullRequest, string repoid, string projectID) //Inserting Data into PullRequests Table
        {
            bool istrue;
            istrue = SPCalls.CheckDatainPullRequestData(gitPullRequest, repoid); //calling Duplicate SP
            string _conn = ConfigurationManager.ConnectionStrings["CONN"].ConnectionString;
            string reviewer;
            try
            {
                if (istrue)
                {
                    using (SqlConnection connection = new SqlConnection(_conn))
                    {
                        var sql = "insert into Pullrequest(PullrequestId,Title,Description,Reviewer,Url,SourceRefName,TargetRefName,LastMergeTargetCommit,LastMergeSourceCommit,LastMergeCommit,Status,RepoId,ProjectId) values(@PullrequestId,@Title,@Description,@Reviewer,@Url,@SourceRefName,@TargetRefName,@LastMergeTargetCommit,@LastMergeSourceCommit,@LastMergeCommit,@Status,@RepoId,@ProjectId)";
                        using (SqlCommand cmd = new SqlCommand(sql, connection))
                        {
                            if (gitPullRequest.Reviewers.Count() > 0) //For checking Multiple Reviewers  if have Inserted with , Saperated
                            {
                                int p = gitPullRequest.Reviewers.Count();

                                while (p > 1)
                                {
                                    reviewer = gitPullRequest.Reviewers[p - 1].DisplayName;
                                    p--;
                                    reviewer = reviewer + ",";
                                }
                                reviewer = gitPullRequest.Reviewers[p - 1].DisplayName;
                            }
                            else
                            {
                                reviewer = DBNull.Value.ToString();
                            }
                            cmd.Parameters.AddWithValue("@Title", gitPullRequest.Title.ToString());
                            cmd.Parameters.AddWithValue("@Description", (string.IsNullOrEmpty(gitPullRequest.Description) ? DBNull.Value : gitPullRequest.Description.ToString()));
                            cmd.Parameters.AddWithValue("@PullrequestId", gitPullRequest.PullRequestId.ToString());
                            cmd.Parameters.AddWithValue("@Url", gitPullRequest.Url.ToString());
                            cmd.Parameters.AddWithValue("@Reviewer", reviewer);
                            cmd.Parameters.AddWithValue("@SourceRefName", gitPullRequest.SourceRefName.ToString());
                            cmd.Parameters.AddWithValue("@TargetRefName", gitPullRequest.TargetRefName.ToString());
                            cmd.Parameters.AddWithValue("@LastMergeTargetCommit", gitPullRequest.LastMergeTargetCommit.CommitId.ToString());
                            cmd.Parameters.AddWithValue("@LastMergeSourceCommit", gitPullRequest.LastMergeSourceCommit.CommitId.ToString());
                            if (gitPullRequest.LastMergeCommit == null)
                            {
                                cmd.Parameters.AddWithValue("@LastMergeCommit", DBNull.Value);
                            }
                            else
                            {
                                cmd.Parameters.AddWithValue("@LastMergeCommit", gitPullRequest.LastMergeCommit.CommitId.ToString());
                            }
                            cmd.Parameters.AddWithValue("@Status", gitPullRequest.Status.ToString());
                            cmd.Parameters.AddWithValue("@RepoId", repoid);
                            cmd.Parameters.AddWithValue("@ProjectId", projectID);
                            connection.Open();
                            cmd.ExecuteNonQuery();
                            connection.Close();
                        }
                    }
                }
            }
            catch (Exception e)
            {
                throw e;
            }

        }
    }
}
