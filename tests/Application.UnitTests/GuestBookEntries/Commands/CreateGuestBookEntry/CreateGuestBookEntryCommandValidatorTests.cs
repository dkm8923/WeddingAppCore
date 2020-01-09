using CleanArchitecture.Application.UnitTests.Common;
using CleanArchitecture.Application.GuestBookEntries.Commands.CreateGuestBookEntry;
using Shouldly;
using Xunit;

namespace CleanArchitecture.Application.UnitTests.GuestBookEntries.Commands.CreateGuestBookEntry
{
    public class CreateGuestBookEntryCommandValidatorTests : CommandTestBase
    {
        [Fact]
        public void IsValid_ShouldBeTrue_WhenRequiredFieldsAreSet()
        {
            var command = new CreateGuestBookEntryCommand
            {
                Name = "Test Name",
                Entry = "Test Entry"
            };

            var validator = new CreateGuestBookEntryCommandValidator(Context);

            var result = validator.Validate(command);

            result.IsValid.ShouldBe(true);
        }

        [Fact]
        public void IsValid_ShouldBeFalse_WhenRequiredFieldsAreNotSet()
        {
            var command = new CreateGuestBookEntryCommand();

            var validator = new CreateGuestBookEntryCommandValidator(Context);

            var result = validator.Validate(command);

            result.IsValid.ShouldBe(false);
        }
    }
}
