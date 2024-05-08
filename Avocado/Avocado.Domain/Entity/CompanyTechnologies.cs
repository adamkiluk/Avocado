namespace Avocado.Domain.Entity
{
    using System;
    
    public class CompanyTechnologies
    {
        public int Id { get; set; }
        public Guid CompanyId { get; set; }
        public string Technology { get; set; }
    }
}
