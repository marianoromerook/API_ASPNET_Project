using System.Net.Http;

namespace API_RESTful_Project.Services
{
    public class EcommerceService : IEcommerceService
    {
        private readonly HttpClient httpClient;
        private readonly string woocommerceApiBaseUrl;

        public EcommerceService(HttpClient httpClient, string woocommerceApiBaseUrl)
        {
            this.httpClient = httpClient;
            this.woocommerceApiBaseUrl = woocommerceApiBaseUrl;
        }

        public async Task ApplyDiscountAsync(int customerId, decimal discountAmount)
        {
            try
            {
                // Construye la URL de la API para aplicar el descuento al cliente con el customerId en WooCommerce
                string requestUri = $"{woocommerceApiBaseUrl}/customers/{customerId}";

                // Realiza una solicitud HTTP para obtener la información del cliente desde WooCommerce
                var customerResponse = await httpClient.GetAsync(requestUri);

                if (customerResponse.IsSuccessStatusCode)
                {
                    // Procesar la información del cliente y aplica el descuento según la lógica de WooCommerce.
                    // Esto podría implicar actualizar los precios de los productos o aplicar cupones de descuento.
                    // Asegrar  consultar la documentación de la API de WooCommerce para implementar esta lógica.

                   
                    // var customer = JsonConvert.DeserializeObject<Customer>(await customerResponse.Content.ReadAsStringAsync());
                    // customer.Discount = discountAmount;
                    // Actualiza la información del cliente en WooCommerce.
                }
                else
                {
                    throw new EcommerceServiceException($"No se pudo obtener la información del cliente de WooCommerce. Estado de respuesta: {customerResponse.StatusCode}");
                }
            }
            catch (HttpRequestException ex)
            {
                throw new EcommerceServiceException($"Error al aplicar el descuento en WooCommerce: {ex.Message}");
            }
        }

        public async Task RevertDiscountAsync(int customerId)
        {
            try
            {
                // Construye la URL de la API para revertir el descuento del cliente con el customerId en WooCommerce
                string requestUri = $"{woocommerceApiBaseUrl}/customers/{customerId}";

                // Realiza una solicitud HTTP para obtener la información del cliente desde WooCommerce
                var customerResponse = await httpClient.GetAsync(requestUri);

                if (customerResponse.IsSuccessStatusCode)
                {
                    // Procesar la información del cliente y revierte el descuento según la lógica de WooCommerce.
                    // Esto podría implicar eliminar los descuentos aplicados o restaurar los precios originales de los productos.
                    // Asegúrate de consultar la documentación de la API de WooCommerce para implementar esta lógica.

                    
                    // var customer = JsonConvert.DeserializeObject<Customer>(await customerResponse.Content.ReadAsStringAsync());
                    // customer.Discount = 0; // Elimina el descuento
                    // Actualiza la información del cliente en WooCommerce.
                }
                else
                {
                    throw new EcommerceServiceException($"No se pudo obtener la información del cliente de WooCommerce. Estado de respuesta: {customerResponse.StatusCode}");
                }
            }
            catch (HttpRequestException ex)
            {
                throw new EcommerceServiceException($"Error al revertir el descuento en WooCommerce: {ex.Message}");
            }


        }
    }
}
