using CleanArchitecture.Application.UnitTests.Common;
using CleanArchitecture.Application.Emails.Commands.CreateEmail;
using Shouldly;
using Xunit;

namespace CleanArchitecture.Application.UnitTests.Emails.Commands.CreateEmail
{
    public class CreateEmailCommandValidatorTests : CommandTestBase
    {
        [Fact]
        public void IsValid_ShouldBeTrue_WhenRequiredFieldsAreSet()
        {
            var command = new CreateEmailCommand
            {
                Description = "test",
                Subject = "test",
                Body = "test"
            };

            var validator = new CreateEmailCommandValidator(Context);

            var result = validator.Validate(command);

            result.IsValid.ShouldBe(true);
        }

        [Fact]
        public void IsValid_ShouldBeFalse_WhenRequiredFieldsAreNotSet()
        {
            var command = new CreateEmailCommand();

            var validator = new CreateEmailCommandValidator(Context);

            var result = validator.Validate(command);

            result.IsValid.ShouldBe(false);
        }
    }
}
