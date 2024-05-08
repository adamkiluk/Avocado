namespace Avocado.FunctionalTests.ControllerTests
{
    using Avocado.Application.Extensions;
    using Avocado.Application.Signboards.Query.GetAllUserSignboards;
    using Avocado.FunctionalTests.Infrastructure;
    using Microsoft.AspNetCore.TestHost;
    using Shouldly;
    using System.Net.Http;
    using System.Threading.Tasks;
    using Xunit;

    public class SignboardControllerTest : IClassFixture<CustomWebApplicationFactory<TestStartup>>
    {
        private readonly HttpClient _client;

        public SignboardControllerTest(CustomWebApplicationFactory<TestStartup> factory)
        {
            _client = factory
                .WithWebHostBuilder(builder => builder.UseSolutionRelativeContentRoot("relative/path/of/project/under/test"))
                .CreateClient();
        }

        [Fact]
        public async Task Server_Should_Return_Signboard_List()
        {
            var response = await _client.GetAsync("/api/Signboard");

            string json = await response.Content.ReadAsStringAsync();
            var signboard = json.DeserializeObjectFromJson<SignboardModel>();

            response.EnsureSuccessStatusCode();
            signboard.ShouldBeOfType<SignboardModel>();
            signboard.AllSignboards.ShouldNotBeEmpty();
        }
    }
}
