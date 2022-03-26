using Microsoft.TeamFoundation.Core.WebApi;
using Microsoft.TeamFoundation.SourceControl.WebApi;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevOpsDataJob.StoredProcedures
{
    public class SPCalls
    {
        public static DataTable ProjectDetails()   //To get the Projects Devops URL's from Db
        {
            string _conn = ConfigurationManager.ConnectionStrings["CONN"].ConnectionString;
            using(SqlConnection connection = new SqlConnection(_conn))
            {
                var sql = "select * from ProjectsDetails";
                DataTable dt = new DataTable();
                using(SqlCommand cmd = new SqlCommand(sql,connection))
                {
                    connection.Open();
                    using(SqlDataAdapter adp = new SqlDataAdapter(cmd))
                    {
                        adp.Fill(dt);
                    }
                    connection.Close();
                    return dt;
                }
            }
        }

        public static bool CheckDatainProjectData(TeamProjectReference reference)   // for Checking Duplicate Projects Data
        {
            string _conn = ConfigurationManager.ConnectionStrings["CONN"].ConnectionString;
            using (SqlConnection connection = new SqlConnection(_conn))
            {
                var sql = "CheckDataProject";
                {
                    using (SqlCommand cmd = new SqlCommand(sql, connection))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        connection.Open();
                        SqlParameter[] parms = new SqlParameter[2];
                        parms[0] = new SqlParameter("@id", SqlDbType.NVarChar);
                        parms[0].Value = reference.Id.ToString();
                        parms[1] = new SqlParameter("@name", SqlDbType.NVarChar);
                        parms[1].Value = reference.Name.ToString();
                        IDbDataParameter ispresent = cmd.CreateParameter();
                        cmd.Parameters.Add(ispresent);
                        cmd.Parameters.AddRange(parms);
                        ispresent.Direction = ParameterDirection.ReturnValue;
                        cmd.ExecuteNonQuery();
                        int returnVALUE = (int)(ispresent.Value);
                        connection.Close();
                        if (returnVALUE == 0)
                        {
                            return true;
                        }
                        return false;
                    }
                }
            }
        }

        public static bool CheckDatainReposData(GitRepository Repo)   //for Checking Duplicate ReposData
        {
            string _conn = ConfigurationManager.ConnectionStrings["CONN"].ConnectionString;
            using (SqlConnection connection = new SqlConnection(_conn))
            {
                var sql = "CheckRepoData";
                using (SqlCommand cmd = new SqlCommand(sql, connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    connection.Open();
                    SqlParameter[] parms = new SqlParameter[2];
                    parms[0] = new SqlParameter("@id", SqlDbType.NVarChar);
                    parms[0].Value = Repo.Id.ToString();
                    parms[1] = new SqlParameter("@name", SqlDbType.NVarChar);
                    parms[1].Value = Repo.ProjectReference.Id.ToString();
                    IDbDataParameter ispresent = cmd.CreateParameter();
                    cmd.Parameters.Add(ispresent);
                    cmd.Parameters.AddRange(parms);
                    ispresent.Direction = ParameterDirection.ReturnValue;
                    cmd.ExecuteNonQuery();
                    int returnVALUE = (int)(ispresent.Value);
                    connection.Close();
                    if (returnVALUE == 0)
                    {
                        return true;
                    }
                    return false;
                }
            }
        }

        public static bool CheckDatainUsersData(GitCommitRef commit) //To Check Duplicate UserData
        {
            string _conn = ConfigurationManager.ConnectionStrings["CONN"].ConnectionString;
            using (SqlConnection connection = new SqlConnection(_conn))
            {
                var sql = "CheckIdentityData";
                using (SqlCommand cmd = new SqlCommand(sql, connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    connection.Open();
                    SqlParameter[] parms = new SqlParameter[2];
                    parms[0] = new SqlParameter("@id", SqlDbType.NVarChar);
                    parms[0].Value = commit.Author.Name.ToString();
                    parms[1] = new SqlParameter("@name", SqlDbType.NVarChar);
                    if (commit.Author.Email == null)
                    {
                        parms[1].Value = DBNull.Value.ToString();
                    }
                    else
                    {
                        parms[1].Value = commit.Author.Email.ToString();
                    }
                    IDbDataParameter ispresent = cmd.CreateParameter();
                    cmd.Parameters.Add(ispresent);
                    cmd.Parameters.AddRange(parms);
                    ispresent.Direction = ParameterDirection.ReturnValue;
                    cmd.ExecuteNonQuery();
                    int returnVALUE = (int)(ispresent.Value);
                    connection.Close();
                    if (returnVALUE == 0)
                    {
                        return true;
                    }
                    return false;
                }
            }

        }

        //CommitsTable
        public static DataTable PrevCommitsCount(string repoid) //No.of Commits(Rows) Inserted Previously
        {
            string _conn = ConfigurationManager.ConnectionStrings["CONN"].ConnectionString;
            using (SqlConnection connection = new SqlConnection(_conn))
            {
                var sql = "select Count(*) as Countcommit from CommitsData where repoid=@repoid ";
                DataTable dt = new DataTable();
                using (SqlCommand cmd = new SqlCommand(sql, connection))
                {
                    connection.Open();
                    cmd.Parameters.AddWithValue("@repoid", repoid);
                    using (SqlDataAdapter adp = new SqlDataAdapter(cmd))
                    {
                        adp.Fill(dt);
                    }
                    connection.Close();
                }
                return dt;
            }
        }

        public bool CheckDatainCommitsData(GitCommitRef commitone, GitRepository repo) //For Checking Duplicate CommitsData
        {
            string _conn = ConfigurationManager.ConnectionStrings["CONN"].ConnectionString;
            using (SqlConnection connection = new SqlConnection(_conn))
            {
                var sql = "CheckCommitdata";
                using (SqlCommand cmd = new SqlCommand(sql, connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    connection.Open();
                    SqlParameter[] parms = new SqlParameter[2];
                    parms[0] = new SqlParameter("@id", SqlDbType.NVarChar);
                    parms[0].Value = repo.Id.ToString();
                    parms[1] = new SqlParameter("@name", SqlDbType.NVarChar);
                    parms[1].Value = commitone.CommitId.ToString();
                    IDbDataParameter ispresent = cmd.CreateParameter();
                    cmd.Parameters.Add(ispresent);
                    cmd.Parameters.AddRange(parms);
                    ispresent.Direction = ParameterDirection.ReturnValue;
                    cmd.ExecuteNonQuery();
                    int returnVALUE = (int)(ispresent.Value);
                    connection.Close();
                    if (returnVALUE == 0)
                    {
                        return true;
                    }
                    return false;
                }
            }
        }

        //for Changes Table
        public static DataTable PrevChangeCount(string repoid, string Commitid) //for Checking Previous Inserted(Rows) ChangeCount
        {
            string _conn = ConfigurationManager.ConnectionStrings["CONN"].ConnectionString;
            using (SqlConnection connection = new SqlConnection(_conn))
            {
                var sql = "select Count(*) as ChangeCount from ChangesData where repoid=@repoid and CommitId=@commitid";
                DataTable dt = new DataTable();
                using (SqlCommand cmd = new SqlCommand(sql, connection))
                {
                    connection.Open();
                    cmd.Parameters.AddWithValue("@repoid", repoid);
                    cmd.Parameters.AddWithValue("@commitid", Commitid);
                    using (SqlDataAdapter adp = new SqlDataAdapter(cmd))
                    {
                        adp.Fill(dt);
                    }
                    connection.Close();
                }
                return dt;
            }
        }

        public static bool CheckDatainChangesData(GitChange Changes, string commmitid)    //For Checking duplicate ChangesData
        {
            string _conn = ConfigurationManager.ConnectionStrings["CONN"].ConnectionString;
            using (SqlConnection connection = new SqlConnection(_conn))
            {
                var sql = "CheckChangeData";
                using (SqlCommand cmd = new SqlCommand(sql, connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    connection.Open();
                    SqlParameter[] parms = new SqlParameter[2];
                    parms[0] = new SqlParameter("@id", SqlDbType.NVarChar);
                    parms[0].Value = commmitid;
                    parms[1] = new SqlParameter("@name", SqlDbType.NVarChar);
                    parms[1].Value = Changes.Item.ObjectId.ToString();
                    IDbDataParameter ispresent = cmd.CreateParameter();
                    cmd.Parameters.Add(ispresent);
                    cmd.Parameters.AddRange(parms);
                    ispresent.Direction = ParameterDirection.ReturnValue;
                    cmd.ExecuteNonQuery();
                    int returnVALUE = (int)(ispresent.Value);
                    connection.Close();
                    if (returnVALUE == 0)
                    {
                        return true;
                    }
                    return false;
                }
            }
        }

        //PullRequests
        public static DataTable PrevPullReqCount(string repoid) //To check no. of Rows Inserted in PullRequest Table
        {
            string _conn = ConfigurationManager.ConnectionStrings["CONN"].ConnectionString;
            using (SqlConnection connection = new SqlConnection(_conn))
            {
                var sql = "select count(*) as CountPull from Pullrequest where repoid=@repoid";
                DataTable dt = new DataTable();
                using (SqlCommand cmd = new SqlCommand(sql, connection))
                {
                    connection.Open();
                    cmd.Parameters.AddWithValue("@repoid", repoid);


                    using (SqlDataAdapter adp = new SqlDataAdapter(cmd))
                    {
                        adp.Fill(dt);
                    }
                    connection.Close();
                }

                return dt;
            }
        }

        public static bool CheckDatainPullRequestData(GitPullRequest commit, string repoid) //To Check Duplicate data in PullRequests Table
        {
            string _conn = ConfigurationManager.ConnectionStrings["CONN"].ConnectionString;
            using (SqlConnection connection = new SqlConnection(_conn))
            {
                var sql = "CheckPullrequestdata";;
                using (SqlCommand cmd = new SqlCommand(sql, connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    connection.Open();
                    SqlParameter[] parms = new SqlParameter[2];
                    parms[0] = new SqlParameter("@id", SqlDbType.Int);
                    parms[0].Value = commit.PullRequestId;
                    parms[1] = new SqlParameter("@name", SqlDbType.NVarChar);
                    parms[1].Value = repoid;
                    IDbDataParameter ispresent = cmd.CreateParameter();
                    cmd.Parameters.Add(ispresent);
                    cmd.Parameters.AddRange(parms);
                    ispresent.Direction = ParameterDirection.ReturnValue;
                    cmd.ExecuteNonQuery();
                    int returnVALUE = (int)(ispresent.Value);
                    connection.Close();
                    if (returnVALUE == 0)
                    {
                        return true;
                    }
                    return false;
                }
            }

        }

        //Branches

        public static DataTable PreviousBranchesCount(string repoid) //To check no. of Rows Inserted in Branches Table
        {
            string _conn = ConfigurationManager.ConnectionStrings["CONN"].ConnectionString;
            using (SqlConnection connection = new SqlConnection(_conn))
            {
                var sql = "select count(*) as BranchCount from BranchDetails where repoid=@repoid";
                DataTable dt = new DataTable();
                using (SqlCommand cmd = new SqlCommand(sql, connection))
                {
                    connection.Open();
                    cmd.Parameters.AddWithValue("@repoid", repoid);


                    using (SqlDataAdapter adp = new SqlDataAdapter(cmd))
                    {
                        adp.Fill(dt);
                    }
                    connection.Close();
                }

                return dt;
            }
        }

        public static bool CheckDatainBranchData(GitBranchStats branch) //To Check Duplicate data in PullRequests Table
        {
            string _conn = ConfigurationManager.ConnectionStrings["CONN"].ConnectionString;
            using (SqlConnection connection = new SqlConnection(_conn))
            {
                var sql = "CheckBranchesData"; ;
                using (SqlCommand cmd = new SqlCommand(sql, connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    connection.Open();
                    SqlParameter[] parms = new SqlParameter[2];
                    parms[0] = new SqlParameter("@name", SqlDbType.NVarChar);
                    parms[0].Value = branch.Name;
                    parms[1] = new SqlParameter("@commitId", SqlDbType.NVarChar);
                    parms[1].Value = branch.Commit.CommitId;
                    IDbDataParameter ispresent = cmd.CreateParameter();
                    cmd.Parameters.Add(ispresent);
                    cmd.Parameters.AddRange(parms);
                    ispresent.Direction = ParameterDirection.ReturnValue;
                    cmd.ExecuteNonQuery();
                    int returnVALUE = (int)(ispresent.Value);
                    connection.Close();
                    if (returnVALUE == 0)
                    {
                        return true;
                    }
                    return false;
                }
            }

        }

    }
}
