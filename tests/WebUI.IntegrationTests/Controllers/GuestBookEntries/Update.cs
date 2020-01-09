using CleanArchitecture.Application.GuestBookEntries.Commands.UpdateGuestBookEntry;
using System.Threading.Tasks;
using Xunit;

namespace CleanArchitecture.WebUI.IntegrationTests.Controllers.GuestBookEntries
{
    public class Update : IClassFixture<CustomWebApplicationFactory<Startup>>
    {
        private readonly CustomWebApplicationFactory<Startup> _factory;

        public Update(CustomWebApplicationFactory<Startup> factory)
        {
            _factory = factory;
        }

        [Fact]
        public async Task GivenValidUpdateGuestBookEntryCommand_ReturnsSuccessCode()
        {
            var client = await _factory.GetAuthenticatedClientAsync();

            var command = new UpdateGuestBookEntryCommand
            {
                Id = 1,
                Name = "Test Name Update",
                Entry = "Test Entry Update"
            };

            var content = IntegrationTestHelper.GetRequestContent(command);

            var response = await client.PutAsync($"/api/GuestBookEntry/{command.Id}", content);

            response.EnsureSuccessStatusCode();
        }
    }
}
