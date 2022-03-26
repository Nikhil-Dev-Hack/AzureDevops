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
    public class UserDetails
    {
        public void InsertDataIntoUserData(GitCommitRef Commit) //Inserting Userdata into DB
        {
            bool istrue;
            istrue = SPCalls.CheckDatainUsersData(Commit); //Calling Duplicate SP
            string _conn = ConfigurationManager.ConnectionStrings["CONN"].ConnectionString;
            try
            {
                if (istrue)
                {
                    using (SqlConnection connection = new SqlConnection(_conn))
                    {
                        var sql = "insert into Userdata(UserName,Email) values(@Author,@Email)";
                        using (SqlCommand cmd = new SqlCommand(sql, connection))
                        {
                            cmd.Parameters.AddWithValue("@Author", Commit.Author.Name.ToString());
                            if (Commit.Author.Email == null)
                            {
                                cmd.Parameters.AddWithValue("@Email", DBNull.Value.ToString());
                            }
                            else
                            {
                                cmd.Parameters.AddWithValue("@Email", Commit.Author.Email.ToString());
                            }
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
