namespace API_RESTful_Project.Exceptions
{
    public class BadRequestException: Exception
    {
        public BadRequestException(string message) : base(message)
        {
        }
    }
}
