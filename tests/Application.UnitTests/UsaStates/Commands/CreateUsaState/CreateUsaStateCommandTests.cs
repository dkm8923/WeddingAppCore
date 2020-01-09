using Shouldly;
using System.Threading;
using System.Threading.Tasks;
using Xunit;
using CleanArchitecture.Application.UnitTests.Common;
using CleanArchitecture.Application.UsaStates.Commands.CreateUsaState;

namespace CleanArchitecture.Application.UnitTests.UsaStates.Commands.CreateUsaState
{
    public class CreateUsaStateCommandTests : CommandTestBase
    {
        [Fact]
        public async Task Handle_ShouldPersistUsaState()
        {
            var command = new CreateUsaStateCommand
            {
                Name = "Test Name",
                AbbreviatedName = "Test AbbreviatedName"
            };

            var handler = new CreateUsaStateCommand.CreateUsaStateCommandHandler(Context);

            var result = await handler.Handle(command, CancellationToken.None);

            var entity = Context.UsaStates.Find(result);

            entity.ShouldNotBeNull();
            entity.Name.ShouldBe(command.Name);
            entity.AbbreviatedName.ShouldBe(command.AbbreviatedName);
        }
    }
}
