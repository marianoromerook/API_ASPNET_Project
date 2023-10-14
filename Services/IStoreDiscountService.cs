using API_RESTful_Project.Models;

namespace API_RESTful_Project.Services
{
    public interface IStoreDiscountService
    {
        StoreDiscountConfiguration GetStoreDiscountConfiguration(int storeId);
    }
}
