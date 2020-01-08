using CleanArchitecture.Application.Common.Exceptions;
using CleanArchitecture.Application.UnitTests.Common;
using CleanArchitecture.Application.Emails.Commands.DeleteEmail;
using Shouldly;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace CleanArchitecture.Application.UnitTests.Emails.Commands.DeleteEmail
{
    public class DeleteEmailCommandTests : CommandTestBase
    {
        [Fact]
        public async Task Handle_GivenValidId_ShouldRemovePersistedEmail()
        {
            var command = new DeleteEmailCommand
            {
                Id = 1
            };

            var handler = new DeleteEmailCommand.DeleteEmailCommandHandler(Context);

            await handler.Handle(command, CancellationToken.None);

            var entity = Context.Emails.Find(command.Id);

            entity.ShouldBeNull();
        }

        [Fact]
        public void Handle_GivenInvalidId_ThrowsException()
        {
            var command = new DeleteEmailCommand
            {
                Id = 99
            };

            var handler = new DeleteEmailCommand.DeleteEmailCommandHandler(Context);

            Should.ThrowAsync<NotFoundException>(() =>
                handler.Handle(command, CancellationToken.None));
        }
    }
}
