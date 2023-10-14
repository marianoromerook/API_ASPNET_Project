using API_RESTful_Project.Models;

namespace API_RESTful_Project.Services
{
    public class StoreDiscountService : IStoreDiscountService
    {
        private readonly Dictionary<int, StoreDiscountConfiguration>? _storeDiscountConfigurations;

        public StoreDiscountService()
        {
            // Simulación de datos de configuración de descuentos
            _storeDiscountConfigurations = new Dictionary<int, StoreDiscountConfiguration>
            {
                {
                    1, new StoreDiscountConfiguration
                    {
                        StoreId = 1,
                        GeneralDiscount = 0.0m // Inicialmente, no se establece ningún descuento
                    }
                },
                // Agregar más configuraciones para otras tiendas
            };
        }

        public StoreDiscountConfiguration GetStoreDiscountConfiguration(int storeId)
        {
            if (_storeDiscountConfigurations.ContainsKey(storeId))
            {
                return _storeDiscountConfigurations[storeId];
            }
            throw new StoreNotFoundException($"Store with ID {storeId} not found");
        }

        public void SetGeneralDiscount(int storeId, decimal discount)
        {
            if (_storeDiscountConfigurations.ContainsKey(storeId))
            {
                _storeDiscountConfigurations[storeId].GeneralDiscount = discount;
            }
            else
            {
                throw new StoreNotFoundException($"Store with ID {storeId} not found");
            }
        }
    }
}
