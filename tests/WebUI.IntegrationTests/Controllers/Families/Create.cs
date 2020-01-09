using CleanArchitecture.Application.Families.Commands.CreateFamily;
using System.Threading.Tasks;
using Xunit;

namespace CleanArchitecture.WebUI.IntegrationTests.Controllers.Families
{
    public class Create : IClassFixture<CustomWebApplicationFactory<Startup>>
    {
        private readonly CustomWebApplicationFactory<Startup> _factory;

        public Create(CustomWebApplicationFactory<Startup> factory)
        {
            _factory = factory;
        }

        [Fact]
        public async Task GivenValidCreateFamilyCommand_ReturnsSuccessCode()
        {
            var client = await _factory.GetAuthenticatedClientAsync();

            var command = new CreateFamilyCommand
            {
                GuestId = 1,
                ConfirmationCode = "Test ConfirmationCode",
                Address1 = "Test Address1",
                Address2 = "Test Address2",
                City = "Test City",
                StateId = 1,
                Zip = "Test Zip"
            };

            var content = IntegrationTestHelper.GetRequestContent(command);

            var response = await client.PostAsync($"/api/Family", content);

            response.EnsureSuccessStatusCode();
        }
    }
}