using CleanArchitecture.Application.Families.Commands.UpdateFamily;
using System.Threading.Tasks;
using Xunit;

namespace CleanArchitecture.WebUI.IntegrationTests.Controllers.Families
{
    public class Update : IClassFixture<CustomWebApplicationFactory<Startup>>
    {
        private readonly CustomWebApplicationFactory<Startup> _factory;

        public Update(CustomWebApplicationFactory<Startup> factory)
        {
            _factory = factory;
        }

        [Fact]
        public async Task GivenValidUpdateFamilyCommand_ReturnsSuccessCode()
        {
            var client = await _factory.GetAuthenticatedClientAsync();

            var command = new UpdateFamilyCommand
            {
                Id = 1,
                GuestId = 1,
                ConfirmationCode = "Test ConfirmationCode Update",
                Address1 = "Test Address1 Update",
                Address2 = "Test Address2 Update",
                City = "Test City Update",
                StateId = 1,
                Zip = "Test Zip Update"
            };

            var content = IntegrationTestHelper.GetRequestContent(command);

            var response = await client.PutAsync($"/api/Family/{command.Id}", content);

            response.EnsureSuccessStatusCode();
        }
    }
}
