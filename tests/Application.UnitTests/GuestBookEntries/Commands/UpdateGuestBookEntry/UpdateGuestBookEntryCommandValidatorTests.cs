using CleanArchitecture.Application.UnitTests.Common;
using CleanArchitecture.Application.GuestBookEntries.Commands.UpdateGuestBookEntry;
using Shouldly;
using Xunit;

namespace CleanArchitecture.Application.UnitTests.GuestBookEntries.Commands.UpdateGuestBookEntry
{
    public class UpdateGuestBookEntryCommandValidatorTests : CommandTestBase
    {
        [Fact]
        public void IsValid_ShouldBeTrue_WhenRequiredFieldsAreSet()
        {
            var command = new UpdateGuestBookEntryCommand
            {
                Id = 1,
                Name = "Test Name Update",
                Entry = "Test Entry Update"
            };

            var validator = new UpdateGuestBookEntryCommandValidator(Context);

            var result = validator.Validate(command);

            result.IsValid.ShouldBe(true);
        }

        [Fact]
        public void IsValid_ShouldBeFalse_WhenRequiredFieldsAreNotSet()
        {
            var command = new UpdateGuestBookEntryCommand();

            var validator = new UpdateGuestBookEntryCommandValidator(Context);

            var result = validator.Validate(command);

            result.IsValid.ShouldBe(false);
        }
    }
}
