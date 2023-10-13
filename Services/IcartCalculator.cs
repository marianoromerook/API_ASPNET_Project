using API_RESTful_Project.ModulesAPI.WooCommerce.Models;

namespace API_RESTful_Project.Services
{
    public interface IcartCalculator
    {
        decimal CalculateCartTotal(WooCustomers wooCustomer);
    }
}
