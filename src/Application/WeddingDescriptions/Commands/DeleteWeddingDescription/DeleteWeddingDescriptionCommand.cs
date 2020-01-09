using CleanArchitecture.Application.Common.Exceptions;
using CleanArchitecture.Application.Common.Interfaces;
using CleanArchitecture.Domain.Entities;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace CleanArchitecture.Application.WeddingDescriptions.Commands.DeleteWeddingDescription
{
    public class DeleteWeddingDescriptionCommand : IRequest
    {
        public long Id { get; set; }

        public class DeleteWeddingDescriptionCommandHandler : IRequestHandler<DeleteWeddingDescriptionCommand>
        {
            private readonly IApplicationDbContext _context;

            public DeleteWeddingDescriptionCommandHandler(IApplicationDbContext context)
            {
                _context = context;
            }

            public async Task<Unit> Handle(DeleteWeddingDescriptionCommand request, CancellationToken cancellationToken)
            {
                var entity = await _context.WeddingDescriptions.FindAsync(request.Id);

                if (entity == null)
                {
                    throw new NotFoundException(nameof(WeddingDescription), request.Id);
                }

                _context.WeddingDescriptions.Remove(entity);

                await _context.SaveChangesAsync(cancellationToken);

                return Unit.Value;
            }
        }
    }
}
