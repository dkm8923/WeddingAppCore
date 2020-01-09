using Shouldly;
using System.Threading;
using System.Threading.Tasks;
using Xunit;
using CleanArchitecture.Application.UnitTests.Common;
using CleanArchitecture.Application.Guests.Commands.CreateGuest;
using System;

namespace CleanArchitecture.Application.UnitTests.Guests.Commands.CreateGuest
{
    public class CreateGuestCommandTests : CommandTestBase
    {
        [Fact]
        public async Task Handle_ShouldPersistGuest()
        {
            var command = new CreateGuestCommand
            {
                FirstName = "Test FirstName",
                LastName = "Test LastName",
                Email = "Test Email"
            };

            var handler = new CreateGuestCommand.CreateGuestCommandHandler(Context);

            var result = await handler.Handle(command, CancellationToken.None);

            var entity = Context.Guests.Find(result);

            entity.ShouldNotBeNull();
            entity.FirstName.ShouldBe(command.FirstName);
            entity.LastName.ShouldBe(command.LastName);
            entity.Email.ShouldBe(command.Email);
        }
    }
}
