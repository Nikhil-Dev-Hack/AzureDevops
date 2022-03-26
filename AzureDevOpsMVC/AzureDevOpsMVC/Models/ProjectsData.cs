using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AzureDevOpsMVC.Models
{
   public class ProjectsData
    {
        [Key]
        public string ProjectName { get; set; }
        public string ProjectId { get; set; }
        public string Description { get; set; }
        public string URL { get; set; }
        public Int64 ReposCount { get; set; }

    }
}
