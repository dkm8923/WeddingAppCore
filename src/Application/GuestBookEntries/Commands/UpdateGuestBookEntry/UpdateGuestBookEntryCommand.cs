using CleanArchitecture.Application.Common.Exceptions;
using CleanArchitecture.Application.Common.Interfaces;
using CleanArchitecture.Domain.Entities;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace CleanArchitecture.Application.GuestBookEntries.Commands.UpdateGuestBookEntry
{
    public class UpdateGuestBookEntryCommand : IRequest
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string Entry { get; set; }

        public class UpdateGuestBookEntryCommandHandler : IRequestHandler<UpdateGuestBookEntryCommand>
        {
            private readonly IApplicationDbContext _context;

            public UpdateGuestBookEntryCommandHandler(IApplicationDbContext context)
            {
                _context = context;
            }

            public async Task<Unit> Handle(UpdateGuestBookEntryCommand request, CancellationToken cancellationToken)
            {
                var entity = await _context.GuestBookEntries.FindAsync(request.Id);

                if (entity == null)
                {
                    throw new NotFoundException(nameof(GuestBookEntry), request.Id);
                }

                entity.Name = request.Name;
                entity.Entry = request.Entry;
                
                await _context.SaveChangesAsync(cancellationToken);

                return Unit.Value;
            }
        }
    }
}
