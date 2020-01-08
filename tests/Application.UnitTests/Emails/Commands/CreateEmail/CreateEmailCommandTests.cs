using Shouldly;
using System.Threading;
using System.Threading.Tasks;
using Xunit;
using CleanArchitecture.Application.UnitTests.Common;
using CleanArchitecture.Application.Emails.Commands.CreateEmail;

namespace CleanArchitecture.Application.UnitTests.Emails.Commands.CreateEmail
{
    public class CreateEmailCommandTests : CommandTestBase
    {
        [Fact]
        public async Task Handle_ShouldPersistEmail()
        {
            var command = new CreateEmailCommand
            {
                Description = "test Description",
                Subject = "test Subject",
                Body = "test Body"
            };

            var handler = new CreateEmailCommand.CreateEmailCommandHandler(Context);

            var result = await handler.Handle(command, CancellationToken.None);

            var entity = Context.Emails.Find(result);

            entity.ShouldNotBeNull();
            entity.Description.ShouldBe(command.Description);
            entity.Subject.ShouldBe(command.Subject);
            entity.Body.ShouldBe(command.Body);
        }
    }
}
