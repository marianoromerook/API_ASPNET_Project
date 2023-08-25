using API_RESTful_Project.Exceptions;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using WooCommerceNET;
using WooCommerceNET.WooCommerce.v3;

namespace API_RESTful_Project.ModulesAPI.WooCommerce.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WooController : ControllerBase
    {
        private readonly RestAPI _woocommerceApi;

        public WooController(IConfiguration configuration)
        {
            // Obtiene las credenciales desde la configuración (reemplaza con tu lógica)
            string baseUrl = configuration["WooCommerce:BaseUrl"];
            string consumerKey = configuration["WooCommerce:ConsumerKey"];
            string consumerSecret = configuration["WooCommerce:ConsumerSecret"];

            if (string.IsNullOrEmpty(baseUrl) || string.IsNullOrEmpty(consumerKey) || string.IsNullOrEmpty(consumerSecret))
            {
                // Maneja el caso en que alguna de las credenciales sea nula o vacía
                throw new InvalidOperationException("Credenciales de WooCommerce no configuradas correctamente.");
            }

            _woocommerceApi = new RestAPI(baseUrl, consumerKey, consumerSecret);
        }

        [HttpGet("customers")]
        public IActionResult GetCustomers()
        {
            try
            {
                var wc = new WCObject(_woocommerceApi);
                var customers = wc.Customer.GetAll();
                return Ok(customers);
            }
            catch (WooRequestException ex)
            {
                // Captura y maneja las excepciones específicas de WooCommerce
                return StatusCode(StatusCodes.Status500InternalServerError, $"Error al acceder a WooCommerce API: {ex.Message}");
            }
            catch (WebException ex)
            {
                // Captura y maneja las excepciones de red (por ejemplo, errores de conexión)
                return StatusCode(StatusCodes.Status500InternalServerError, "Error de red al acceder a WooCommerce API");
            }
            catch (Exception ex)
            {
                // Captura y maneja cualquier otra excepción no prevista
                return StatusCode(StatusCodes.Status500InternalServerError, $"Error interno en el servidor: {ex.Message}");
            }
        }
    }
}
