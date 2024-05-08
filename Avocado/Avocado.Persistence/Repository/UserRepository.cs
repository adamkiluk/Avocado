namespace Avocado.Persistence.Repository
{
    using Avocado.Application.Interfaces;
    using Avocado.Domain.Entity;
    using Microsoft.EntityFrameworkCore;
    using System;
    using System.Threading.Tasks;

    public class UserRepository : Repository<User>, IUserRepository
    {
        public UserRepository(AvocadoDbContext context) : base(context)
        {

        }

        public async Task<User> GetUserByNameAsync(string userName)
        {
            return await base._context.Users.FirstOrDefaultAsync(u => u.UserName.Equals(userName));
        }

        public async Task<User> GetUserByEmailAsync(string emailAddress)
        {
            return await base._context.Users.FirstOrDefaultAsync(u => u.Email.Equals(emailAddress));
        }

        public async Task<User> GetUserByIdAsync(Guid userId)
        {
            return await base._context.Users.FirstOrDefaultAsync(u => u.UserId.Equals(userId));
        }
    }
}
