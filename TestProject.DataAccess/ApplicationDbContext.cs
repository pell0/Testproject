using Microsoft.EntityFrameworkCore;
using System;
using TestProject.Common;

namespace TestProject.DataAccess
{
    public class ApplicationDbContext:DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
            
        }

        public DbSet<Person> People { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            BuildPeopleModel(modelBuilder);   
        }

        private void BuildPeopleModel(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Person>().HasKey(m => m.Id);
            modelBuilder.Entity<Person>().Property(m => m.Name).HasMaxLength(20);
        }
    }
}
