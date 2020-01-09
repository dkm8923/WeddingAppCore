using CleanArchitecture.Application.UnitTests.Common;
using CleanArchitecture.Application.EmailLogs.Commands.CreateEmailLog;
using Shouldly;
using Xunit;
using System;

namespace CleanArchitecture.Application.UnitTests.EmailLogs.Commands.CreateEmailLog
{
    public class CreateEmailLogCommandValidatorTests : CommandTestBase
    {
        [Fact]
        public void IsValid_ShouldBeTrue_WhenRequiredFieldsAreSet()
        {
            var command = new CreateEmailLogCommand
            {
                EmailId = 1,
                SentDate = DateTime.Now,
                SentBy = "UnitTest"
            };

            var validator = new CreateEmailLogCommandValidator(Context);

            var result = validator.Validate(command);

            result.IsValid.ShouldBe(true);
        }

        [Fact]
        public void IsValid_ShouldBeFalse_WhenRequiredFieldsAreNotSet()
        {
            var command = new CreateEmailLogCommand();

            var validator = new CreateEmailLogCommandValidator(Context);

            var result = validator.Validate(command);

            result.IsValid.ShouldBe(false);
        }
    }
}
