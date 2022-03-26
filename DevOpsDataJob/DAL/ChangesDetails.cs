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
   public class ChangesDetails
    {
        public static DataTable PrevChangeCount(string Commitid, string Repoid)//Calling Previous ChangeCount
        {
            DataTable dt = new DataTable();
            dt = SPCalls.PrevChangeCount(Repoid, Commitid);
            return dt;
        }

        public static void InsertDataIntoChangesData(GitChange Changes, string Commitid, string Repoid) //Inserting Data into ChangesTable
        {
            bool istrue;
            istrue = SPCalls.CheckDatainChangesData(Changes, Commitid); //Calling Duplicate SP
            string _conn = ConfigurationManager.ConnectionStrings["CONN"].ConnectionString;
            try
            {
                if (istrue)
                {
                    using (SqlConnection connection = new SqlConnection(_conn))
                    {
                        var sql = "insert into ChangesData(CommitId,RepoId,ObjectId,Url,Path,Chnagetype) values(@CommitId,@RepoId,@ObjectId,@Url,@Path,@Chnagetype)";
                        using (SqlCommand cmd = new SqlCommand(sql, connection))
                        {
                            cmd.Parameters.AddWithValue("@CommitId", Commitid);
                            cmd.Parameters.AddWithValue("@RepoId", Repoid);
                            cmd.Parameters.AddWithValue("@ObjectId", Changes.Item.ObjectId.ToString());
                            cmd.Parameters.AddWithValue("@Url", Changes.Item.Url.ToString());
                            cmd.Parameters.AddWithValue("@Path", Changes.Item.Path.ToString());
                            cmd.Parameters.AddWithValue("@Chnagetype", Changes.ChangeType.ToString());
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
