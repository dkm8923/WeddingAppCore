using CleanArchitecture.Application.WeddingDescriptions.Commands.UpdateWeddingDescription;
using System.Threading.Tasks;
using Xunit;


namespace CleanArchitecture.WebUI.IntegrationTests.Controllers.WeddingDescriptions
{
    public class Update : IClassFixture<CustomWebApplicationFactory<Startup>>
    {
        private readonly CustomWebApplicationFactory<Startup> _factory;

        public Update(CustomWebApplicationFactory<Startup> factory)
        {
            _factory = factory;
        }

        [Fact]
        public async Task GivenValidUpdateWeddingDescriptionCommand_ReturnsSuccessCode()
        {
            var client = await _factory.GetAuthenticatedClientAsync();

            var command = new UpdateWeddingDescriptionCommand
            {
                Id = 1,
                GroomDescription = "Test Update",
                BrideDescription = "Test Update",
                CeremonyDateTimeLocation = "Test Update",
                CeremonyDescription = "Test Update",
                ReceptionDateTimeLocation = "Test Update",
                ReceptionDescription = "Test Update",
            };

            var content = IntegrationTestHelper.GetRequestContent(command);

            var response = await client.PutAsync($"/api/WeddingDescription/{command.Id}", content);

            response.EnsureSuccessStatusCode();
        }
    }
}
