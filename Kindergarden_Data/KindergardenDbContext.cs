using Kindergarden_Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

/// <summary>Represents the database context for the kindergarten application,
/// providing access to entities such as kids, parents, and groups.</summary>
namespace Kindergarden_Data
{
    public class KindergardenDbContext : DbContext
    {
        public KindergardenDbContext()
        {
        }
        public KindergardenDbContext(DbContextOptions options)
        : base(options) { }

        /// <summary>Gets or sets the kids from the database.</summary>
        /// <value>The kids.</value>
        public DbSet<Kid> Kids { get; set; }
        /// <summary>Gets or sets the parents from the database .</summary>
        /// <value>The parents.</value>
        public DbSet<Parent> Parents { get; set; }
        /// <summary>Gets or sets the groups from the database.</summary>
        /// <value>The groups.</value>
        public DbSet<Kindergarden_Models.Group> Groups { get; set; }

        
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=KAMENPC\\SQLEXPRESS;Database=Kindergarden;Integrated Security=true;TrustServerCertificate=True");
            }

        }

       
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            
            modelBuilder.Entity<Parent>()
                .HasMany(x => x.Kids)
                .WithOne(x => x.Parent)
                .OnDelete(DeleteBehavior.Restrict);


            // Configure the constant table
            modelBuilder.Entity<Kindergarden_Models.Group>().HasData(
                new Kindergarden_Models.Group() { GroupId = 1, GroupName = "Kometa" },
                new Kindergarden_Models.Group() { GroupId = 2, GroupName = "Luna" },
                new Kindergarden_Models.Group() { GroupId = 3, GroupName = "Zvezdichka" },
                new Kindergarden_Models.Group() { GroupId = 4, GroupName = "Slunchice" }
            );
            

        }
    }
}

