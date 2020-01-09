using CleanArchitecture.Application.Common.Exceptions;
using CleanArchitecture.Application.UnitTests.Common;
using CleanArchitecture.Application.EmailLogs.Commands.DeleteEmailLog;
using Shouldly;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace CleanArchitecture.Application.UnitTests.EmailLogs.Commands.DeleteEmailLog
{
    public class DeleteEmailLogCommandTests : CommandTestBase
    {
        [Fact]
        public async Task Handle_GivenValidId_ShouldRemovePersistedEmailLog()
        {
            var command = new DeleteEmailLogCommand
            {
                Id = 1
            };

            var handler = new DeleteEmailLogCommand.DeleteEmailLogCommandHandler(Context);

            await handler.Handle(command, CancellationToken.None);

            var entity = Context.EmailLogs.Find(command.Id);

            entity.ShouldBeNull();
        }

        [Fact]
        public void Handle_GivenInvalidId_ThrowsException()
        {
            var command = new DeleteEmailLogCommand
            {
                Id = 99
            };

            var handler = new DeleteEmailLogCommand.DeleteEmailLogCommandHandler(Context);

            Should.ThrowAsync<NotFoundException>(() =>
                handler.Handle(command, CancellationToken.None));
        }
    }
}
