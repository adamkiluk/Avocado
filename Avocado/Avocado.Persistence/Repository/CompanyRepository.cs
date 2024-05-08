namespace Avocado.Persistence.Repository
{
    using Avocado.Application.Interfaces;
    using Avocado.Domain.Entity;
    using Microsoft.EntityFrameworkCore;
    using System;
    using System.Linq;
    using System.Threading.Tasks;

    public class CompanyRepository : Repository<Company>, ICompanyRepository
    {
        public CompanyRepository(AvocadoDbContext context) : base(context)
        {

        }

        public async Task<Company> GetUserCompany(Guid? companyId)
        {
            return await base._context.Companies.FirstOrDefaultAsync(x => x.CompanyId.Equals(companyId));
        }
    }
}
