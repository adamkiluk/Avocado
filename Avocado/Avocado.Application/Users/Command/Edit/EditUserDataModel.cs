namespace Avocado.Application.Users.Command.Edit
{
    public class EditUserDTO
    {
        public string Token { get; set; }
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
