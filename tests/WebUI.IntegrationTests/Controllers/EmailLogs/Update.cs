using CleanArchitecture.Application.EmailLogs.Commands.UpdateEmailLog;
using System;
using System.Threading.Tasks;
using Xunit;

namespace CleanArchitecture.WebUI.IntegrationTests.Controllers.EmailLogs
{
    public class Update : IClassFixture<CustomWebApplicationFactory<Startup>>
    {
        private readonly CustomWebApplicationFactory<Startup> _factory;

        public Update(CustomWebApplicationFactory<Startup> factory)
        {
            _factory = factory;
        }

        [Fact]
        public async Task GivenValidUpdateEmailLogCommand_ReturnsSuccessCode()
        {
            var client = await _factory.GetAuthenticatedClientAsync();

            var command = new UpdateEmailLogCommand
            {
                Id = 1,
                EmailId = 1,
                SentDate = DateTime.Now,
                SentBy = "Unit Test Update"
            };

            var content = IntegrationTestHelper.GetRequestContent(command);

            var response = await client.PutAsync($"/api/EmailLog/{command.Id}", content);

            response.EnsureSuccessStatusCode();
        }
    }
}
