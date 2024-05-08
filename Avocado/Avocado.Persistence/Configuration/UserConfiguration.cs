namespace Avocado.Persistence.Configuration
{
    using Avocado.Domain.Entity;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    public class UserConfiguration : IEntityTypeConfiguration<Signboard>
    {
        public void Configure(EntityTypeBuilder<Signboard> builder)
        {
            builder.HasOne(m => m.User)
                   .WithMany(n => n.Signboards)
                   .OnDelete(DeleteBehavior.Cascade);

        }
    }
}
