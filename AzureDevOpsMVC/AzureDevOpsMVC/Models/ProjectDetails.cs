using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace AzureDevOpsMVC.Models
{
    [Table("ProjectsDetails")]
    public class ProjectDetails
    {
            [Key]
            public string URL { get; set; }
            public string Token { get; set; }
    }
}
