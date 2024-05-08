namespace Avocado.Application.Interfaces
{
    using Avocado.Domain.Entity;
    using System.Threading.Tasks;

    public interface IUserRepository : IRepository<User>
    {
        Task<User> GetUserByNameAsync(string userName);
        Task<User> GetUserByEmailAsync(string emailAddress);

    }
}
