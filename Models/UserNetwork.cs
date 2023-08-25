namespace API_RESTful_Project.Models
{
    public class UserNetwork
    {
        public string? UserId { get; set; }
        public string? FriendId { get; set; }

        public string? UnionId { get; set; }

        public string? Content { get; set; }

        public string? Link { get; set; }

        public string? Name { get; set; }
        public FriendRequestStatus Status { get; set; }

        public int Id { get; set; }

        public enum FriendRequestStatus
        {
            Pending,
            Accepted,
            Rejected
        }
    }
}
