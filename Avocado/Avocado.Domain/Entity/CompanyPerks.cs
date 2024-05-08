namespace Avocado.Domain.Entity
{
    using System;
    
    public class CompanyPerks
    {
        public int Id { get; set; }
        public Guid CompanyId { get; set; }
        public string Perk { get; set; }
    }
}
