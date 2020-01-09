using CleanArchitecture.Application.UnitTests.Common;
using CleanArchitecture.Application.Families.Commands.UpdateFamily;
using Shouldly;
using Xunit;

namespace CleanArchitecture.Application.UnitTests.Families.Commands.UpdateFamily
{
    public class UpdateFamilyCommandValidatorTests : CommandTestBase
    {
        [Fact]
        public void IsValid_ShouldBeTrue_WhenRequiredFieldsAreSet()
        {
            var command = new UpdateFamilyCommand
            {
                Id = 1,
                GuestId = 1,
                ConfirmationCode = "Test ConfirmationCode Update",
                Address1 = "Test Address1 Update",
                Address2 = "Test Address2 Update",
                City = "Test City Update",
                StateId = 1,
                Zip = "Test Zip Update"
            };

            var validator = new UpdateFamilyCommandValidator(Context);

            var result = validator.Validate(command);

            result.IsValid.ShouldBe(true);
        }

        [Fact]
        public void IsValid_ShouldBeFalse_WhenRequiredFieldsAreNotSet()
        {
            var command = new UpdateFamilyCommand();

            var validator = new UpdateFamilyCommandValidator(Context);

            var result = validator.Validate(command);

            result.IsValid.ShouldBe(false);
        }
    }
}
