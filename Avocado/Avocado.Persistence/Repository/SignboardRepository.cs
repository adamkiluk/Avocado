namespace Avocado.Persistence.Repository
{
    using Avocado.Application.Interfaces;
    using Avocado.Domain.Entity;
    using Microsoft.EntityFrameworkCore;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    public class SignboardRepository : Repository<Signboard>, ISignboardRepository
    {
        public SignboardRepository(AvocadoDbContext context) : base(context)
        {

        }

        public async Task<List<Signboard>> GetAllUserSignboardsAsync(Guid userId)
        {
            return await base._context.Signboards.Where(x => x.UserId == userId).ToListAsync();
        }

        public async Task<List<Signboard>> GetAllCompanySignboardsAsync(Guid companyId)
        {
            return await base._context.Signboards.Where(x => x.CompanyId == companyId).ToListAsync();
        }
    }
}
