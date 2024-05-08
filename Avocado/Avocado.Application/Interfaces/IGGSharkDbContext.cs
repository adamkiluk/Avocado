using Avocado.Domain.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System.Threading;
using System.Threading.Tasks;

namespace Avocado.Application.Interfaces
{
    public interface IAvocadoDbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Signboard> Signboards { get; set; }
        public DbSet<Company> Companies { get; set; }
        public DbSet<CompanyPerks> Perks { get; set; }
        public DbSet<CompanyBenefits> Benefits { get; set; }
        public DbSet<CompanyTechnologies> Technologies { get; set; }

        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
        DbSet<TEntity> Set<TEntity>() where TEntity : class;
        EntityEntry<TEntity> Entry<TEntity>(TEntity entity) where TEntity : class;
    }
}
