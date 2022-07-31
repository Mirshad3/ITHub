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
        public DbSet<JobFunction> jobFunction { get; set; }

        public DbSet<JobTechnologies> jobTechnologies { get; set; }
        public DbSet<JobWithExperienceLevel> jobWithExperienceLevels { get; set; }
        public DbSet<JobWithFunction> jobWithFunction { get; set; }
        public DbSet<JobWithTechnologies> jobWithTechnologies { get; set; }
        public DbSet<WorkMode> workModes { get; set; }
        public DbSet<Remuneration> remuneration { get; set; }
        public DbSet<ExperienceLevel> experienceLevels { get; set; }
        public DbSet<CurrencyType> currencyTypes  { get; set; }
        public DbSet<RemunerationRange> remunerationRanges { get; set; }
        public DbSet<DatePosted> datePosteds { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<ExperienceLevel>().HasData(
                new ExperienceLevel() {  Id=1,Name = "Internship", Value = "Internship" },
                new ExperienceLevel() {   Id=2,Name = "Associate ", Value = "Associate " },
                new ExperienceLevel() {   Id=3,Name = "Junior", Value = "Junior" },
                new ExperienceLevel() {   Id=4,Name = "Mid Level", Value = "MidLevel" },
                new ExperienceLevel() {   Id=5,Name = "Senior", Value = "Senior" },
                new ExperienceLevel() {   Id=6,Name = "Associate Lead", Value = "AssociateLead" },
                new ExperienceLevel() {   Id=7,Name = "Lead", Value = "Lead" });
            modelBuilder.Entity<JobTechnologies>().HasData(
               new JobTechnologies() { Id=1,Name = "HTML", Value = "HTML" },
               new JobTechnologies() { Id=2,Name = ".Net", Value = ".Net" },
               new JobTechnologies() { Id=3,Name = "Node", Value = "Node" });
            modelBuilder.Entity<JobFunction>().HasData(
               new JobFunction() { Id=1,Name = "Frontend", Value = "Frontend" },
               new JobFunction() { Id=2,Name = "Backend", Value = "Backend" },
               new JobFunction() { Id=3,Name = "IT Support", Value = "ITSupport" });
            modelBuilder.Entity<JobType>().HasData(
               new JobType() { Id=1,Name = "Part time", Value = "Part time" },
               new JobType() { Id=2,Name = "Full time", Value = "Full time" },
               new JobType() { Id=3,Name = "Freelance", Value = "Freelance" },
                new JobType() { Id=4,Name = "Contract", Value = "Contract" },
                 new JobType() { Id=5,Name = "Temporary", Value = "Temporary" });
            modelBuilder.Entity<WorkMode>().HasData(
               new WorkMode() { Id=1,Name = "Remote", Value = "Remote" },
               new WorkMode() { Id=2,Name = "On-Premise", Value = "On-Premise" },
               new WorkMode() { Id=3,Name = "Hybrid", Value = "Hybrid" });
            modelBuilder.Entity<Remuneration>().HasData(
               new Remuneration() { Id=1,Name = "By Yearly", Value = "ByYearly" },
               new Remuneration() { Id=2,Name = "By Monthly", Value = "ByMonthly" },
               new Remuneration() { Id=3,Name = "By Daily", Value = "ByDaily" },
                new Remuneration() { Id=4,Name = "By Hourly", Value = "ByHourly" },
                 new Remuneration() { Id=5,Name = "By Contract", Value = "ByContract" });
            modelBuilder.Entity<RemunerationRange>().HasData(
               new RemunerationRange() { Id=1,Name = "50k - 100k", Value = 1 },
               new RemunerationRange() { Id=2,Name = "100k - 150k", Value = 2 },
               new RemunerationRange() { Id=3,Name = "150k - 200k", Value = 3},
                new RemunerationRange() { Id=4,Name = "200k+", Value = 4 });
            modelBuilder.Entity<DatePosted>().HasData(
               new DatePosted() { Id=1,Name = "Past 24 hrs", Value = "Past24hrs" },
               new DatePosted() { Id=2,Name = "Past Week", Value = "PastWeek" },
               new DatePosted() { Id=3,Name = "Past Month", Value = "PastMonth" });
           
        }
    }
}
