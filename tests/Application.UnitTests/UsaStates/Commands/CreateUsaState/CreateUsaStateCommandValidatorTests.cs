using CleanArchitecture.Application.UnitTests.Common;
using CleanArchitecture.Application.UsaStates.Commands.CreateUsaState;
using Shouldly;
using Xunit;

namespace CleanArchitecture.Application.UnitTests.UsaStates.Commands.CreateUsaState
{
    public class CreateUsaStateCommandValidatorTests : CommandTestBase
    {
        [Fact]
        public void IsValid_ShouldBeTrue_WhenRequiredFieldsAreSet()
        {
            var command = new CreateUsaStateCommand
            {
                Name = "Test Name",
                AbbreviatedName = "Test AbbreviatedName"
            };

            var validator = new CreateUsaStateCommandValidator(Context);

            var result = validator.Validate(command);

            result.IsValid.ShouldBe(true);
        }

        [Fact]
        public void IsValid_ShouldBeFalse_WhenRequiredFieldsAreNotSet()
        {
            var command = new CreateUsaStateCommand();

            var validator = new CreateUsaStateCommandValidator(Context);

            var result = validator.Validate(command);

            result.IsValid.ShouldBe(false);
        }
    }
}
