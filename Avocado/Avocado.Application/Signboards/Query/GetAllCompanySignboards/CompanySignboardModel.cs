namespace Avocado.Application.Signboards.Query.GetAllCompanySignboards
{
    using Avocado.Domain.Entity;
    using System.Collections.Generic;

    public class CompanySignboardModel
    {
        public List<Signboard> AllCompanySignboards { get; set; }
    }
}
