namespace Avocado.Application.Interfaces
{
    using Avocado.Domain.Entity;
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public interface ISignboardRepository : IRepository<Signboard>
    {
        Task<List<Signboard>> GetAllUserSignboardsAsync(Guid UserId);
        Task<List<Signboard>> GetAllCompanySignboardsAsync(Guid CompanyId);
    }
}
