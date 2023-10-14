using System.Runtime.Serialization;

namespace API_RESTful_Project.Models
{
    [Serializable]
    internal class StoreNotFoundException : Exception
    {
        public StoreNotFoundException()
        {
        }

        public StoreNotFoundException(string? message) : base(message)
        {
        }

        public StoreNotFoundException(string? message, Exception? innerException) : base(message, innerException)
        {
        }

        protected StoreNotFoundException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}