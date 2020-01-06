using CleanArchitecture.Application.UnitTests.Common;
using CleanArchitecture.Application.WeddingDescriptions.Commands.CreateWeddingDescription;
using Shouldly;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace CleanArchitecture.Application.UnitTests.WeddingDescriptions.Commands.CreateWeddingDescription
{
    public class CreateWeddingDescriptionCommandTests : CommandTestBase
    {
        [Fact]
        public async Task Handle_ShouldPersistWeddingDescription()
        {
            var command = new CreateWeddingDescriptionCommand
            {
                GroomDescription = "Test GroomDescription",
                BrideDescription = "Test BrideDescription",
                CeremonyDateTimeLocation = "Test CeremonyDateTimeLocation",
                CeremonyDescription = "Test CeremonyDescription",
                ReceptionDateTimeLocation = "Test ReceptionDateTimeLocation",
                ReceptionDescription = "Test ReceptionDescription"
            };

            var handler = new CreateWeddingDescriptionCommand.CreateWeddingDescriptionCommandHandler(Context);

            var result = await handler.Handle(command, CancellationToken.None);

            var entity = Context.WeddingDescriptions.Find(result);

            entity.ShouldNotBeNull();
            entity.GroomDescription.ShouldBe(command.GroomDescription);
            entity.BrideDescription.ShouldBe(command.BrideDescription);
            entity.CeremonyDateTimeLocation.ShouldBe(command.CeremonyDateTimeLocation);
            entity.CeremonyDescription.ShouldBe(command.CeremonyDescription);
            entity.ReceptionDateTimeLocation.ShouldBe(command.ReceptionDateTimeLocation);
            entity.ReceptionDescription.ShouldBe(command.ReceptionDescription);
        }
    }
}
