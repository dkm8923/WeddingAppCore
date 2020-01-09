using CleanArchitecture.Application.Common.Exceptions;
using CleanArchitecture.Application.UnitTests.Common;
using CleanArchitecture.Application.Families.Commands.DeleteFamily;
using Shouldly;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace CleanArchitecture.Application.UnitTests.Families.Commands.DeleteFamily
{
    public class DeleteFamilyCommandTests : CommandTestBase
    {
        [Fact]
        public async Task Handle_GivenValidId_ShouldRemovePersistedFamily()
        {
            var command = new DeleteFamilyCommand
            {
                Id = 1
            };

            var handler = new DeleteFamilyCommand.DeleteFamilyCommandHandler(Context);

            await handler.Handle(command, CancellationToken.None);

            var entity = Context.Families.Find(command.Id);

            entity.ShouldBeNull();
        }

        [Fact]
        public void Handle_GivenInvalidId_ThrowsException()
        {
            var command = new DeleteFamilyCommand
            {
                Id = 99
            };

            var handler = new DeleteFamilyCommand.DeleteFamilyCommandHandler(Context);

            Should.ThrowAsync<NotFoundException>(() =>
                handler.Handle(command, CancellationToken.None));
        }
    }
}
