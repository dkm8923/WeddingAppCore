using CleanArchitecture.Application.Common.Exceptions;
using CleanArchitecture.Application.Common.Interfaces;
using CleanArchitecture.Domain.Entities;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace CleanArchitecture.Application.UsaStates.Commands.DeleteUsaState
{
    public class DeleteUsaStateCommand : IRequest
    {
        public long Id { get; set; }

        public class DeleteUsaStateCommandHandler : IRequestHandler<DeleteUsaStateCommand>
        {
            private readonly IApplicationDbContext _context;

            public DeleteUsaStateCommandHandler(IApplicationDbContext context)
            {
                _context = context;
            }

            public async Task<Unit> Handle(DeleteUsaStateCommand request, CancellationToken cancellationToken)
            {
                var entity = await _context.UsaStates.FindAsync(request.Id);

                if (entity == null)
                {
                    throw new NotFoundException(nameof(UsaState), request.Id);
                }

                _context.UsaStates.Remove(entity);

                await _context.SaveChangesAsync(cancellationToken);

                return Unit.Value;
            }
        }
    }
}
