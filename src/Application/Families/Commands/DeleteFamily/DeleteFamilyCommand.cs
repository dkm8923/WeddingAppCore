using CleanArchitecture.Application.Common.Exceptions;
using CleanArchitecture.Application.Common.Interfaces;
using CleanArchitecture.Domain.Entities;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace CleanArchitecture.Application.Families.Commands.DeleteFamily
{
    public class DeleteFamilyCommand : IRequest
    {
        public long Id { get; set; }

        public class DeleteFamilyCommandHandler : IRequestHandler<DeleteFamilyCommand>
        {
            private readonly IApplicationDbContext _context;

            public DeleteFamilyCommandHandler(IApplicationDbContext context)
            {
                _context = context;
            }

            public async Task<Unit> Handle(DeleteFamilyCommand request, CancellationToken cancellationToken)
            {
                var entity = await _context.Families.FindAsync(request.Id);

                if (entity == null)
                {
                    throw new NotFoundException(nameof(Family), request.Id);
                }

                _context.Families.Remove(entity);

                await _context.SaveChangesAsync(cancellationToken);

                return Unit.Value;
            }
        }
    }
}
