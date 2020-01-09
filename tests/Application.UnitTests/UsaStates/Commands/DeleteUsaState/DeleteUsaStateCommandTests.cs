using CleanArchitecture.Application.Common.Exceptions;
using CleanArchitecture.Application.UnitTests.Common;
using CleanArchitecture.Application.UsaStates.Commands.DeleteUsaState;
using Shouldly;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace CleanArchitecture.Application.UnitTests.UsaStates.Commands.DeleteUsaState
{
    public class DeleteUsaStateCommandTests : CommandTestBase
    {
        [Fact]
        public async Task Handle_GivenValidId_ShouldRemovePersistedUsaState()
        {
            var command = new DeleteUsaStateCommand
            {
                Id = 1
            };

            var handler = new DeleteUsaStateCommand.DeleteUsaStateCommandHandler(Context);

            await handler.Handle(command, CancellationToken.None);

            var entity = Context.UsaStates.Find(command.Id);

            entity.ShouldBeNull();
        }

        [Fact]
        public void Handle_GivenInvalidId_ThrowsException()
        {
            var command = new DeleteUsaStateCommand
            {
                Id = 99
            };

            var handler = new DeleteUsaStateCommand.DeleteUsaStateCommandHandler(Context);

            Should.ThrowAsync<NotFoundException>(() =>
                handler.Handle(command, CancellationToken.None));
        }
    }
}
