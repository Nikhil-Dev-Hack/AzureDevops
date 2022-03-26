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
    public class BranchDetails
    {
        public static DataTable PrevBranchesCount(string Repoid)//Calling Previous BranchCount
        {
            DataTable dt = new DataTable();
            dt = SPCalls.PreviousBranchesCount(Repoid);
            return dt;
        }

        public static void InsertDataIntoBranchesData(GitBranchStats Branches, string ProjectId, string RepoId) //Inserting Data into ChangesTable
        {
            bool istrue;
            istrue = SPCalls.CheckDatainBranchData(Branches); //Calling Duplicate SP
            string _conn = ConfigurationManager.ConnectionStrings["CONN"].ConnectionString;
            try
            {
                if (istrue)
                {
                    using (SqlConnection connection = new SqlConnection(_conn))
                    {
                        var sql = "insert into BranchDetails(Name,AheadCount,BehindCount,CommitId,URL,Author,Comment,Commiter,ProjectId,RepoId) values(@Name,@AheadCount,@BehindCount,@CommitId,@URL,@Author,@Comment,@Commiter,@ProjectId,@RepoId)";
                        using (SqlCommand cmd = new SqlCommand(sql, connection))
                        {
                            cmd.Parameters.AddWithValue("@Name", Branches.Name.ToString());
                            cmd.Parameters.AddWithValue("@AheadCount", Branches.AheadCount);
                            cmd.Parameters.AddWithValue("@BehindCount", Branches.BehindCount);
                            cmd.Parameters.AddWithValue("@CommitId", Branches.Commit.CommitId.ToString());
                            cmd.Parameters.AddWithValue("@URL", Branches.Commit.Url.ToString());
                            cmd.Parameters.AddWithValue("@Author", Branches.Commit.Author.Name.ToString());
                            cmd.Parameters.AddWithValue("@Comment", Branches.Commit.Comment.ToString());
                            cmd.Parameters.AddWithValue("@Commiter", Branches.Commit.Committer.Name.ToString());
                            cmd.Parameters.AddWithValue("@ProjectId", ProjectId.ToString());
                            cmd.Parameters.AddWithValue("@RepoId", RepoId.ToString());
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
