using CleanArchitecture.Application.Common.Exceptions;
using CleanArchitecture.Application.Common.Interfaces;
using CleanArchitecture.Domain.Entities;
using MediatR;
using System.Threading;
using System.Threading.Tasks;


namespace CleanArchitecture.Application.GuestBookEntries.Commands.DeleteGuestBookEntry
{
    public class DeleteGuestBookEntryCommand : IRequest
    {
        public long Id { get; set; }

        public class DeleteGuestBookEntryCommandHandler : IRequestHandler<DeleteGuestBookEntryCommand>
        {
            private readonly IApplicationDbContext _context;

            public DeleteGuestBookEntryCommandHandler(IApplicationDbContext context)
            {
                _context = context;
            }

            public async Task<Unit> Handle(DeleteGuestBookEntryCommand request, CancellationToken cancellationToken)
            {
                var entity = await _context.GuestBookEntries.FindAsync(request.Id);

                if (entity == null)
                {
                    throw new NotFoundException(nameof(GuestBookEntry), request.Id);
                }

                _context.GuestBookEntries.Remove(entity);

                await _context.SaveChangesAsync(cancellationToken);

                return Unit.Value;
            }
        }
    }
}