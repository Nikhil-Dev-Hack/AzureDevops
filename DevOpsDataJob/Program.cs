using DevOpsDataJob;
using DevOpsDataJob.DAL;
using Microsoft.TeamFoundation.Core.WebApi;
using Microsoft.TeamFoundation.SourceControl.WebApi;
using Microsoft.VisualStudio.Services.Common;
using Microsoft.VisualStudio.Services.WebApi;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace SampleConsoleAppAzureDevops
{
    class Program
    {
        static void Main(string[] args)
        {
            Loginformation _objlog = new Loginformation();
            DataTable dt = new DataTable();
            dt = ProjectDetails.ProjectLogins();
            _objlog.WriteServiceLine("Job Started");
            foreach (DataRow dataRow in dt.Rows)
            {
                string URL = dataRow["URL"].ToString();
                Uri orgUrl = new Uri(URL);         // Organization URL, for example: https://dev.azure.com/fabrikam               
                String personalAccessToken = dataRow["Token"].ToString();  // See https://docs.microsoft.com/azure/devops/integrate/get-started/authentication/pats                                                                                                     
                VssConnection connection = new VssConnection(orgUrl, new VssBasicCredential(string.Empty, personalAccessToken));
                // Show details a work item
                ListPullRequestsForProject(connection);
                _objlog.WriteServiceLine("Job Ended.");
            }
        }

        public static IEnumerable<GitPullRequest> ListPullRequestsForProject(VssConnection connection)
        {
            GitHttpClient gitClient = connection.GetClient<GitHttpClient>();
            var project = FindAnyProject(connection);
            List<GitRepository> repos = gitClient.GetRepositoriesAsync(project.Id).Result;
            List<GitPullRequest> prs = new List<GitPullRequest>();
            List<GitCommitRef> commits = new List<GitCommitRef>();
            GitCommitChanges changes = new GitCommitChanges();
            List<GitPullRequest> prsrepo = new List<GitPullRequest>();
            List<GitBranchStats> branches = new List<GitBranchStats>();

            foreach (var repo in repos)
            {
                DataTable dt = new DataTable();
                dt = CommitDetails.GetDetails(repo.Id.ToString());
                if (dt.Rows.Count > 0) //Getting and Checking the Previously Inserted CommitsCount
                {
                    foreach (DataRow item in dt.Rows)
                    {
                        if (item["Countcommit"].ToString() != "0") //Skipping Previously Inserted Rows
                        {
                            int countcommit = int.Parse(item["Countcommit"].ToString());
                            commits = connection.GetClient<GitHttpClient>().GetCommitsAsync(repo.Id, new GitQueryCommitsCriteria() { Skip = countcommit, Top = 500000 }).Result;
                        }
                        else
                        {
                            commits = connection.GetClient<GitHttpClient>().GetCommitsAsync(repo.Id, new GitQueryCommitsCriteria() { Top = 500000 }).Result;
                        }
                    }
                }
                else
                {
                    commits = connection.GetClient<GitHttpClient>().GetCommitsAsync(repo.Id, new GitQueryCommitsCriteria() { Top = 500000 }).Result;

                }

                int countPull = 0;
                DataTable PC = new DataTable(); //Getting Previously Inserted PullRequests Count
                PC = PullRequestDetails.Pullcount(repo.Id.ToString());
                foreach (DataRow item in PC.Rows)
                {
                    countPull = int.Parse(item["CountPull"].ToString());
                }
                if (countPull > 0) //Skipping Previously Inserted Rows
                {

                    prsrepo = gitClient.GetPullRequestsAsync(project.Id, repo.Id, new GitPullRequestSearchCriteria() { Status = PullRequestStatus.All, }, skip: countPull, top: 500000).Result;
                }
                else
                {
                    prsrepo = gitClient.GetPullRequestsAsync(project.Id, repo.Id, new GitPullRequestSearchCriteria() { Status = PullRequestStatus.All }, top: 500000).Result;
                }

                int ReposCount = repos.Count;
                ProjectDetails PD = new ProjectDetails();
                PD.InsertIntoProjectsData(project, ReposCount);//Calling Projects Method.
                int CommitsCount = commits.Count;
                ReposDetails RD = new ReposDetails();
                RD.InsertIntoReposData(repo, CommitsCount);//Calling Repos Method.
                foreach (GitPullRequest pr in prsrepo) //Calling PullRequests Method.
                {
                    PullRequestDetails.InsertDataintoPullrequestData(pr, repo.Id.ToString(), project.Id.ToString());
                }
                prs.AddRange(prsrepo);
                foreach (var commit in commits)
                {
                    CommitDetails CD = new CommitDetails();
                    CD.InsertDataintoCommitsData(commit, repo);//Calling Commits Table
                    UserDetails UD = new UserDetails();
                    UD.InsertDataIntoUserData(commit); //Calling Changes Table
                    DataTable chnagecounttable = new DataTable();
                    int Countvalue = 0;
                    chnagecounttable = ChangesDetails.PrevChangeCount(commit.CommitId.ToString(), repo.Id.ToString());
                    foreach (DataRow item in chnagecounttable.Rows) //Getting Previously Inserted Count Value.
                    {
                        Countvalue = int.Parse(item["ChangeCount"].ToString());
                    }
                    if (Countvalue > 0) //Skipping the Count.
                    {
                        changes = connection.GetClient<GitHttpClient>().GetChangesAsync(commit.CommitId, repo.Id, skip: Countvalue).Result;
                    }
                    else
                    {
                        changes = connection.GetClient<GitHttpClient>().GetChangesAsync(commit.CommitId, repo.Id).Result;
                    }
                    foreach (var Change in changes.Changes)// Calling Changes Method.
                    {
                       ChangesDetails.InsertDataIntoChangesData(Change, commit.CommitId.ToString(), repo.Id.ToString());
                    }


                    //Branches
                    DataTable branchcount = new DataTable();
                    int branchCountValue = 0;
                    branchcount = BranchDetails.PrevBranchesCount(repo.Id.ToString());
                    foreach (DataRow item in branchcount.Rows) //Getting Previously Inserted Count Value.
                    {
                        branchCountValue = int.Parse(item["BranchCount"].ToString());
                    }
                    if (branchCountValue > 0) //Skipping the Count.
                    {
                        branches = connection.GetClient<GitHttpClient>().GetBranchesAsync(project.Id, repo.Id.ToString()).Result;
                    }
                    else
                    {
                       branches = connection.GetClient<GitHttpClient>().GetBranchesAsync(project.Id, repo.Id.ToString()).Result;
                    }

                    foreach(var branch in branches)

                    {
                        BranchDetails.InsertDataIntoBranchesData(branch, project.Id.ToString(), repo.Id.ToString());
                    }

                }
            }
                return prs;
            }
        

        public static TeamProjectReference FindAnyProject(VssConnection connection)
        {
            TeamProjectReference project;
            if (!FindAnyProject(connection,out project))
            {
                throw new Exception("No sample projects available. Create a project in this collection and run the sample again.");
            }
            return project;
        }

        public static bool FindAnyProject(VssConnection connection, out TeamProjectReference project)
        {
            // Check if we already have a default project loaded
            ProjectHttpClient projectClient = connection.GetClient<ProjectHttpClient>();
            project = projectClient.GetProjects(null, top: 100).Result.FirstOrDefault();
            return project != null;
        }
    }
}
