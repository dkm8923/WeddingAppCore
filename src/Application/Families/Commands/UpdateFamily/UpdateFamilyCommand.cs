using CleanArchitecture.Application.Common.Exceptions;
using CleanArchitecture.Application.Common.Interfaces;
using CleanArchitecture.Domain.Entities;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace CleanArchitecture.Application.Families.Commands.UpdateFamily
{
    public class UpdateFamilyCommand : IRequest
    {
        public long Id { get; set; }
        public long GuestId { get; set; }
        public string ConfirmationCode { get; set; }
        public string Address1 { get; set; }
        public string Address2 { get; set; }
        public string City { get; set; }
        public long StateId { get; set; }
        public string Zip { get; set; }
        public bool? Attending { get; set; }

        public class UpdateFamilyCommandHandler : IRequestHandler<UpdateFamilyCommand>
        {
            private readonly IApplicationDbContext _context;

            public UpdateFamilyCommandHandler(IApplicationDbContext context)
            {
                _context = context;
            }

            public async Task<Unit> Handle(UpdateFamilyCommand request, CancellationToken cancellationToken)
            {
                var entity = await _context.Families.FindAsync(request.Id);

                if (entity == null)
                {
                    throw new NotFoundException(nameof(Family), request.Id);
                }

                entity.GuestId = request.GuestId;
                entity.ConfirmationCode = request.ConfirmationCode;
                entity.Address1 = request.Address1;
                entity.Address2 = request.Address2;
                entity.City = request.City;
                entity.StateId = request.StateId;
                entity.Zip = request.Zip;
                entity.Attending = request.Attending;

                await _context.SaveChangesAsync(cancellationToken);

                return Unit.Value;
            }
        }
    }
}
