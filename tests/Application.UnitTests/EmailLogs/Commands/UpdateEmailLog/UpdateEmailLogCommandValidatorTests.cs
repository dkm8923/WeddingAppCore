using CleanArchitecture.Application.UnitTests.Common;
using CleanArchitecture.Application.EmailLogs.Commands.UpdateEmailLog;
using Shouldly;
using Xunit;
using System;

namespace CleanArchitecture.Application.UnitTests.EmailLogs.Commands.UpdateEmailLog
{
    public class UpdateGuestCommandValidatorTests : CommandTestBase
    {
        [Fact]
        public void IsValid_ShouldBeTrue_WhenRequiredFieldsAreSet()
        {
            var command = new UpdateEmailLogCommand
            {
                Id = 1,
                EmailId = 1,
                SentDate = DateTime.Now,
                SentBy = "UnitTest"
            };

            var validator = new UpdateEmailLogCommandValidator(Context);

            var result = validator.Validate(command);

            result.IsValid.ShouldBe(true);
        }

        [Fact]
        public void IsValid_ShouldBeFalse_WhenRequiredFieldsAreNotSet()
        {
            var command = new UpdateEmailLogCommand();

            var validator = new UpdateEmailLogCommandValidator(Context);

            var result = validator.Validate(command);

            result.IsValid.ShouldBe(false);
        }
    }
}
