using System;
using System.Collections.Generic;
using System.Text;
using ITHub.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace ITHub.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<Company> companies { get; set; }
        public DbSet<Location> locations { get; set; }
        public DbSet<Job> jobs { get; set; }
        public DbSet<News> news { get; set; }

        public DbSet<Banners> banners { get; set; } 
        public DbSet<JobType> jobTypes { get; set; }    
        public DbSet<QuestionCategory> questionCategories { get; set; }
        public DbSet<Questions> questions { get; set; }
        public DbSet<Samples> samples { get; set; }
        public DbSet<SamplesType> samplesTypes { get; set; }
    }
}
