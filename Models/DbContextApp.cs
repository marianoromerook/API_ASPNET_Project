using Microsoft.EntityFrameworkCore;
using API_RESTful_Project.Models;

namespace API_RESTful_Project.Models
{
    public class DbContextApp: DbContext
    {
        public DbSet<User> Users { get; set; }


        public DbContextApp(DbContextOptions<DbContextApp> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            
        }
    }
}
