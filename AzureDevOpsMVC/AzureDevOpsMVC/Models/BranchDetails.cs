using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace AzureDevOpsMVC.Models
{
    public class BranchDetails
    {
        [Key]
        public string Name { get; set; }
        public Int64 AheadCount { get; set; }
        public Int64 BehindCount { get; set; }
        public string CommitId { get; set; }
        public Int64 Comment { get; set; }
        public Int64 URL { get; set; }
        public Int64 Author { get; set; }
        public string Commiter { get; set; }
        public string RepoId { get; set; }
        public string ProjectId { get; set; }
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public string Sno { get; set; }
    }
}
