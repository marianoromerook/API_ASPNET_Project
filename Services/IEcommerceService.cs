namespace API_RESTful_Project.Services
{
    public interface IEcommerceService
    {
        Task ApplyDiscountAsync(int productId, decimal discountAmount);
        Task RevertDiscountAsync(int productId);
    }

    public class EcommerceServiceException : Exception
    {
        public EcommerceServiceException(string message) : base(message) { }
    }

    public class NetworkException : Exception
    {
        public NetworkException(string message) : base(message) { }
    }
}
