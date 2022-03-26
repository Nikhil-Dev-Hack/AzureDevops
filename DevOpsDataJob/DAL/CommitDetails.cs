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
    class CommitDetails
    {
        public static DataTable GetDetails(string repoid) //Calling Previously Inserted CommitCount
        {
            DataTable dt = new DataTable();
            dt = SPCalls.PrevCommitsCount(repoid);
            return dt;
        }

        public void InsertDataintoCommitsData(GitCommitRef commitone, GitRepository repo) //Inserting Commits Data
        {
            try
            {
                string _connstr = ConfigurationManager.ConnectionStrings["CONN"].ConnectionString;
                using (SqlConnection connection = new SqlConnection(_connstr))
                {
                    SPCalls SPC = new SPCalls();
                    bool isexist = SPC.CheckDatainCommitsData(commitone, repo);
                    if (isexist)
                    {
                        var listNumber = commitone.ChangeCounts.Keys.ToList();
                        var sql = "insert into CommitsData(RepoId,CommitId,CommitDate,Adds,Deletes,Edits,UserName,Email,Comments,RemoteUrl,Url) values(@repoid,@CommitId,@CommitteDate,@add,@edit,@delete,@userid,@email,@comment,@RemoteUrl,@Url)";
                        using (SqlCommand cmd = new SqlCommand(sql, connection))
                        {
                            cmd.Parameters.AddWithValue("@comment", commitone.Comment);
                            cmd.Parameters.AddWithValue("@repoid", repo.Id);
                            cmd.Parameters.AddWithValue("@CommitId", commitone.CommitId);
                            cmd.Parameters.AddWithValue("@CommitteDate", commitone.Committer.Date);
                            cmd.Parameters.AddWithValue("@add", listNumber[0]);
                            cmd.Parameters.AddWithValue("@edit", listNumber[1]);
                            cmd.Parameters.AddWithValue("@delete", listNumber[2]);
                            if (commitone.Committer.Email != null)
                            {
                                cmd.Parameters.AddWithValue("@email", commitone.Committer.Email);
                            }
                            else
                            {
                                cmd.Parameters.AddWithValue("@email", DBNull.Value.ToString());
                            }
                            cmd.Parameters.AddWithValue("@userid", commitone.Author.Name);
                            cmd.Parameters.AddWithValue("@RemoteUrl", commitone.RemoteUrl);
                            cmd.Parameters.AddWithValue("@Url", commitone.Url);
                            connection.Open();
                            cmd.ExecuteNonQuery();
                            connection.Close();
                        }
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw e;
            }
        }
    }
}
