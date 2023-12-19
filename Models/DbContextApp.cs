using Microsoft.EntityFrameworkCore;
using Bogus;
using API_RESTful_Project.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;


namespace API_RESTful_Project.Models
{
    public class DbContextApp : DbContext
    {
        public DbSet<User> Users { get; set; }

        public DbSet<Postulate> Postulates { get; set; }

        public DbSet<UserNetwork> UserNetworks { get; set; }

        //public DbSet<LinkModel> Links { get; set; }

        private readonly IConfiguration _configuration;
        private readonly PasswordService _passwordService;


        public DbContextApp(DbContextOptions<DbContextApp> options, IConfiguration configuration, PasswordService passwordService) : base(options)
        {
            _configuration = configuration;
            _passwordService = passwordService;

            // Aplicar migraciones al iniciar la aplicación
            Database.Migrate();

            // Semilla de datos ficticios
            DataSeeder.SeedData(this);

            // Semilla del usuario de prueba
            DataSeeder.SeedTestUser(this, _passwordService);
        }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql(_configuration.GetConnectionString("DefaultConnection"));
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Postulate>()
                .HasOne(p => p.Usuario)
                .WithMany(u => u.Postulates)
                .HasForeignKey(p => p.UsuarioId)
                .HasPrincipalKey(u => u.Id); 
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

            public static void SeedTestUser(DbContextApp context, PasswordService passwordService)
            {
                // Verificar si el usuario de prueba ya existe en la base de datos
                var existingTestUser = context.Users.FirstOrDefault(u => u.UserName == "test_user");
                if (existingTestUser == null)
                {
                    // Contraseña para el usuario de prueba
                    const string TestUserPassword = "testpassword";

                    // Generar un salt aleatorio
                    string salt = BCrypt.Net.BCrypt.GenerateSalt();

                    // Concatenar el salt con la contraseña del usuario
                    string hashedPassword = passwordService.HashPassword(TestUserPassword + salt);

                    // Crear el usuario de prueba
                    var testUser = new User
                    {
                        UserName = "test_user",
                        PasswordHash = hashedPassword,
                        Salt = salt,
                        Email = "marianoromero40@gmail.com"
                    };

                    // Guardar el usuario de prueba en la base de datos
                    context.Users.Add(testUser);
                    context.SaveChanges();
                }
            }


        }
    }
}
