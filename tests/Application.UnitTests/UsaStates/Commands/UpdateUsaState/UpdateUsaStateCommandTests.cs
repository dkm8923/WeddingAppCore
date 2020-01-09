using CleanArchitecture.Application.Common.Exceptions;
using CleanArchitecture.Application.UnitTests.Common;
using CleanArchitecture.Application.UsaStates.Commands.UpdateUsaState;
using Shouldly;
using System.Threading;
using System.Threading.Tasks;
using Xunit;
namespace CleanArchitecture.Application.UnitTests.UsaStates.Commands.UpdateUsaState
{
    public class UpdateUsaStateCommandTests : CommandTestBase
    {
        [Fact]
        public async Task Handle_GivenValidId_ShouldUpdatePersistedUsaState()
        {
            var command = new UpdateUsaStateCommand
            {
                Id = 1,
                Name = "Test Name Update",
                AbbreviatedName = "Test AbbreviatedName Update"
            };

            var handler = new UpdateUsaStateCommand.UpdateUsaStateCommandHandler(Context);

            await handler.Handle(command, CancellationToken.None);

            var entity = Context.UsaStates.Find(command.Id);

            entity.ShouldNotBeNull();
            entity.Name.ShouldBe(command.Name);
            entity.AbbreviatedName.ShouldBe(command.AbbreviatedName);
        }

        [Fact]
        public void Handle_GivenInvalidId_ThrowsException()
        {
            var command = new UpdateUsaStateCommand
            {
                Id = 99,
                Name = "Test Name Update",
                AbbreviatedName = "Test AbbreviatedName Update"
            };

            var handler = new UpdateUsaStateCommand.UpdateUsaStateCommandHandler(Context);

            Should.ThrowAsync<NotFoundException>(() =>
                handler.Handle(command, CancellationToken.None));
        }
    }
}
