namespace API_RESTful_Project.Services
{
    public class PasswordService
    {
        public string HashPassword(string password)
        {
            return BCrypt.Net.BCrypt.HashPassword(password);
        }

        public bool VerifyPassword(string password, string passwordHash, string salt)
        {
            string passwordWithSalt = password + salt;
            return BCrypt.Net.BCrypt.Verify(passwordWithSalt, passwordHash);
        }
    }
}
