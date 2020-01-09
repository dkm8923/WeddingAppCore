using CleanArchitecture.Application.Emails.Commands.UpdateEmail;
using System.Threading.Tasks;
using Xunit;

namespace CleanArchitecture.WebUI.IntegrationTests.Controllers.Emails
{
    public class Update : IClassFixture<CustomWebApplicationFactory<Startup>>
    {
        private readonly CustomWebApplicationFactory<Startup> _factory;

        public Update(CustomWebApplicationFactory<Startup> factory)
        {
            _factory = factory;
        }

        [Fact]
        public async Task GivenValidUpdateEmailCommand_ReturnsSuccessCode()
        {
            var client = await _factory.GetAuthenticatedClientAsync();

            var command = new UpdateEmailCommand
            {
                Id = 1,
                Description = "Test Description Update",
                Subject = "Test Subject Update",
                Body = "Test Body Update"
            };

            var content = IntegrationTestHelper.GetRequestContent(command);

            var response = await client.PutAsync($"/api/Email/{command.Id}", content);

            response.EnsureSuccessStatusCode();
        }
    }
}
