using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ScentApp.Model;

namespace ScentApp
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions options) : base(options)
        {
        }
        public DbSet<Template> Templates { get; set; }

        public DbSet<Project> Projects { get; set; }

        public DbSet<Category> Categories { get; set; }

        public DbSet<Requirement> Requirements { get; set; }

    }
}
