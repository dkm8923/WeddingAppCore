using CleanArchitecture.Application.WeddingDescriptions.Commands.CreateWeddingDescription;
using Shouldly;
using System.Net;
using System.Threading.Tasks;
using Xunit;


namespace CleanArchitecture.WebUI.IntegrationTests.Controllers.WeddingDescriptions
{
    public class Create : IClassFixture<CustomWebApplicationFactory<Startup>>
    {
        private readonly CustomWebApplicationFactory<Startup> _factory;

        public Create(CustomWebApplicationFactory<Startup> factory)
        {
            _factory = factory;
        }

        [Fact]
        public async Task GivenValidCreateWeddingDescriptionCommand_ReturnsSuccessCode()
        {
            var client = await _factory.GetAuthenticatedClientAsync();

            var command = new CreateWeddingDescriptionCommand
            {
                GroomDescription = "Test",
                BrideDescription = "Test",
                CeremonyDateTimeLocation = "Test",
                CeremonyDescription = "Test",
                ReceptionDateTimeLocation = "Test",
                ReceptionDescription = "Test",
            };

            var content = IntegrationTestHelper.GetRequestContent(command);

            var response = await client.PostAsync($"/api/WeddingDescription", content);

            response.EnsureSuccessStatusCode();
        }
    }
}
