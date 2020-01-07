using CleanArchitecture.Application.Common.Interfaces;
using CleanArchitecture.Domain.Entities;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace CleanArchitecture.Application.GuestBookEntries.Commands.CreateGuestBookEntry
{
    public class CreateGuestBookEntryCommand : IRequest<long>
    {
        public string Name { get; set; }
        public string Entry { get; set; }
        
        public class CreateGuestBookEntryCommandHandler : IRequestHandler<CreateGuestBookEntryCommand, long>
        {
            private readonly IApplicationDbContext _context;

            public CreateGuestBookEntryCommandHandler(IApplicationDbContext context)
            {
                _context = context;
            }

            public async Task<long> Handle(CreateGuestBookEntryCommand request, CancellationToken cancellationToken)
            {
                var entity = new GuestBookEntry
                {
                    Name = request.Name,
                    Entry = request.Entry
                };

                _context.GuestBookEntries.Add(entity);

                await _context.SaveChangesAsync(cancellationToken);

                return entity.Id;
            }
        }
    }
}
