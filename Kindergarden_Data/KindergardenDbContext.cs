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
            //при изтриване на идасшев да се трие само ако няма децана този родител
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
            
            //modelBuilder.Entity<Parent>().HasData(

            //    new Parent { ParentId = 1, FirstName = "Anton", LastName = "Donov", PhoneNumber = "0897596243", Address = "Pazardjik, Ulitsa 7"},
            //    new Parent { ParentId = 2, FirstName = "Borqna", LastName = "Valcheva", PhoneNumber = "0886489235", Address = "Pazardjik, Ulitsa 8"},
            //    new Parent { ParentId = 3, FirstName = "Ceca", LastName = "Trepni", PhoneNumber = "0893465955", Address = "Pazardjik, Ulitsa 9"},
            //    new Parent { ParentId = 4, FirstName = "Deez", LastName = "Nuts", PhoneNumber = "0875966356", Address = "Pazardjik, Ulitsa 10"},
            //    new Parent { ParentId = 5, FirstName = "Emanuel", LastName = "Kant", PhoneNumber = "0887528744", Address = "Pazardjik, Ulitsa 11"}
            //);

            //modelBuilder.Entity<Kid>().HasData(
            //    new Kid { KidId = 1, FirstName = "Mariqn",LastName = "Ganev",Age = 4, ParentId = 2, GroupId = 2},
            //    new Kid { KidId = 2, FirstName = "Pitagor",LastName = "Kant",Age = 3, ParentId = 5, GroupId = 1},
            //    new Kid { KidId = 3, FirstName = "Kukuvica",LastName = "Trepni",Age = 6, ParentId = 3, GroupId = 4},
            //    new Kid { KidId = 4, FirstName = "Petkan",LastName = "Ganev",Age = 6, ParentId = 2, GroupId = 4},
            //    new Kid { KidId = 5, FirstName = "Kaloqn",LastName = "Donov",Age = 4, ParentId = 1, GroupId = 2},
            //    new Kid { KidId = 6, FirstName = "Dragondis",LastName = "Nuts",Age = 3, ParentId = 4, GroupId = 1}
            //);



        }
    }
}

