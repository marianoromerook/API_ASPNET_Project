namespace API_RESTful_Project.Models
{
    public class Discount
    {
        public int ProductId { get; set; }
        public decimal Amount { get; set; }
        public DiscountPreference DiscountPreference { get; set; }
    }

    public enum DiscountPreference
    {
        NoDiscount,
        TenPercentOff,
        TwentyPercentOff,
    }
}
