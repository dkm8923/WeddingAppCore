using Shouldly;
using System.Threading;
using System.Threading.Tasks;
using Xunit;
using CleanArchitecture.Application.UnitTests.Common;
using CleanArchitecture.Application.EmailLogs.Commands.CreateEmailLog;
using System;

namespace CleanArchitecture.Application.UnitTests.EmailLogs.Commands.CreateEmailLog
{
    public class CreateEmailLogCommandTests : CommandTestBase
    {
        [Fact]
        public async Task Handle_ShouldPersistEmailLog()
        {
            var command = new CreateEmailLogCommand
            {
                EmailId = 1,
                SentDate = DateTime.Now,
                SentBy = "UnitTest"
            };

            var handler = new CreateEmailLogCommand.CreateEmailLogCommandHandler(Context);

            var result = await handler.Handle(command, CancellationToken.None);

            var entity = Context.EmailLogs.Find(result);

            entity.ShouldNotBeNull();
            entity.EmailId.ShouldBe(command.EmailId);
            entity.SentDate.ShouldBe(command.SentDate);
            entity.SentBy.ShouldBe(command.SentBy);
        }
    }
}
