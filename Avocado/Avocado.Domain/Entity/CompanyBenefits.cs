namespace Avocado.Domain.Entity
{
    using System;

    public class CompanyBenefits
    {
        public int Id { get; set; }
        public Guid CompanyId { get; set; }
        public string Benefit { get; set; }
    }
}
