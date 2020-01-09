using CleanArchitecture.Application.Common.Exceptions;
using CleanArchitecture.Application.UnitTests.Common;
using CleanArchitecture.Application.GuestBookEntries.Commands.DeleteGuestBookEntry;
using Shouldly;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace CleanArchitecture.Application.UnitTests.GuestBookEntries.Commands.DeleteGuestBookEntry
{
    public class DeleteGuestBookEntryCommandTests : CommandTestBase
    {
        [Fact]
        public async Task Handle_GivenValidId_ShouldRemovePersistedGuestBookEntry()
        {
            var command = new DeleteGuestBookEntryCommand
            {
                Id = 1
            };

            var handler = new DeleteGuestBookEntryCommand.DeleteGuestBookEntryCommandHandler(Context);

            await handler.Handle(command, CancellationToken.None);

            var entity = Context.GuestBookEntries.Find(command.Id);

            entity.ShouldBeNull();
        }

        [Fact]
        public void Handle_GivenInvalidId_ThrowsException()
        {
            var command = new DeleteGuestBookEntryCommand
            {
                Id = 99
            };

            var handler = new DeleteGuestBookEntryCommand.DeleteGuestBookEntryCommandHandler(Context);

            Should.ThrowAsync<NotFoundException>(() =>
                handler.Handle(command, CancellationToken.None));
        }
    }
}
