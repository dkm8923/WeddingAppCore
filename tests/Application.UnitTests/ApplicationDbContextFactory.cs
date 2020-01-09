using CleanArchitecture.Application.Common.Interfaces;
using CleanArchitecture.Domain.Entities;
using CleanArchitecture.Infrastructure.Persistence;
using IdentityServer4.EntityFramework.Options;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Moq;
using System;

namespace CleanArchitecture.Application.UnitTests.Common
{
    public static class ApplicationDbContextFactory
    {
        public static ApplicationDbContext Create()
        {
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase(Guid.NewGuid().ToString())
                .Options;

            var operationalStoreOptions = Options.Create(
                new OperationalStoreOptions
                {
                    DeviceFlowCodes = new TableConfiguration("DeviceCodes"),
                    PersistedGrants = new TableConfiguration("PersistedGrants")
                });

            var dateTimeMock = new Mock<IDateTime>();
            dateTimeMock.Setup(m => m.Now)
                .Returns(new DateTime(3001, 1, 1));

            var currentUserServiceMock = new Mock<ICurrentUserService>();
            currentUserServiceMock.Setup(m => m.UserId)
                .Returns("00000000-0000-0000-0000-000000000000");

            var context = new ApplicationDbContext(
                options, operationalStoreOptions,
                currentUserServiceMock.Object, dateTimeMock.Object);

            context.Database.EnsureCreated();

            SeedSampleData(context);

            return context;
        }

        public static void SeedSampleData(ApplicationDbContext context)
        {
            #region Todos

            context.TodoItems.AddRange(
                new TodoItem { Id = 1, ListId = 1, Title = "Bread", Done = true },
                new TodoItem { Id = 2, ListId = 1, Title = "Butter", Done = true },
                new TodoItem { Id = 3, ListId = 1, Title = "Milk" },
                new TodoItem { Id = 4, ListId = 1, Title = "Sugar" },
                new TodoItem { Id = 5, ListId = 1, Title = "Coffee" }
            );

            #endregion

            #region TodoLists

            context.TodoLists.AddRange(
                new TodoList { Id = 1, Title = "Shopping" }
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

        public static void Destroy(ApplicationDbContext context)
        {
            context.Database.EnsureDeleted();

            context.Dispose();
        }
    }
}