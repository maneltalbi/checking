using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CheckingSystem.Models;

namespace CheckingSystem.Models
{
    public class CheckingSystemDBContext  : DbContext
    {
        public CheckingSystemDBContext(DbContextOptions<CheckingSystemDBContext> options)
           : base(options)
        {
        }

        public DbSet<admin> admin { get; set; }
        public DbSet<Categories> Categories { get; set; }
        public DbSet<Users> Users { get; set; }
        public DbSet<SupportAgents> SupportAgents { get; set; }
        public DbSet<Incidents> Incidents { get; set; }
        public DbSet<CheckingSystem.Models.SubCategories> SubCategories { get; set; }

    }
}
