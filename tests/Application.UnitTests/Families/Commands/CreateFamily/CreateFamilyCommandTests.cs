using Shouldly;
using System.Threading;
using System.Threading.Tasks;
using Xunit;
using CleanArchitecture.Application.UnitTests.Common;
using CleanArchitecture.Application.Families.Commands.CreateFamily;

namespace CleanArchitecture.Application.UnitTests.Families.Commands.CreateFamily
{
    public class CreateFamilyCommandTests : CommandTestBase
    {
        [Fact]
        public async Task Handle_ShouldPersistFamily()
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

            var handler = new CreateFamilyCommand.CreateFamilyCommandHandler(Context);

            var result = await handler.Handle(command, CancellationToken.None);

            var entity = Context.Families.Find(result);

            entity.ShouldNotBeNull();
            entity.ConfirmationCode.ShouldBe(command.ConfirmationCode);
            entity.Address1.ShouldBe(command.Address1);
            entity.Address2.ShouldBe(command.Address2);
            entity.City.ShouldBe(command.City);
            entity.StateId.ShouldBe(command.StateId);
            entity.Zip.ShouldBe(command.Zip);
        }
    }
}
