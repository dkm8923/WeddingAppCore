using CleanArchitecture.Application.UnitTests.Common;
using CleanArchitecture.Application.Families.Commands.CreateFamily;
using Shouldly;
using Xunit;

namespace CleanArchitecture.Application.UnitTests.Families.Commands.CreateFamily
{
    public class CreateFamilyCommandValidatorTests : CommandTestBase
    {
        [Fact]
        public void IsValid_ShouldBeTrue_WhenRequiredFieldsAreSet()
        {
            var command = new CreateFamilyCommand
            {
                GuestId = 1,
                ConfirmationCode = "Test ConfirmationCode",
                Address1 = "Test Address1",
                Address2 = "Test Address2",
                City = "Test City",
                StateId = 1,
                Zip = "Test Zip"
            };

            var validator = new CreateFamilyCommandValidator(Context);

            var result = validator.Validate(command);

            result.IsValid.ShouldBe(true);
        }

        [Fact]
        public void IsValid_ShouldBeFalse_WhenRequiredFieldsAreNotSet()
        {
            var command = new CreateFamilyCommand();

            var validator = new CreateFamilyCommandValidator(Context);

            var result = validator.Validate(command);

            result.IsValid.ShouldBe(false);
        }
    }
}
