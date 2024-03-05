using Kindergarden_Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace Kindergarden_Data
{
    public class KindergardenDbContext : DbContext
    {
        public KindergardenDbContext()
        {
        }
        public KindergardenDbContext(DbContextOptions options)
        : base(options) { }

        public DbSet<Kid> Kids { get; set; }
        public DbSet<Parent> Parents { get; set; }
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
            // Configure the constant table
            modelBuilder.Entity<Kindergarden_Models.Group>().HasData(
                new Kindergarden_Models.Group { GroupId = 1, GroupName = "Kometa" },
                new Kindergarden_Models.Group { GroupId = 2, GroupName = "Luna" },
                new Kindergarden_Models.Group { GroupId = 3, GroupName = "Zvezdichka" },
                new Kindergarden_Models.Group { GroupId = 4, GroupName = "Slunchice" }
            );


        }
        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    //при изтриване на компания да се трие само ако няма филми направени от тази компания
        //    modelBuilder.Entity<Company>()
        //        .HasMany(x => x.Movies)
        //        .WithOne(x => x.Company)
        //        .OnDelete(DeleteBehavior.Restrict);

        //    // този метод може и да го няма
        //}
    }
}

