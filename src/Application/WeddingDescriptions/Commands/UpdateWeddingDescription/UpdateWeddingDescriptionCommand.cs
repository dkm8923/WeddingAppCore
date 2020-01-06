using CleanArchitecture.Application.Common.Exceptions;
using CleanArchitecture.Application.Common.Interfaces;
using CleanArchitecture.Domain.Entities;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace CleanArchitecture.Application.WeddingDescriptions.Commands.UpdateWeddingDescription
{
    public class UpdateWeddingDescriptionCommand : IRequest
    {
        public long Id { get; set; }
        public string GroomDescription { get; set; }
        public string BrideDescription { get; set; }
        public string CeremonyDateTimeLocation { get; set; }
        public string CeremonyDescription { get; set; }
        public string ReceptionDateTimeLocation { get; set; }
        public string ReceptionDescription { get; set; }

        public class UpdateWeddingDescriptionCommandHandler : IRequestHandler<UpdateWeddingDescriptionCommand>
        {
            private readonly IApplicationDbContext _context;

            public UpdateWeddingDescriptionCommandHandler(IApplicationDbContext context)
            {
                _context = context;
            }

            public async Task<Unit> Handle(UpdateWeddingDescriptionCommand request, CancellationToken cancellationToken)
            {
                var entity = await _context.WeddingDescriptions.FindAsync(request.Id);

                if (entity == null)
                {
                    throw new NotFoundException(nameof(WeddingDescription), request.Id);
                }

                entity.GroomDescription = request.GroomDescription;
                entity.BrideDescription = request.BrideDescription;
                entity.CeremonyDateTimeLocation = request.CeremonyDateTimeLocation;
                entity.CeremonyDescription = request.CeremonyDescription;
                entity.ReceptionDateTimeLocation = request.ReceptionDateTimeLocation;
                entity.ReceptionDescription = request.ReceptionDescription;
                
                await _context.SaveChangesAsync(cancellationToken);

                return Unit.Value;
            }
        }
    }
}
