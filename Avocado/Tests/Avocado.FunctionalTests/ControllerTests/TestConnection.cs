namespace Avocado.FunctionalTests.ControllerTests
{
    using Avocado.FunctionalTests.Infrastructure;
    using Microsoft.AspNetCore.Mvc.Testing;
    using Microsoft.AspNetCore.TestHost;
    using System;
    using System.Net.Http;
    using System.Threading.Tasks;
    using Xunit;
    public class TestConnection : IClassFixture<CustomWebApplicationFactory<TestStartup>>
    {
        private readonly HttpClient _client;
        private readonly TestServer _server;

        public TestConnection(CustomWebApplicationFactory<TestStartup> factory)
        {
            //.WithWebHostBuilder(builder => builder.UseSolutionRelativeContentRoot("\\"))

            var clientOptions = new WebApplicationFactoryClientOptions();
            clientOptions.AllowAutoRedirect = true;
            clientOptions.BaseAddress = new Uri("http://localhost");
            clientOptions.HandleCookies = true;
            clientOptions.MaxAutomaticRedirections = 7;

            _client = factory.CreateClient();
            _server = factory.Server;
        }

        [Fact]
        public async Task Check_If_Api_Works()
        {
            var response = await _client.GetAsync("/api/test");
            response.EnsureSuccessStatusCode();
        }
    }
}
