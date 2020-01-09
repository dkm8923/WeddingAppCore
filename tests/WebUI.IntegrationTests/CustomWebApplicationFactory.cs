using CleanArchitecture.Application;
using CleanArchitecture.Application.Common.Interfaces;
using CleanArchitecture.Domain.Entities;
using CleanArchitecture.Infrastructure.Persistence;
using IdentityModel.Client;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace CleanArchitecture.WebUI.IntegrationTests
{
    public class CustomWebApplicationFactory<TStartup> : WebApplicationFactory<TStartup> where TStartup : class
    {
        protected override void ConfigureWebHost(IWebHostBuilder builder)
        {
            builder
                .ConfigureServices(services =>
                {
                    // Create a new service provider.
                    var serviceProvider = new ServiceCollection()
                        .AddEntityFrameworkInMemoryDatabase()
                        .BuildServiceProvider();

                    // Add a database context using an in-memory 
                    // database for testing.
                    services.AddDbContext<ApplicationDbContext>(options =>
                    {
                        options.UseInMemoryDatabase("InMemoryDbForTesting");
                        options.UseInternalServiceProvider(serviceProvider);
                    });

                    services.AddScoped<IApplicationDbContext>(provider => provider.GetService<ApplicationDbContext>());

                    services.AddScoped<ICurrentUserService, TestCurrentUserService>();
                    services.AddScoped<IDateTime, TestDateTimeService>();
                    services.AddScoped<IIdentityService, TestIdentityService>();

                    var sp = services.BuildServiceProvider();

                    // Create a scope to obtain a reference to the database
                    using var scope = sp.CreateScope();
                    var scopedServices = scope.ServiceProvider;
                    var context = scopedServices.GetRequiredService<ApplicationDbContext>();
                    var logger = scopedServices.GetRequiredService<ILogger<CustomWebApplicationFactory<TStartup>>>();

                    // Ensure the database is created.
                    context.Database.EnsureCreated();

                    try
                    {
                        SeedSampleData(context);
                    }
                    catch (Exception ex)
                    {
                        logger.LogError(ex, $"An error occurred seeding the database with sample data. Error: {ex.Message}.");
                    }
                })
                .UseEnvironment("Test");
        }

        public HttpClient GetAnonymousClient()
        {
            return CreateClient();
        }

        public async Task<HttpClient> GetAuthenticatedClientAsync()
        {
            return await GetAuthenticatedClientAsync("jason@clean-architecture", "CleanArchitecture!");
        }

        public async Task<HttpClient> GetAuthenticatedClientAsync(string userName, string password)
        {
            var client = CreateClient();

            var token = await GetAccessTokenAsync(client, userName, password);

            client.SetBearerToken(token);

            return client;
        }

        private async Task<string> GetAccessTokenAsync(HttpClient client, string userName, string password)
        {
            var disco = await client.GetDiscoveryDocumentAsync();

            if (disco.IsError)
            {
                throw new Exception(disco.Error);
            }

            var response = await client.RequestPasswordTokenAsync(new PasswordTokenRequest
            {
                Address = disco.TokenEndpoint,
                ClientId = "CleanArchitecture.IntegrationTests",
                ClientSecret = "secret",

                Scope = "CleanArchitecture.WebUIAPI openid profile",
                UserName = userName,
                Password = password
            });

            if (response.IsError)
            {
                throw new Exception(response.Error);
            }

            return response.AccessToken;
        }

        public static void SeedSampleData(ApplicationDbContext context)
        {
            #region Todos

            context.TodoItems.AddRange(
                new TodoItem { Id = 1, Title = "Do this thing." },
                new TodoItem { Id = 2, Title = "Do this thing too." },
                new TodoItem { Id = 3, Title = "Do many, many things." },
                new TodoItem { Id = 4, Title = "This thing is done!", Done = true }
            );

            #endregion

            #region WeddingDescriptions

            context.WeddingDescriptions.AddRange(
                new WeddingDescription
                {
                    Id = 1,
                    BrideDescription = "Test Bride Desc 1",
                    GroomDescription = "Test Groom Desc 1",
                    CeremonyDateTimeLocation = "Test CeremonyDateTimeLocation 1",
                    CeremonyDescription = "Test CeremonyDescription 1",
                    ReceptionDateTimeLocation = "Test ReceptionDateTimeLocation 1",
                    ReceptionDescription = "Test ReceptionDescription 1",
                    Created = DateTime.Now,
                    CreatedBy = "UnitTest",
                    LastModified = DateTime.Now,
                    LastModifiedBy = "UnitTest"
                },
                new WeddingDescription
                {
                    Id = 2,
                    BrideDescription = "Test Bride Desc 2",
                    GroomDescription = "Test Groom Desc 2",
                    CeremonyDateTimeLocation = "Test CeremonyDateTimeLocation 2",
                    CeremonyDescription = "Test CeremonyDescription 2",
                    ReceptionDateTimeLocation = "Test ReceptionDateTimeLocation 2",
                    ReceptionDescription = "Test ReceptionDescription 2",
                    Created = DateTime.Now,
                    CreatedBy = "UnitTest",
                    LastModified = DateTime.Now,
                    LastModifiedBy = "UnitTest"
                }
            );

            #endregion

            #region Emails

            context.Emails.AddRange(
                new Email { Id = 1, Description = "Test Description", Subject = "Test Subject", Body = "Test Body" }
            );

            #endregion

            #region EmailLogs

            context.EmailLogs.AddRange(
                new EmailLog { Id = 1, EmailId = 1, SentDate = new DateTime(), SentBy = "Test SentBy" }
            );

            #endregion

            #region GuestBookEntries

            context.GuestBookEntries.AddRange(
                new GuestBookEntry { Id = 1, Name = "Test Name", Entry = "Test Entry", Approved = true, ApprovedOn = DateTime.Now }
            );

            #endregion

            #region Guests

            context.Guests.AddRange(
                new Guest { Id = 1, FirstName = "Test FirstName", LastName = "Test LastName", Email = "Test Email" }
            );

            #endregion

            #region Families

            context.Families.AddRange(
                new Family { Id = 1, GuestId = 1, ConfirmationCode = "Test ConfirmationCode", Address1 = "Test Address1", Address2 = "Test Address2", City = "Test City", StateId = 1, Zip = "Test Zip" }
            );

            #endregion

            #region UsaState

            context.UsaStates.AddRange(
                new UsaState { Id = 1, Name = "Test Name", AbbreviatedName = "Test AbbreviatedName" }
            );

            #endregion

            context.SaveChanges();
        }
    }
}
