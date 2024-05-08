namespace Avocado.Application.Authentication.Model
{
    using System;

    public class JwtTokenModel
    {
        public string Token { get; set; }
        public DateTime ValidTo { get; set; }
        public string Email { get; set; }
        public string Status { get; set; }
    }
}
