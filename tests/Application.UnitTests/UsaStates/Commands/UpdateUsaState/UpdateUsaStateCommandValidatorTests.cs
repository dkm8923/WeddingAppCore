using CleanArchitecture.Application.UnitTests.Common;
using CleanArchitecture.Application.UsaStates.Commands.UpdateUsaState;
using Shouldly;
using Xunit;

namespace CleanArchitecture.Application.UnitTests.UsaStates.Commands.UpdateUsaState
{
    public class UpdateUsaStateCommandValidatorTests : CommandTestBase
    {
        [Fact]
        public void IsValid_ShouldBeTrue_WhenRequiredFieldsAreSet()
        {
            var command = new UpdateUsaStateCommand
            {
                Id = 1,
                Name = "Test Name Update",
                AbbreviatedName = "Test AbbreviatedName Update"
            };

            var validator = new UpdateUsaStateCommandValidator(Context);

            var result = validator.Validate(command);

            result.IsValid.ShouldBe(true);
        }

        [Fact]
        public void IsValid_ShouldBeFalse_WhenRequiredFieldsAreNotSet()
        {
            var command = new UpdateUsaStateCommand();

            var validator = new UpdateUsaStateCommandValidator(Context);

            var result = validator.Validate(command);

            result.IsValid.ShouldBe(false);
        }
    }
}
