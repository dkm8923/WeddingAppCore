using CleanArchitecture.Application.UnitTests.Common;
using CleanArchitecture.Application.Emails.Commands.UpdateEmail;
using Shouldly;
using Xunit;

namespace CleanArchitecture.Application.UnitTests.Emails.Commands.UpdateEmail
{
    public class UpdateEmailCommandValidatorTests : CommandTestBase
    {
        [Fact]
        public void IsValid_ShouldBeTrue_WhenRequiredFieldsAreSet()
        {
            var command = new UpdateEmailCommand
            {
                Id = 1,
                Description = "test Description",
                Subject = "test Subject",
                Body = "test Body"
            };

            var validator = new UpdateEmailCommandValidator(Context);

            var result = validator.Validate(command);

            result.IsValid.ShouldBe(true);
        }

        [Fact]
        public void IsValid_ShouldBeFalse_WhenRequiredFieldsAreNotSet()
        {
            var command = new UpdateEmailCommand();

            var validator = new UpdateEmailCommandValidator(Context);

            var result = validator.Validate(command);

            result.IsValid.ShouldBe(false);
        }
    }
}
