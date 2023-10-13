using API_RESTful_Project.Models;
using API_RESTful_Project.ModulesAPI.WooCommerce.Models;

namespace API_RESTful_Project.Services
{
    public class DiscountEcommerce
    {
        private IcartCalculator? _cartCalculator;

        public DiscountEcommerce(IcartCalculator cartCalculator) 
        { 
            _cartCalculator = cartCalculator;
        }

        public decimal CalculateDiscount(WooCustomers wooCustomer, List<Discount> discounts, DiscountPreference preference)
        {
            try
            {
                decimal cartTotal = _cartCalculator.CalculateCartTotal(wooCustomer);
                decimal totalDiscount = 0;

                foreach (var discount in discounts)
                {
                    totalDiscount += CalculateCustomerPreferenceDiscount(preference, cartTotal);
                }

                return totalDiscount;
            }
            catch (DiscountCalculationException ex)
            {
                // Maneja la excepción específica de cálculo de descuento
                // Registra o notifica el error según sea necesario
                throw ex;
            }
            catch (Exception ex)
            {
                // Maneja otras excepciones generales
                // Registra o notifica el error según sea necesario
                throw new DiscountEcommerceException("Error en el cálculo del descuento", ex);
            }
        }

        private decimal CalculateCustomerPreferenceDiscount(DiscountPreference preference, decimal cartTotal)
        {
            // Implementa la lógica para calcular el descuento basado en la preferencia del cliente.
            switch (preference)
            {
                case DiscountPreference.TenPercentOff:
                    return cartTotal * 0.10m;
                case DiscountPreference.TwentyPercentOff:
                    return cartTotal * 0.20m;
                case DiscountPreference.NoDiscount:
                default:
                    return 0;
            }
        }

        public class DiscountEcommerceException : Exception
        {
            public DiscountEcommerceException(string message, Exception innerException) : base(message, innerException) { }
        }

        public class DiscountCalculationException : Exception
        {
            public DiscountCalculationException(string message) : base(message) { }
        }
    }
}
