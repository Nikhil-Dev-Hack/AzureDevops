using DevOpsDataJob.StoredProcedures;
using Microsoft.TeamFoundation.Core.WebApi;
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
   public class ProjectDetails
    {
        public static DataTable ProjectLogins() //Method for Getting Logins from ProjectsDetails Table
        {
            DataTable dt = new DataTable();
            dt = SPCalls.ProjectDetails();
            return dt;
        }

        public void InsertIntoProjectsData(TeamProjectReference reference, int ReposCount) //Inserting Data into Projects Table
        {
            bool istrue;
            istrue = SPCalls.CheckDatainProjectData(reference); //Calling Dupplicate Check SP
            string _conn = ConfigurationManager.ConnectionStrings["CONN"].ConnectionString;
            try
            {
                if (istrue)
                {
                    using (SqlConnection connection = new SqlConnection(_conn))
                    {
                        var sql = "insert into ProjectsData(ProjectName,ProjectId,Description,URL,ReposCount) values(@projectname,@PId,@DESP,@Url,@CountRepo)";
                        using (SqlCommand cmd = new SqlCommand(sql, connection))
                        {
                            cmd.Parameters.AddWithValue("@projectname", reference.Name);
                            cmd.Parameters.AddWithValue("@PId", reference.Id);
                            cmd.Parameters.AddWithValue("@DESP", reference.Description);
                            cmd.Parameters.AddWithValue("@Url", reference.Url);
                            cmd.Parameters.AddWithValue("@CountRepo", ReposCount);
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
