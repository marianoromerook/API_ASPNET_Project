namespace API_RESTful_Project.Models
{
    public class ConfigurationConnectionString
    {
        private readonly IConfiguration _configuration;

        public ConfigurationConnectionString(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public string GetConnectionString()
        {

            return _configuration.GetConnectionString("DefaultConnection");
        }
    }
}
