using CleanArchitecture.Application.Guests.Commands.UpdateGuest;
using System.Threading.Tasks;
using Xunit;

namespace CleanArchitecture.WebUI.IntegrationTests.Controllers.Guests
{
    public class Update : IClassFixture<CustomWebApplicationFactory<Startup>>
    {
        private readonly CustomWebApplicationFactory<Startup> _factory;

        public Update(CustomWebApplicationFactory<Startup> factory)
        {
            _factory = factory;
        }

        [Fact]
        public async Task GivenValidUpdateGuestCommand_ReturnsSuccessCode()
        {
            var client = await _factory.GetAuthenticatedClientAsync();

            var command = new UpdateGuestCommand
            {
                Id = 1,
                FirstName = "Test FirstName Update",
                LastName = "Test LastName Update",
                Email = "Test Email Update"
            };

            var content = IntegrationTestHelper.GetRequestContent(command);

            var response = await client.PutAsync($"/api/Guest/{command.Id}", content);

            response.EnsureSuccessStatusCode();
        }
    }
}
