using CleanArchitecture.Application.Common.Exceptions;
using CleanArchitecture.Application.UnitTests.Common;
using CleanArchitecture.Application.Guests.Commands.UpdateGuest;
using Shouldly;
using System;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace CleanArchitecture.Application.UnitTests.Guests.Commands.UpdateGuest
{
    public class UpdateGuestCommandTests : CommandTestBase
    {
        [Fact]
        public async Task Handle_GivenValidId_ShouldUpdatePersistedGuest()
        {
            var command = new UpdateGuestCommand
            {
                Id = 1,
                FirstName = "Test FirstName Update",
                LastName = "Test LastName Update",
                Email = "Test Email Update"
            };

            var handler = new UpdateGuestCommand.UpdateGuestCommandHandler(Context);

            await handler.Handle(command, CancellationToken.None);

            var entity = Context.Guests.Find(command.Id);

            entity.ShouldNotBeNull();
            entity.FirstName.ShouldBe(command.FirstName);
            entity.LastName.ShouldBe(command.LastName);
            entity.Email.ShouldBe(command.Email);
        }

        [Fact]
        public void Handle_GivenInvalidId_ThrowsException()
        {
            var command = new UpdateGuestCommand
            {
                Id = 99,
                FirstName = "Test FirstName Update",
                LastName = "Test LastName Update",
                Email = "Test Email Update"
            };

            var handler = new UpdateGuestCommand.UpdateGuestCommandHandler(Context);

            Should.ThrowAsync<NotFoundException>(() =>
                handler.Handle(command, CancellationToken.None));
        }
    }
}
