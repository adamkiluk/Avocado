namespace Avocado.Persistence
{
    using Microsoft.EntityFrameworkCore;
    using Avocado.Persistence.Infrastructure;

    public class AvocadoDbContextFactory : DesignTimeDbContextFactoryBase<AvocadoDbContext>
    {
        protected override AvocadoDbContext CreateNewInstance(DbContextOptions<AvocadoDbContext> options)
        {
            return new AvocadoDbContext(options);
        }
    }
}
