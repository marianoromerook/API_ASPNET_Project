namespace API_RESTful_Project.Models
{
    public class User
    {
        public string? Id { get; set; } 
        public string? UserName { get; set; }
        public string? PasswordHash { get; set; }

        public string? Salt { get; set; }

        public ICollection<Postulate>? Postulates { get; set; }
    }
}
