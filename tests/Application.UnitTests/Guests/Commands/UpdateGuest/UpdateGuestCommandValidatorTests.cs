using CleanArchitecture.Application.UnitTests.Common;
using CleanArchitecture.Application.Guests.Commands.UpdateGuest;
using Shouldly;
using Xunit;

namespace CleanArchitecture.Application.UnitTests.Guests.Commands.UpdateGuest
{
    public class UpdateGuestCommandValidatorTests : CommandTestBase
    {
        [Fact]
        public void IsValid_ShouldBeTrue_WhenRequiredFieldsAreSet()
        {
            var command = new UpdateGuestCommand
            {
                Id = 1,
                FirstName = "Test FirstName Update",
                LastName = "Test LastName Update",
                Email = "Test Email Update"
            };

            var validator = new UpdateGuestCommandValidator(Context);

            var result = validator.Validate(command);

            result.IsValid.ShouldBe(true);
        }

        [Fact]
        public void IsValid_ShouldBeFalse_WhenRequiredFieldsAreNotSet()
        {
            var command = new UpdateGuestCommand();

            var validator = new UpdateGuestCommandValidator(Context);

            var result = validator.Validate(command);

            result.IsValid.ShouldBe(false);
        }
    }
}
