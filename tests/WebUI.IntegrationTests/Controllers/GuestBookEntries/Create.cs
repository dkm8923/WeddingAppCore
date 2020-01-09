using CleanArchitecture.Application.GuestBookEntries.Commands.CreateGuestBookEntry;
using System.Threading.Tasks;
using Xunit;

namespace CleanArchitecture.WebUI.IntegrationTests.Controllers.GuestBookEntries
{
    public class Create : IClassFixture<CustomWebApplicationFactory<Startup>>
    {
        private readonly CustomWebApplicationFactory<Startup> _factory;

        public Create(CustomWebApplicationFactory<Startup> factory)
        {
            _factory = factory;
        }

        [Fact]
        public async Task GivenValidCreateGuestBookEntryCommand_ReturnsSuccessCode()
        {
            var client = await _factory.GetAuthenticatedClientAsync();

            var command = new CreateGuestBookEntryCommand
            {
                Name = "Test Name",
                Entry = "Test Entry"
            };

            var content = IntegrationTestHelper.GetRequestContent(command);

            var response = await client.PostAsync($"/api/GuestBookEntry", content);

            response.EnsureSuccessStatusCode();
        }
    }
}