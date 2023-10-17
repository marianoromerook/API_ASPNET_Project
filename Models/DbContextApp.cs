using Microsoft.EntityFrameworkCore;
using Bogus;



namespace API_RESTful_Project.Models
{
    public class DbContextApp : DbContext
    {
        public DbSet<User> Users { get; set; }

        public DbSet<Postulate> Postulates { get; set; }

        public DbSet<UserNetwork> UserNetworks { get; set; }

        public DbSet<StoreConnection> StoreConnections { get; set; }

        private readonly IConfiguration _configuration;



        public DbContextApp(DbContextOptions<DbContextApp> options, IConfiguration configuration) : base(options)
        {
            _configuration = configuration;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql(_configuration.GetConnectionString("DefaultConnection"));
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<UserNetwork>().HasNoKey();

            modelBuilder.Entity<StoreConnection>().ToTable("StoreConnections");

            modelBuilder.Entity<Postulate>()
                .HasOne(p => p.Usuario)
                .WithMany(u => u.Postulates) // Agregar esta línea para establecer la propiedad de navegación inversa
                .HasForeignKey(p => p.UsuarioId);
        }

        public class DataSeeder
        {
            public static void SeedData(DbContextApp context)
            {
                var faker = new Faker<User>()
                    .RuleFor(u => u.UserName, f => f.Internet.UserName())
                    .RuleFor(u => u.Email, (f, u) => f.Internet.Email(u.UserName))
                    .RuleFor(u => u.PasswordHash, f => f.Internet.Password());

                var users = faker.Generate(10); // Generar 10 usuarios ficticios

                context.Users.AddRange(users);
                context.SaveChanges();
            }
        }
    }
}
