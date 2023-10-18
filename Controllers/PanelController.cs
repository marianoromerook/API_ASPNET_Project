using API_RESTful_Project.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API_RESTful_Project.Controllers
{
    [Route("api/panel")]
    [ApiController]
    public class PanelController : ControllerBase
    {
        [HttpPost("woocommerce")]
        public async Task<IActionResult> ConnectToWooCommerce([FromBody] StoreConnection connectionInfo)
        {
            // Aquí deberías manejar la lógica para conectarte a la tienda WooCommerce
            // Utiliza la información proporcionada en el objeto StoreConnectionInfo
            // Realiza las solicitudes a la API de WooCommerce y guarda las credenciales si es necesario

            // Ejemplo de respuesta exitosa
            return Ok("Conexión exitosa a WooCommerce");
        }

        [HttpPost("magento")]
        public async Task<IActionResult> ConnectToMagento([FromBody] StoreConnection connectionInfo)
        {
            // Aquí deberías manejar la lógica para conectarte a la tienda Magento
            // Utiliza la información proporcionada en el objeto StoreConnectionInfo
            // Realiza las solicitudes a la API de Magento y guarda las credenciales si es necesario

            // Ejemplo de respuesta exitosa
            return Ok("Conexión exitosa a Magento");
        }
    }
}
