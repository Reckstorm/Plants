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
        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<Plant> Plants { get; set; }
        private static Context _context;
        public Context() { }
        public static Context GetInstance() 
        {
            if (_context == null)
            {
                _context = new Context();
            }
            return _context; 
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=localhost\\SQLEXPRESS;Database=PlantsDB;Trusted_Connection=True;TrustServerCertificate=True;");
        }
    }
}
