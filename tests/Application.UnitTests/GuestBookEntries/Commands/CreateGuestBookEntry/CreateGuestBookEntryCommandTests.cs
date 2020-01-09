using Shouldly;
using System.Threading;
using System.Threading.Tasks;
using Xunit;
using CleanArchitecture.Application.UnitTests.Common;
using CleanArchitecture.Application.GuestBookEntries.Commands.CreateGuestBookEntry;

namespace CleanArchitecture.Application.UnitTests.GuestBookEntries.Commands.CreateGuestBookEntry
{
    public class CreateGuestBookEntryCommandTests : CommandTestBase
    {
        [Fact]
        public async Task Handle_ShouldPersistGuestBookEntry()
        {
            var command = new CreateGuestBookEntryCommand
            {
                Name = "Test Name",
                Entry = "Test Entry"
            };

            var handler = new CreateGuestBookEntryCommand.CreateGuestBookEntryCommandHandler(Context);

            var result = await handler.Handle(command, CancellationToken.None);

            var entity = Context.GuestBookEntries.Find(result);

            entity.ShouldNotBeNull();
            entity.Name.ShouldBe(command.Name);
            entity.Entry.ShouldBe(command.Entry);
        }
    }
}
