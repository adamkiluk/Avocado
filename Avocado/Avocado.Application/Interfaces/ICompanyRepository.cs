namespace Avocado.Application.Interfaces
{
    using Avocado.Domain.Entity;
    using System;
    using System.Threading.Tasks;

    public interface ICompanyRepository : IRepository<Company>
    {
        Task<Company> GetUserCompany(Guid? userId);
    }
}
