namespace Avocado.Tests.Infrastructure
{
    using Avocado.Domain.Entity;
    using Avocado.Domain.Enums;
    using Avocado.Persistence;
    using Microsoft.EntityFrameworkCore;
    using System;

    public class DatabaseContextFactory
    {
        public static AvocadoDbContext Create()
        {
            var options = new DbContextOptionsBuilder<AvocadoDbContext>()
                               .UseInMemoryDatabase(Guid.NewGuid().ToString())
                               .EnableSensitiveDataLogging(true)
                               .Options;

            var context = new AvocadoDbContext(options);

            //context.Signboards.AddRange(AddSingboardsToDatabase());

            context.SaveChanges();

            return context;
        }

        public static void Destroy(AvocadoDbContext context)
        {
            context.Database.EnsureDeleted();
            context.Dispose();
        }

        //private static Signboard[] AddSingboardsToDatabase()
        //{
        //    int singboardsCount = 20;
        //    var singboards = new Signboard[singboardsCount];
            
        //    for(int i = 0; i < singboardsCount; i++)
        //    {
        //        singboards[i] = new Signboard
        //        {
        //            UserId = Guid.NewGuid(),
        //            CompanyId = Guid.NewGuid(),
        //            CompanyName = $"Company_nr{i}",
        //            MustHave = $".Net, C#, React, {i}",
        //            NiceToHave = $"Angular, Docker, NodeJs, {i}",
        //            SalaryRange = $"{i}00 - {i + 2}00",
        //            Categories = $"{i}",
        //            Seniority = SingboardSeniorityLevel.Expert

        //        };
        //    }

        //    return singboards;
        //}
    }
}
