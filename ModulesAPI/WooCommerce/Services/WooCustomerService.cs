using API_RESTful_Project.Services;
using Newtonsoft.Json;
using WooCommerceNET.WooCommerce.Legacy;

namespace API_RESTful_Project.ModulesAPI.WooCommerce.Services
{
    public class WooCustomerService : ICustomerService
    {
        private readonly string _apiUrl;
        private readonly string _consumerKey;
        private readonly string _consumerSecret;
        private readonly HttpClient _httpClient;

        public WooCustomerService(string apiUrl, string consumerKey, string consumerSecret)
        {
            _apiUrl = apiUrl;
            _consumerKey = consumerKey;
            _consumerSecret = consumerSecret;

            // Configurar HttpClient con las credenciales
            _httpClient = new HttpClient();
            _httpClient.DefaultRequestHeaders.Add("Authorization", $"Basic {Convert.ToBase64String(System.Text.Encoding.ASCII.GetBytes($"{_consumerKey}:{_consumerSecret}"))}");
        }

        public async Task<IEnumerable<Customer>> GetCustomersAsync()
        {
            try
            {
                var endpoint = "customers";
                var response = await _httpClient.GetStringAsync($"{_apiUrl}/{endpoint}");
                var customers = JsonConvert.DeserializeObject<List<Customer>>(response);
                return customers;
            }
            catch (HttpRequestException ex)
            {
                throw new CustomerServiceException($"Error al obtener los clientes: {ex.Message}");
            }
        }

        public async Task<Customer> GetCustomerByIdAsync(int customerId)
        {
            try
            {
                var endpoint = $"customers/{customerId}";
                var response = await _httpClient.GetStringAsync($"{_apiUrl}/{endpoint}");
                var customer = JsonConvert.DeserializeObject<Customer>(response);
                return customer;
            }
            catch (HttpRequestException ex)
            {
                throw new CustomerServiceException($"Error al obtener el cliente con ID {customerId}: {ex.Message}");
            }
        }
    }
}
