namespace Avocado.Persistence
{
    using Avocado.Application.Interfaces;
    using Avocado.Domain.Entity;
    using Microsoft.EntityFrameworkCore;
    using Newtonsoft.Json;
    using System;
    using System.Collections.Generic;

    public class AvocadoDbContext : DbContext, IAvocadoDbContext
    {
        public AvocadoDbContext(DbContextOptions<AvocadoDbContext> options)
            : base(options)
        {

        }
        public DbSet<User> Users {get; set;}
        public DbSet<Signboard> Signboards { get; set; }
        public DbSet<Company> Companies { get; set; }
        public DbSet<CompanyPerks> Perks { get; set; }
        public DbSet<CompanyBenefits> Benefits { get; set; }
        public DbSet<CompanyTechnologies> Technologies { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(AvocadoDbContext).Assembly);

            modelBuilder.Entity<Signboard>().Property(p => p.SeniorityLevel)
            .HasConversion(
                v => JsonConvert.SerializeObject(v),
                v => JsonConvert.DeserializeObject<List<string>>(v));

            modelBuilder.Entity<Signboard>().Property(p => p.MustHave)
            .HasConversion(
                v => JsonConvert.SerializeObject(v),
                v => JsonConvert.DeserializeObject<List<string>>(v));

            modelBuilder.Entity<Signboard>().Property(p => p.NiceToHave)
            .HasConversion(
                v => JsonConvert.SerializeObject(v),
                v => JsonConvert.DeserializeObject<List<string>>(v));

            modelBuilder.Entity<Signboard>().Property(p => p.DailyTasks)
            .HasConversion(
                v => JsonConvert.SerializeObject(v),
                v => JsonConvert.DeserializeObject<List<string>>(v));
        }
    }
}
