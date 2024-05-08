namespace Avocado.FunctionalTests.Infrastructure
{
    using Avocado.Domain.Entity;
    using Avocado.Domain.Enums;
    using Avocado.Persistence;
    using System;

    class ContextDataSeeding
    {
        public static void Run(ref AvocadoDbContext context)
        {
            //context.Signboards.AddRange(AddSignboardsToDatabase());

            context.SaveChanges();
        }

        //public static Signboard[] AddSignboardsToDatabase()
        //{
        //    int singboardsCount = 20;
        //    var singboards = new Signboard[singboardsCount];

        //    for (int i = 0; i < singboardsCount; i++)
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
