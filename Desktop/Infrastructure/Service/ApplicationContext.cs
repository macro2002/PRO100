using Desktop.Model;
using Desktop.Model.Users;
using Microsoft.EntityFrameworkCore;
using System;

namespace Desktop.Infrastructure.Service
{
    public class ApplicationContext : DbContext
    {
        public DbSet<Organization> Organizations { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Log> Logs { get; set; }


        public ApplicationContext()
        {
            Database.EnsureCreated();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Organization>().HasKey(u => u.ID);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite(string.Format("Data Source={0}Base.db", AppDomain.CurrentDomain.BaseDirectory));
        }
    }
}
