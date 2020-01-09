using CleanArchitecture.Application.UsaStates.Commands.CreateUsaState;
using System.Threading.Tasks;
using Xunit;

namespace CleanArchitecture.WebUI.IntegrationTests.Controllers.UsaStates
{
    public class Create : IClassFixture<CustomWebApplicationFactory<Startup>>
    {
        private readonly CustomWebApplicationFactory<Startup> _factory;

        public Create(CustomWebApplicationFactory<Startup> factory)
        {
            _factory = factory;
        }

        [Fact]
        public async Task GivenValidCreateUsaStateCommand_ReturnsSuccessCode()
        {
            var client = await _factory.GetAuthenticatedClientAsync();

            var command = new CreateUsaStateCommand
            {
                Name = "Test Name",
                AbbreviatedName = "Test AbbreviatedName"
            };

            var content = IntegrationTestHelper.GetRequestContent(command);

            var response = await client.PostAsync($"/api/UsaState", content);

            response.EnsureSuccessStatusCode();
        }
    }
}