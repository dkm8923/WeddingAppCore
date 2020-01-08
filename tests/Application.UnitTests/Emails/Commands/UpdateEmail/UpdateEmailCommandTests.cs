using CleanArchitecture.Application.Common.Exceptions;
using CleanArchitecture.Application.UnitTests.Common;
using CleanArchitecture.Application.Emails.Commands.UpdateEmail;
using Shouldly;
using System.Threading;
using System.Threading.Tasks;
using Xunit;
namespace CleanArchitecture.Application.UnitTests.Emails.Commands.UpdateEmail
{
    public class UpdateEmailCommandTests : CommandTestBase
    {
        [Fact]
        public async Task Handle_GivenValidId_ShouldUpdatePersistedEmail()
        {
            var command = new UpdateEmailCommand
            {
                Id = 1,
                Description = "Test Update Description",
                Subject = "Test Update Subject",
                Body = "Test Update Body"
            };

            var handler = new UpdateEmailCommand.UpdateEmailCommandHandler(Context);

            await handler.Handle(command, CancellationToken.None);

            var entity = Context.Emails.Find(command.Id);

            entity.ShouldNotBeNull();
            entity.Description.ShouldBe(command.Description);
            entity.Subject.ShouldBe(command.Subject);
            entity.Body.ShouldBe(command.Body);
        }

        [Fact]
        public void Handle_GivenInvalidId_ThrowsException()
        {
            var command = new UpdateEmailCommand
            {
                Id = 99,
                Description = "Test Update Description",
                Subject = "Test Update Subject",
                Body = "Test Update Body"
            };

            var handler = new UpdateEmailCommand.UpdateEmailCommandHandler(Context);

            Should.ThrowAsync<NotFoundException>(() =>
                handler.Handle(command, CancellationToken.None));
        }
    }
}
