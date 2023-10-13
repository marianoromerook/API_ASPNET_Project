using API_RESTful_Project.ModulesAPI.WooCommerce.Models;

namespace API_RESTful_Project.Services
{
    public class CartCalculator: IcartCalculator

    {
        public decimal CalculateCartTotal(WooCustomers wooCustomer)
        {
            // Implementa la lógica para calcular el valor total del carrito.
            decimal totalAmount = 0.0m;

            // ... (lógica para calcular el total del carrito)

            return totalAmount;
        }
    }


}
