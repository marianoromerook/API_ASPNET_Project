using API_RESTful_Project.Models;
using API_RESTful_Project.ModulesAPI.WooCommerce.Models;
using System;
using System.Collections.Generic;

namespace API_RESTful_Project.Services
{
    public class DiscountEcommerce
    {
        public decimal CalculateDiscount(WooCustomers wooCustomer, List<DiscountEcommerce> discounts, DiscountPreference preference)
        {
            try
            {
                decimal cartTotal = CalculateCartTotal(wooCustomer);
                decimal totalDiscount = 0;

                foreach (var discount in discounts)
                {
                    // Puedes buscar descuentos que coincidan con productos en el carrito o con las preferencias del cliente.
                    // Implementa la lógica según tus necesidades.

                    // Accede a la propiedad DiscountPreference a través del objeto Discount
                    totalDiscount += CalculateCustomerPreferenceDiscount(preference, cartTotal);
                }

                return totalDiscount;
            }
            catch (Exception ex)
            {
                // Maneja excepciones generales
                // Registra o notifica el error según sea necesario
                throw new DiscountEcommerceException("Error en el cálculo del descuento", ex);
            }
        }

        private decimal CalculateCartTotal(WooCustomers wooCustomer)
        {
            // Implementa la lógica para calcular el valor total del carrito, que puede implicar recorrer los productos y sumar sus precios.
            decimal totalAmount = 0.0m;

            // ... (lógica para calcular el total del carrito)

            return totalAmount;
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
    }

    public class DiscountEcommerceException : Exception
    {
        public DiscountEcommerceException(string message, Exception innerException) : base(message, innerException) { }
    }
}
