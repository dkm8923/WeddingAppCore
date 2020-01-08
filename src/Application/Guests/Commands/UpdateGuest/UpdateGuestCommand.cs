using CleanArchitecture.Application.Common.Exceptions;
using CleanArchitecture.Application.Common.Interfaces;
using CleanArchitecture.Domain.Entities;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace CleanArchitecture.Application.Guests.Commands.UpdateGuest
{
    public class UpdateGuestCommand : IRequest
    {
        public long Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }

        public class UpdateGuestCommandHandler : IRequestHandler<UpdateGuestCommand>
        {
            private readonly IApplicationDbContext _context;

            public UpdateGuestCommandHandler(IApplicationDbContext context)
            {
                _context = context;
            }

            public async Task<Unit> Handle(UpdateGuestCommand request, CancellationToken cancellationToken)
            {
                var entity = await _context.Guests.FindAsync(request.Id);

                if (entity == null)
                {
                    throw new NotFoundException(nameof(Guest), request.Id);
                }

                entity.FirstName = request.FirstName;
                entity.LastName = request.LastName;
                entity.Email = request.Email;

                await _context.SaveChangesAsync(cancellationToken);

                return Unit.Value;
            }
        }
    }
}