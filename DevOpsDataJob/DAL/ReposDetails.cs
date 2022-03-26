using DevOpsDataJob.StoredProcedures;
using Microsoft.TeamFoundation.SourceControl.WebApi;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevOpsDataJob.DAL
{
   public class ReposDetails
    {
        public void InsertIntoReposData(GitRepository Repo, int CountCommits) //Inserting ReposData into DB
        {
            bool istrue = false;
            istrue = SPCalls.CheckDatainReposData(Repo); //Calling Duplicate SP
            string _conn = ConfigurationManager.ConnectionStrings["CONN"].ConnectionString;
            try
            {
                if (istrue)
                {
                    using (SqlConnection connection = new SqlConnection(_conn))
                    {
                        var sql = "insert into ReposDataOriginal(RepoName,RepoId,RepoURL,DefaultBranch,ProjectName,ProjectId,CommitCount) values(@RepoName,@Id,@URL,@Branch,@PName,@PId,@Countcommit)";
                        using (SqlCommand cmd = new SqlCommand(sql, connection))
                        {
                            cmd.Parameters.AddWithValue("@RepoName", Repo.Name);
                            cmd.Parameters.AddWithValue("@Id", Repo.Id);
                            cmd.Parameters.AddWithValue("@URL", Repo.Url);
                            cmd.Parameters.AddWithValue("@Branch", Repo.DefaultBranch);
                            cmd.Parameters.AddWithValue("@PName", Repo.ProjectReference.Name);
                            cmd.Parameters.AddWithValue("@PId", Repo.ProjectReference.Id);
                            cmd.Parameters.AddWithValue("@Countcommit", CountCommits);
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
