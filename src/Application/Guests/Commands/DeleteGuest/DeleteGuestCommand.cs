using CleanArchitecture.Application.Common.Exceptions;
using CleanArchitecture.Application.Common.Interfaces;
using CleanArchitecture.Domain.Entities;
using MediatR;
using System.Threading;
using System.Threading.Tasks;


namespace CleanArchitecture.Application.Guest.Commands.DeleteGuest
{
    public class DeleteGuestCommand : IRequest
    {
        public long Id { get; set; }

        public class DeleteGuestCommandHandler : IRequestHandler<DeleteGuestCommand>
        {
            private readonly IApplicationDbContext _context;

            public DeleteGuestCommandHandler(IApplicationDbContext context)
            {
                _context = context;
            }

            public async Task<Unit> Handle(DeleteGuestCommand request, CancellationToken cancellationToken)
            {
                var entity = await _context.Guests.FindAsync(request.Id);

                if (entity == null)
                {
                    throw new NotFoundException(nameof(TodoItem), request.Id);
                }

                _context.Guests.Remove(entity);

                await _context.SaveChangesAsync(cancellationToken);

                return Unit.Value;
            }
        }
    }
}