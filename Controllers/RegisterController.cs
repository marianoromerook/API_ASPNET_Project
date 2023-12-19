using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using API_RESTful_Project.Models;
using API_RESTful_Project.Services;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using API_RESTful_Project.Exceptions;
using static API_RESTful_Project.Models.DbContextApp;

namespace API_RESTful_Project.Controllers
{
    [Route("api/register")]
    [ApiController]
    public class RegisterController : ControllerBase
    {
        private readonly DbContextApp _dbContext;
        private readonly PasswordService _passwordService;
        private readonly IConfiguration _configuration;
        private readonly ILogger<RegisterController> _logger;

        public RegisterController(DbContextApp dbContext, PasswordService passwordService, IConfiguration configuration, ILogger<RegisterController> logger)
        {
            _dbContext = dbContext;
            _passwordService = passwordService;
            _configuration = configuration;
            _logger = logger;
        }

        [HttpPost]
        public IActionResult Register([FromBody] RegistrationRequest request)
        {
            try
            {
                if (request == null)
                {
                    throw new BadRequestException("Invalid registration request");
                }

                // Verificar si el usuario ya existe en la base de datos
                var existingUser = _dbContext.Users.FirstOrDefault(u => u.UserName == request.Username);
                if (existingUser != null)
                {
                    return BadRequest("El nombre de usuario ya está en uso");
                }

                // Generar un salt aleatorio
                string salt = BCrypt.Net.BCrypt.GenerateSalt();

                // Concatenar el salt con la contraseña del usuario
                string hashedPassword = _passwordService.HashPassword(request.Password + salt);

                // Guardar el hash de la contraseña y el salt en la base de datos
                var newUser = new User
                {
                    UserName = request.Username,
                    PasswordHash = hashedPassword,
                    Salt = salt
                };

                // Guardar el nuevo usuario en la base de datos
                _dbContext.Users.Add(newUser);
                _dbContext.SaveChanges();

                // Generar token JWT
                var tokenHandler = new JwtSecurityTokenHandler();
                var secretKey = _configuration["IssuerSigningKey"];
                var key = Encoding.UTF8.GetBytes(secretKey);

                var tokenDescriptor = new SecurityTokenDescriptor
                {
                    Subject = new ClaimsIdentity(new Claim[]
                    {
                    new Claim(ClaimTypes.Name, newUser.UserName) // Puedes agregar más claims según tus necesidades
                    }),
                    Expires = DateTime.UtcNow.AddDays(7), // Tiempo de expiración del token
                    SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
                };

                var token = tokenHandler.CreateToken(tokenDescriptor);
                var tokenString = tokenHandler.WriteToken(token);

                return Ok(new { Token = tokenString });

            }

            catch(BadRequestException ex)
            {
                return BadRequest(ex.Message);
            }

            catch (Exception ex)
            {
                _logger.LogError(ex, "An unexpected error occurred.");
                return StatusCode(500, "An unexpected error occurred.");
            }

        }

        [HttpPost("seed-users")]
        public IActionResult SeedUsers()
        {
            try
            {
                // Llama al método para insertar usuarios ficticios
                DbContextApp.DataSeeder.SeedData(_dbContext);

                return Ok("Usuarios ficticios insertados en la base de datos.");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An unexpected error occurred.");
                return StatusCode(500, "An unexpected error occurred.");
            }
        }

        [HttpPost("create-test-user")]
        public IActionResult CreateTestUser()
        {
            try
            {
                // Llama al método para crear el usuario de prueba
                DbContextApp.DataSeeder.SeedTestUser(_dbContext, _passwordService);

                return Ok("Usuario de prueba creado exitosamente.");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An unexpected error occurred.");
                return StatusCode(500, "An unexpected error occurred.");
            }
        }

    }

    public class RegistrationRequest
    {
        public string? Username { get; set; }
        public string? Password { get; set; }
    }


}

