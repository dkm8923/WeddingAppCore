using CleanArchitecture.Application.UnitTests.Common;
using CleanArchitecture.Application.WeddingDescriptions.Commands.UpdateWeddingDescription;
using Shouldly;
using Xunit;

namespace CleanArchitecture.Application.UnitTests.WeddingDescriptions.Commands.UpdateWeddingDescription
{
    public class UpdateWeddingDescriptionCommandValidatorTests : CommandTestBase
    {
        [Fact]
        public void IsValid_ShouldBeTrue_WhenRequiredFieldsAreSet()
        {
            var command = new UpdateWeddingDescriptionCommand 
            {
                GroomDescription = "test",
                BrideDescription = "test",
                CeremonyDateTimeLocation = "test",
                CeremonyDescription = "test",
                ReceptionDateTimeLocation = "test",
                ReceptionDescription = "test"
            };

            var validator = new UpdateWeddingDescriptionCommandValidator(Context);

            var result = validator.Validate(command);

            result.IsValid.ShouldBe(true);
        }

        [Fact]
        public void IsValid_ShouldBeFalse_WhenRequiredFieldsAreNotSet()
        {
            var command = new UpdateWeddingDescriptionCommand();

            var validator = new UpdateWeddingDescriptionCommandValidator(Context);

            var result = validator.Validate(command);

            result.IsValid.ShouldBe(false);
        }
    }
}
