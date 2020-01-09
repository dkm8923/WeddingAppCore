using CleanArchitecture.Application.UnitTests.Common;
using CleanArchitecture.Application.Guests.Commands.CreateGuest;
using Shouldly;
using Xunit;

namespace CleanArchitecture.Application.UnitTests.Guests.Commands.CreateGuest
{
    public class CreateGuestCommandValidatorTests : CommandTestBase
    {
        [Fact]
        public void IsValid_ShouldBeTrue_WhenRequiredFieldsAreSet()
        {
            var command = new CreateGuestCommand
            {
                FirstName = "Test FirstName",
                LastName = "Test LastName",
                Email = "Test Email"
            };

            var validator = new CreateGuestCommandValidator(Context);

            var result = validator.Validate(command);

            result.IsValid.ShouldBe(true);
        }

        [Fact]
        public void IsValid_ShouldBeFalse_WhenRequiredFieldsAreNotSet()
        {
            var command = new CreateGuestCommand();

            var validator = new CreateGuestCommandValidator(Context);

            var result = validator.Validate(command);

            result.IsValid.ShouldBe(false);
        }
    }
}
