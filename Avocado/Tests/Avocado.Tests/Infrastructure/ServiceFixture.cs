namespace Avocado.Tests.Infrastructure
{
    using Avocado.Application.Interfaces;
    using Avocado.Persistence;
    using Microsoft.AspNetCore.Http;
    using Microsoft.Extensions.Configuration;
    using Xunit;

    public class ServiceFixture
    {
        public AvocadoDbContext Context { get; private set; }
        public IConfiguration Configuration { get; private set; }
        public IHttpContextAccessor HttpContextAccessor { get; private set; }
        public INotificationService NotificationService { get; private set; }

        public ServiceFixture()
        {
            var servicesModel = ServiceFactory.Create();

            Context = servicesModel.Context;
            Configuration = servicesModel.Configuration;
            HttpContextAccessor = servicesModel.HttpContextAccessor;
            NotificationService = servicesModel.NotificationService;
        }

        [CollectionDefinition("ServicesTestCollection")]
        public class QueryCollection : ICollectionFixture<ServiceFixture>
        {
        }
    }
}
