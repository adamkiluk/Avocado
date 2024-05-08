namespace Avocado.Domain.Entity
{
    using System;
    using System.Collections.Generic;

    public class Company
    {
        public Guid CompanyId { get; set; } = Guid.NewGuid();

        public string Name { get; set; }
        public string AboutPart1 { get; set; }
        public string AboutPart2 { get; set; }
        public DateTime FoundedIn { get; set; }
        public string Location { get; set; }
        public int CompanySize { get; set; }
        public string Url { get; set; }
        public string Facebook { get; set; }
        public string LinkedIn { get; set; }


        public List<CompanyPerks> Perks { get; set; }
        public List<CompanyBenefits> Benefits { get; set; }
        public List<CompanyTechnologies> Technologies { get; set; }

        public ICollection<User> Employees { get; set; }
        public ICollection<Signboard> CompanySignboards { get; set; }
    }
}
