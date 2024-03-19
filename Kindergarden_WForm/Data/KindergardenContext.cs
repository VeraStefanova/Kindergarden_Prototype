using Kindergarden_Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Kindergarden_Models;
using Kindergarden_Services;


namespace Kindergarden_WForm.Data
{
    public class KindergardenContext : KindergardenDbContext
    {
        public KindergardenContext(DbContextOptions options) : base(options)
        {

        }
        public DbSet<Kid> Kids { get; set; }
        public DbSet<Parent> Parents { get; set; }
        public DbSet<Group> Groups { get; set; }
    }

}
