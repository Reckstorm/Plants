using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Plants.Model
{
    internal class Context : DbContext
    {
        DbSet<User> users;
        DbSet<Role> roles;
        DbSet<Plant> plants;
        public Context() { }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=localhost\\SQLEXPRESS;Database=PlantsDB;Trusted_Connection=True;TrustServerCertificate=True;");
        }
    }
}
