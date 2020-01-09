using CleanArchitecture.Application.Common.Exceptions;
using CleanArchitecture.Application.UnitTests.Common;
using CleanArchitecture.Application.WeddingDescriptions.Commands.UpdateWeddingDescription;
using Shouldly;
using System.Threading;
using System.Threading.Tasks;
using Xunit;
namespace CleanArchitecture.Application.UnitTests.WeddingDescriptions.Commands.UpdateWeddingDescription
{
    public class UpdateUsaStateCommandTests : CommandTestBase
    {
        [Fact]
        public async Task Handle_GivenValidId_ShouldUpdatePersistedWeddingDescription()
        {
            var command = new UpdateWeddingDescriptionCommand
            {
                Id = 1,
                GroomDescription = "Test Update GroomDescription",
                BrideDescription = "Test Update BrideDescription",
                CeremonyDateTimeLocation = "Test Update CeremonyDateTimeLocation",
                CeremonyDescription = "Test Update CeremonyDescription",
                ReceptionDateTimeLocation = "Test Update ReceptionDateTimeLocation",
                ReceptionDescription = "Test Update ReceptionDescription"
            };

            var handler = new UpdateWeddingDescriptionCommand.UpdateWeddingDescriptionCommandHandler(Context);

            await handler.Handle(command, CancellationToken.None);

            var entity = Context.WeddingDescriptions.Find(command.Id);

            entity.ShouldNotBeNull();
            entity.GroomDescription.ShouldBe(command.GroomDescription);
            entity.BrideDescription.ShouldBe(command.BrideDescription);
            entity.CeremonyDateTimeLocation.ShouldBe(command.CeremonyDateTimeLocation);
            entity.CeremonyDescription.ShouldBe(command.CeremonyDescription);
            entity.ReceptionDateTimeLocation.ShouldBe(command.ReceptionDateTimeLocation);
            entity.ReceptionDescription.ShouldBe(command.ReceptionDescription);
        }

        [Fact]
        public void Handle_GivenInvalidId_ThrowsException()
        {
            var command = new UpdateWeddingDescriptionCommand
            {
                Id = 99,
                GroomDescription = "Test Update GroomDescription",
                BrideDescription = "Test Update BrideDescription",
                CeremonyDateTimeLocation = "Test Update CeremonyDateTimeLocation",
                CeremonyDescription = "Test Update CeremonyDescription",
                ReceptionDateTimeLocation = "Test Update ReceptionDateTimeLocation",
                ReceptionDescription = "Test Update ReceptionDescription"
            };

            var handler = new UpdateWeddingDescriptionCommand.UpdateWeddingDescriptionCommandHandler(Context);

            Should.ThrowAsync<NotFoundException>(() =>
                handler.Handle(command, CancellationToken.None));
        }
    }
}
