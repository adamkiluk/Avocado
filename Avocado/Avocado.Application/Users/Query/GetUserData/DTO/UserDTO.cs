namespace Avocado.Application.Users.Query.GetUserData.DTO
{
    public class UserDTO
    {
        public string Email { get; set; }
        public string Name { get; set; }
        public string PhoneNumber { get; set; }
        public string Repository { get; set; }
        public string Website { get; set; }
        public string Facebook { get; set; }
        public string Linkedin { get; set; }
        public bool TermsAndPolicy { get; set; }
        public bool NewsletterSub { get; set; }
    }
}
