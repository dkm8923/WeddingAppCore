﻿using Shouldly;
using System.Net;
using System.Threading.Tasks;
using Xunit;

namespace CleanArchitecture.WebUI.IntegrationTests.Controllers.UsaStates
{
    public class Delete : IClassFixture<CustomWebApplicationFactory<Startup>>
    {
        private readonly CustomWebApplicationFactory<Startup> _factory;

        public Delete(CustomWebApplicationFactory<Startup> factory)
        {
            _factory = factory;
        }

        [Fact]
        public async Task GivenValidId_ReturnsSuccessStatusCode()
        {
            var validId = 1;

            var client = await _factory.GetAuthenticatedClientAsync();

            var response = await client.DeleteAsync($"/api/UsaState/{validId}");

            response.EnsureSuccessStatusCode();
        }

        [Fact]
        public async Task GivenInvalidId_ReturnsNotFound()
        {
            var invalidId = 99;

            var client = await _factory.GetAuthenticatedClientAsync();

            var response = await client.DeleteAsync($"/api/UsaState/{invalidId}");

            response.StatusCode.ShouldBe(HttpStatusCode.NotFound);
        }
    }
}