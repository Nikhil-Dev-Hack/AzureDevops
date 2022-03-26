using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace AzureDevOpsMVC.Models
{
    [Table("ReposDataOriginal")]
    public class ReposData
    {
        public string RepoName { get; set; }
        public string RepoId { get; set; }
        public string RepoURL { get; set; }
        public string DefaultBranch { get; set; }
        [Key]
        public string ProjectName { get; set; }
        public Int64 CommitCount { get; set; }
    }
}
