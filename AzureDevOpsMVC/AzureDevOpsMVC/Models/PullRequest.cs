using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AzureDevOpsMVC.Models
{
    public class PullRequest
    {
        [Key]
        public Int64 PullrequestId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Reviewer { get; set; }
        public string Url { get; set; }

        public string SourceRefName { get; set; }
        public string TargetRefName { get; set; }
        public string LastMergeTargetCommit { get; set; }
        public string LastMergeSourceCommit { get; set; }
        public string LastMergeCommit { get; set; }
        public string Status { get; set; }
        public string RepoId { get; set; }
        public string ProjectId { get; set; }
        public string Workid { get; set; }
        public string WorkUrl { get; set; }
    }
}
