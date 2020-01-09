using CleanArchitecture.Application.UsaStates.Commands.UpdateUsaState;
using System.Threading.Tasks;
using Xunit;

namespace CleanArchitecture.WebUI.IntegrationTests.Controllers.UsaStates
{
    public class Update : IClassFixture<CustomWebApplicationFactory<Startup>>
    {
        private readonly CustomWebApplicationFactory<Startup> _factory;

        public Update(CustomWebApplicationFactory<Startup> factory)
        {
            _factory = factory;
        }

        [Fact]
        public async Task GivenValidUpdateUsaStateCommand_ReturnsSuccessCode()
        {
            var client = await _factory.GetAuthenticatedClientAsync();

            var command = new UpdateUsaStateCommand
            {
                Id = 1,
                Name = "Test Name Update",
                AbbreviatedName = "Test AbbreviatedName Update"
            };

            var content = IntegrationTestHelper.GetRequestContent(command);

            var response = await client.PutAsync($"/api/UsaState/{command.Id}", content);

            response.EnsureSuccessStatusCode();
        }
    }
}
