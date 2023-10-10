using WooCommerceNET.WooCommerce.Legacy;

namespace API_RESTful_Project.Services
{
    public interface ICustomerService
    {
        Task<IEnumerable<Customer>> GetCustomersAsync();
        Task<Customer> GetCustomerByIdAsync(int customerId);

    }

    public class CustomerServiceException : Exception
    {
        public CustomerServiceException(string message) : base(message) { }
    }

    
}
