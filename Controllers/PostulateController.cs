using API_RESTful_Project.Models;
using Microsoft.AspNetCore.Mvc;

namespace API_RESTful_Project.Controllers
{
    [Route("api/postulate")]
    [ApiController]
    public class PostulateController : ControllerBase
    {
        // Acción para crear una publicación
        [HttpPost("Create")]
        public IActionResult Create([FromBody] Postulate postulate)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    if (postulate.Title == "Error")
                    {
                        throw new Exception("An error occurred during creation");
                    }

                    // Procesar la publicación, por ejemplo, guardarla en la base de datos
                    // Si tienes una clase de servicio para manejar la lógica de negocio, aquí sería un buen lugar para invocarla

                    return Ok(new { message = "Post created successfully" });

                }

                return BadRequest(ModelState);

            }

            catch (Exception ex)
            {
                // Registra la excepción
                Console.WriteLine($"Error: {ex.Message}");

                // Devuelve una respuesta de error
                return StatusCode(500, new { message = "An internal error occurred on the server" });
            }

        }

        // Otra acción para mostrar un mensaje de éxito
        [HttpGet("Exit")]
        public IActionResult Exit()
        {
            return Ok(new { message = "Éxit" });
        }
    }
}

