using CleanArchitecture.Application.Common.Exceptions;
using CleanArchitecture.Application.UnitTests.Common;
using CleanArchitecture.Application.GuestBookEntries.Commands.UpdateGuestBookEntry;
using Shouldly;
using System.Threading;
using System.Threading.Tasks;
using Xunit;
namespace CleanArchitecture.Application.UnitTests.GuestBookEntries.Commands.UpdateGuestBookEntry
{
    public class UpdateGuestBookEntryCommandTests : CommandTestBase
    {
        [Fact]
        public async Task Handle_GivenValidId_ShouldUpdatePersistedGuestBookEntry()
        {
            var command = new UpdateGuestBookEntryCommand
            {
                Id = 1,
                Name = "Test Name Update",
                Entry = "Test Entry Update"
            };

            var handler = new UpdateGuestBookEntryCommand.UpdateGuestBookEntryCommandHandler(Context);

            await handler.Handle(command, CancellationToken.None);

            var entity = Context.GuestBookEntries.Find(command.Id);

            entity.ShouldNotBeNull();
            entity.Name.ShouldBe(command.Name);
            entity.Entry.ShouldBe(command.Entry);
        }

        [Fact]
        public void Handle_GivenInvalidId_ThrowsException()
        {
            var command = new UpdateGuestBookEntryCommand
            {
                Id = 99,
                Name = "Test Name Update",
                Entry = "Test Entry Update"
            };

            var handler = new UpdateGuestBookEntryCommand.UpdateGuestBookEntryCommandHandler(Context);

            Should.ThrowAsync<NotFoundException>(() =>
                handler.Handle(command, CancellationToken.None));
        }
    }
}
