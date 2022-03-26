using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using ALLMVC.Models;

namespace ALLMVC.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<ALLMVC.Models.Department> Department { get; set; }
        public DbSet<ALLMVC.Models.Employee> Employee { get; set; }
        public DbSet<ALLMVC.Models.EmpDep> EmpDep { get; set; }
        public DbSet<ALLMVC.Models.SocialIcon> socialIcons { get; set; }

        //protected override void OnModelCreating(ModelBuilder builder)
        //{
        //    base.OnModelCreating(builder);  
        //    builder.Entity<SocialIcon>().HasData(new SocialIcon { ID = 1, IconName = "Google", IconBgColor = "#dd4b39", IconTargetUrl = "www.google.com", IconClass = "fa fa-google" });
        //    builder.Entity<SocialIcon>().HasData(new SocialIcon { ID = 2, IconName = "Facebook", IconBgColor = "#3B5998", IconTargetUrl = "www.facebook.com", IconClass = "fa fa-facebook" });
        //    builder.Entity<SocialIcon>().HasData(new SocialIcon { ID = 3, IconName = "Linked In", IconBgColor = "#007bb5", IconTargetUrl = "www.linkedin.com", IconClass = "fa fa-fa-linkedin" });
        //    builder.Entity<SocialIcon>().HasData(new SocialIcon { ID = 4, IconName = "YouTube", IconBgColor = "#007bb5", IconTargetUrl = "www.youtube.com", IconClass = "fa fa-youtube" });
        //    builder.Entity<SocialIcon>().HasData(new SocialIcon { ID = 5, IconName = "Twitter", IconBgColor = "#55acee", IconTargetUrl = "www.twitter.com", IconClass = "fa fa-twitter" });
        //}
    }
}
