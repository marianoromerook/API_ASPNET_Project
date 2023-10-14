namespace API_RESTful_Project.Models
{
    public class StoreDiscountConfiguration
    {
        public int StoreId { get; set; }
        public Dictionary<string, decimal>? DiscountMapping { get; set; }
        public decimal GeneralDiscount { get; set; }

    }
}
