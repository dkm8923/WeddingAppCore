﻿using CleanArchitecture.Application.Common.Exceptions;
using CleanArchitecture.Application.UnitTests.Common;
using CleanArchitecture.Application.WeddingDescriptions.Commands.DeleteWeddingDescription;
using Shouldly;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace CleanArchitecture.Application.UnitTests.WeddingDescriptions.Commands.DeleteWeddingDescription
{
    public class DeleteUsaStateCommandTests : CommandTestBase
    {
        [Fact]
        public async Task Handle_GivenValidId_ShouldRemovePersistedWeddingDescription()
        {
            var command = new DeleteWeddingDescriptionCommand
            {
                Id = 1
            };

            var handler = new DeleteWeddingDescriptionCommand.DeleteWeddingDescriptionCommandHandler(Context);

            await handler.Handle(command, CancellationToken.None);

            var entity = Context.WeddingDescriptions.Find(command.Id);

            entity.ShouldBeNull();
        }

        [Fact]
        public void Handle_GivenInvalidId_ThrowsException()
        {
            var command = new DeleteWeddingDescriptionCommand
            {
                Id = 99
            };

            var handler = new DeleteWeddingDescriptionCommand.DeleteWeddingDescriptionCommandHandler(Context);

            Should.ThrowAsync<NotFoundException>(() =>
                handler.Handle(command, CancellationToken.None));
        }
    }
}
