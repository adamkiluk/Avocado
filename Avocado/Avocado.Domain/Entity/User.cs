namespace Avocado.Domain.Entity
{
    using System;
    using System.Collections.Generic;

    public class User
    {
        public Guid UserId { get; set; } = Guid.NewGuid();
        public Guid? CompanyId { get; set; }

        public string UserName { get; set; }
        public string Password { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string Repository { get; set; }
        public string Website { get; set; }
        public string Facebook { get; set; }
        public string Linkedin { get; set; }


        public bool TermsAndPolicy { get; set; }
        public bool NewsletterSub{ get; set; }

        public ICollection<Signboard> Signboards { get; set; }
        public virtual Company UserCompany { get; set; }
    }
}
