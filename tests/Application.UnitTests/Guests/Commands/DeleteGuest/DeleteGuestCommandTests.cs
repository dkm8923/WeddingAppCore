using CleanArchitecture.Application.Common.Exceptions;
using CleanArchitecture.Application.UnitTests.Common;
using CleanArchitecture.Application.Guests.Commands.DeleteGuest;
using Shouldly;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace CleanArchitecture.Application.UnitTests.Guests.Commands.DeleteGuest
{
    public class DeleteGuestCommandTests : CommandTestBase
    {
        [Fact]
        public async Task Handle_GivenValidId_ShouldRemovePersistedGuest()
        {
            var command = new DeleteGuestCommand
            {
                Id = 1
            };

            var handler = new DeleteGuestCommand.DeleteGuestCommandHandler(Context);

            await handler.Handle(command, CancellationToken.None);

            var entity = Context.Guests.Find(command.Id);

            entity.ShouldBeNull();
        }

        [Fact]
        public void Handle_GivenInvalidId_ThrowsException()
        {
            var command = new DeleteGuestCommand
            {
                Id = 99
            };

            var handler = new DeleteGuestCommand.DeleteGuestCommandHandler(Context);

            Should.ThrowAsync<NotFoundException>(() =>
                handler.Handle(command, CancellationToken.None));
        }
    }
}
