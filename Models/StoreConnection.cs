using System.ComponentModel.DataAnnotations;

namespace API_RESTful_Project.Models
{
    public class StoreConnection
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "La URL de WooCommerce es obligatoria")]
        [Display(Name = "URL de WooCommerce")]
        public string WooCommerceUrl { get; set; } = string.Empty;
        public string WooCommerceConsumerKey { get; set; } = string.Empty;
        public string WooCommerceConsumerSecret { get; set; } = string.Empty;

        [Display(Name = "URL de Shopify")]
        [Required(ErrorMessage = "La URL de Shopify es obligatoria")]
        public string ShopifyUrl { get; set; } = string.Empty;
        public string ShopifyApiKey { get; set; } = string.Empty;
        public string ShopifyApiSecret { get; set; } = string.Empty;
    }
}
