using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using AzureDevOpsMVC.Models;

namespace AzureDevOpsMVC.Data
{
    public class AzureDevOpsMVCContext : DbContext
    {
        public AzureDevOpsMVCContext (DbContextOptions<AzureDevOpsMVCContext> options)
            : base(options)
        {
        }

        public DbSet<AzureDevOpsMVC.Models.ProjectsData> ProjectsData { get; set; }

        public DbSet<AzureDevOpsMVC.Models.ProjectDetails> ProjectDetails { get; set; }

        public DbSet<AzureDevOpsMVC.Models.BranchDetails> BranchDetails { get; set; }

        public DbSet<AzureDevOpsMVC.Models.ChangesData> ChangesData { get; set; }

        public DbSet<AzureDevOpsMVC.Models.CommitsData> CommitsData { get; set; }

        public DbSet<AzureDevOpsMVC.Models.PullRequest> PullRequest { get; set; }

        public DbSet<AzureDevOpsMVC.Models.ReposData> ReposData { get; set; }
    }
}
