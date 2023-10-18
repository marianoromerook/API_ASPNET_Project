using API_RESTful_Project.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API_RESTful_Project.Controllers
{
    [Route("api/search")]
    [ApiController]
    public class SearchController : ControllerBase
    {
        private readonly DbContextApp? _contextApp;

        public SearchController(DbContextApp? contextApp)
        {
            _contextApp = contextApp;
        }

        [HttpGet("Search")]
        public IActionResult Search(string searchCriteria) 
        { 
            try
            {
                if (_contextApp != null)
                {
                    var postulatesFound = _contextApp?.Postulates
                        ?.Where(p => p.Title.Contains(searchCriteria) || p.Content.Contains(searchCriteria))
                        .ToList() ?? new List<Postulate>();

                    return Ok(postulatesFound); // Devuelve una respuesta 200 OK con los datos encontrados
                }

                return StatusCode(500, new { message = "An error on server" });
            }

            catch (Exception ex)
            {
                return StatusCode(500, new { message = "An error on server", error = ex.Message });
            }


        }
    }
}
