using CleanArchitecture.Application.EmailLogs.Commands.CreateEmailLog;
using System;
using System.Threading.Tasks;
using Xunit;

namespace CleanArchitecture.WebUI.IntegrationTests.Controllers.EmailLogs
{
    public class Create : IClassFixture<CustomWebApplicationFactory<Startup>>
    {
        private readonly CustomWebApplicationFactory<Startup> _factory;

        public Create(CustomWebApplicationFactory<Startup> factory)
        {
            _factory = factory;
        }

        [Fact]
        public async Task GivenValidCreateEmailLogCommand_ReturnsSuccessCode()
        {
            var client = await _factory.GetAuthenticatedClientAsync();

            var command = new CreateEmailLogCommand
            {
                EmailId = 1,
                SentDate = DateTime.Now,
                SentBy = "Unit Test"
            };

            var content = IntegrationTestHelper.GetRequestContent(command);

            var response = await client.PostAsync($"/api/EmailLog", content);

            response.EnsureSuccessStatusCode();
        }
    }
}