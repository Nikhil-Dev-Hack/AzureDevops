using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace JWT_Authentication.Models
{
    public partial class APIContext : DbContext
    {
        public APIContext(DbContextOptions<APIContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Products> Products { get; set; }
        public virtual DbSet<UserInfo> UserInfo { get; set; }
    }
}
