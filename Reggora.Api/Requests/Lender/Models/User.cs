namespace Reggora.Api.Requests.Lender.Models
{
    public class User
    {
        public string Id;
        public string Email;
        public string PhoneNumber = "";
        public string FirstName;
        public string LastName;
        public int? NmlsId = null;
        public string Created = "";
        public string Role = "";
        public User[] MatchedUsers = {};
        public bool? SupressNotifications = null;
    }
}