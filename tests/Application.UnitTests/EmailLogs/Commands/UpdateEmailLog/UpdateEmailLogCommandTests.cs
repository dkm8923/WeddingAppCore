using CleanArchitecture.Application.Common.Exceptions;
using CleanArchitecture.Application.UnitTests.Common;
using CleanArchitecture.Application.EmailLogs.Commands.UpdateEmailLog;
using Shouldly;
using System;
using System.Threading;
using System.Threading.Tasks;
using Xunit;
namespace CleanArchitecture.Application.UnitTests.EmailLogs.Commands.UpdateEmailLog
{
    public class UpdateGuestCommandTests : CommandTestBase
    {
        [Fact]
        public async Task Handle_GivenValidId_ShouldUpdatePersistedEmailLog()
        {
            var command = new UpdateEmailLogCommand
            {
                Id = 1,
                EmailId = 1,
                SentDate = DateTime.Now,
                SentBy = "UnitTest"
            };

            var handler = new UpdateEmailLogCommand.UpdateEmailLogCommandHandler(Context);

            await handler.Handle(command, CancellationToken.None);

            var entity = Context.EmailLogs.Find(command.Id);

            entity.ShouldNotBeNull();
            entity.EmailId.ShouldBe(command.EmailId);
            entity.SentDate.ShouldBe(command.SentDate);
            entity.SentBy.ShouldBe(command.SentBy);
        }

        [Fact]
        public void Handle_GivenInvalidId_ThrowsException()
        {
            var command = new UpdateEmailLogCommand
            {
                Id = 99,
                EmailId = 1,
                SentDate = DateTime.Now,
                SentBy = "UnitTest"
            };

            var handler = new UpdateEmailLogCommand.UpdateEmailLogCommandHandler(Context);

            Should.ThrowAsync<NotFoundException>(() =>
                handler.Handle(command, CancellationToken.None));
        }
    }
}
