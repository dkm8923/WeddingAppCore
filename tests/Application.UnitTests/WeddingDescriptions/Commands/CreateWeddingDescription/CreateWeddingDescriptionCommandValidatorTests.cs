using CleanArchitecture.Application.UnitTests.Common;
using CleanArchitecture.Application.WeddingDescriptions.Commands.CreateWeddingDescription;
using Shouldly;
using Xunit;

namespace CleanArchitecture.Application.UnitTests.WeddingDescriptions.Commands.CreateWeddingDescription
{
    public class CreateWeddingDescriptionCommandValidatorTests : CommandTestBase
    {
        [Fact]
        public void IsValid_ShouldBeTrue_WhenRequiredFieldsAreSet()
        {
            var command = new CreateWeddingDescriptionCommand
            {
                GroomDescription = "test",
                BrideDescription = "test",
                CeremonyDateTimeLocation = "test",
                CeremonyDescription = "test",
                ReceptionDateTimeLocation = "test",
                ReceptionDescription = "test"
            };

            var validator = new CreateWeddingDescriptionCommandValidator(Context);

            var result = validator.Validate(command);

            result.IsValid.ShouldBe(true);
        }

        [Fact]
        public void IsValid_ShouldBeFalse_WhenRequiredFieldsAreNotSet()
        {
            var command = new CreateWeddingDescriptionCommand();

            var validator = new CreateWeddingDescriptionCommandValidator(Context);

            var result = validator.Validate(command);

            result.IsValid.ShouldBe(false);
        }
    }
}
