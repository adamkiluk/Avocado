namespace Avocado.Tests.Infrastructure
{
    using Avocado.Application.Interfaces;
    using Microsoft.AspNetCore.Http;
    using Microsoft.Extensions.Configuration;
    using Moq;
    using System;

    public class ServiceFactory
    {
        public static ServiceModel Create()
        {
            var configuration = CreateConfiguration();

            var context = DatabaseContextFactory.Create();

            var notification = new Mock<INotificationService>();

            var httpContextAccessorMock = new Mock<IHttpContextAccessor>();
            httpContextAccessorMock.Setup(x => x.HttpContext.Request.Scheme).Returns("NotEmpty");

            return new ServiceModel
            {
                Context = context,
                Configuration = configuration,
                HttpContextAccessor = httpContextAccessorMock.Object,
                NotificationService = notification.Object
            };
        }

        private static IConfiguration CreateConfiguration()
        {
            string AspNetCoreEnvironment = "ASPNETCORE_ENVIRONMENT";
            var basePath = AppContext.BaseDirectory.Substring(0, AppContext.BaseDirectory.IndexOf("Tests"));
            basePath += "Api\\Avocado.Api\\";

            var configurationBuilder = new ConfigurationBuilder()
                .SetBasePath(basePath)
                .AddJsonFile("appsettings.json")
                .AddJsonFile($"appsettings.Local.json", optional: true)
                .AddJsonFile($"appsettings.{AspNetCoreEnvironment}.json", optional: true)
                .AddEnvironmentVariables();

            return configurationBuilder.Build();
        }
    }
}
