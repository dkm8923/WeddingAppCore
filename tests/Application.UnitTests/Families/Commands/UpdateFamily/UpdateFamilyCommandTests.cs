using CleanArchitecture.Application.Common.Exceptions;
using CleanArchitecture.Application.UnitTests.Common;
using CleanArchitecture.Application.Families.Commands.UpdateFamily;
using Shouldly;
using System.Threading;
using System.Threading.Tasks;
using Xunit;
namespace CleanArchitecture.Application.UnitTests.Families.Commands.UpdateFamily
{
    public class UpdateFamilyCommandTests : CommandTestBase
    {
        [Fact]
        public async Task Handle_GivenValidId_ShouldUpdatePersistedFamily()
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

            var handler = new UpdateFamilyCommand.UpdateFamilyCommandHandler(Context);

            await handler.Handle(command, CancellationToken.None);

            var entity = Context.Families.Find(command.Id);

            entity.ShouldNotBeNull();
            entity.GuestId.ShouldBe(command.GuestId);
            entity.ConfirmationCode.ShouldBe(command.ConfirmationCode);
            entity.Address1.ShouldBe(command.Address1);
            entity.Address2.ShouldBe(command.Address2);
            entity.City.ShouldBe(command.City);
            entity.StateId.ShouldBe(command.StateId);
            entity.Zip.ShouldBe(command.Zip);
        }

        [Fact]
        public void Handle_GivenInvalidId_ThrowsException()
        {
            var command = new UpdateFamilyCommand
            {
                Id = 99,
                GuestId = 1,
                ConfirmationCode = "Test ConfirmationCode Update",
                Address1 = "Test Address1 Update",
                Address2 = "Test Address2 Update",
                City = "Test City Update",
                StateId = 1,
                Zip = "Test Zip Update"
            };

            var handler = new UpdateFamilyCommand.UpdateFamilyCommandHandler(Context);

            Should.ThrowAsync<NotFoundException>(() =>
                handler.Handle(command, CancellationToken.None));
        }
    }
}
