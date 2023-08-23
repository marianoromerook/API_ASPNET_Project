using Microsoft.AspNetCore.Mvc;
using API_RESTful_Project.Models;
using API_RESTful_Project.Services;

namespace PlatformProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly DbContextApp _dbContext;
        private readonly PasswordService _passwordService;

        public LoginController(DbContextApp dbContext, PasswordService passwordService)
        {
            _dbContext = dbContext;
            _passwordService = passwordService;
        }

        [HttpPost]
        public IActionResult Login([FromBody] LoginRequestModel request)
        {
            try
            {
                var user = _dbContext.Users.FirstOrDefault(u => u.UserName == request.Username);

                if (user != null && !string.IsNullOrEmpty(user.PasswordHash) && !string.IsNullOrEmpty(user.Salt) && _passwordService.VerifyPassword(request.Password, user.PasswordHash, user.Salt))
                {
                    // Usuario autenticado correctamente, devuelve un resultado exitoso
                    return Ok(new { message = "Autenticación exitosa" });
                }

                // Usuario no válido, devuelve un resultado con un mensaje de error
                return BadRequest(new { message = "Credenciales inválidas" });
            }
            catch (Exception ex)
            {
                // Manejo de excepciones: devuelve una respuesta con detalles del error
                return StatusCode(500, new { message = "Error interno del servidor", error = ex.Message });
            }
        }
    }
    public class LoginRequestModel
    {
        public string? Username { get; set; }
        public string? Password { get; set; }
    }
}
