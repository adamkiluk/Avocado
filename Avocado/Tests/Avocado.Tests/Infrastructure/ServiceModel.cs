namespace Avocado.Tests.Infrastructure
{
    using Avocado.Application.Interfaces;
    using Avocado.Persistence;
    using Microsoft.AspNetCore.Http;
    using Microsoft.Extensions.Configuration;

    public class ServiceModel
    {
        public AvocadoDbContext Context { get; set; }
        public IConfiguration Configuration { get; set; }
        public IHttpContextAccessor HttpContextAccessor { get; set; }
        public INotificationService NotificationService { get; set; }
    }
}
