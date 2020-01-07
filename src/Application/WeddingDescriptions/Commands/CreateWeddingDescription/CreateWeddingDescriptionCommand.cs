using CleanArchitecture.Application.Common.Interfaces;
using CleanArchitecture.Domain.Entities;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace CleanArchitecture.Application.WeddingDescriptions.Commands.CreateWeddingDescription
{
    public class CreateWeddingDescriptionCommand : IRequest<long>
    {
        public string GroomDescription { get; set; }
        public string BrideDescription { get; set; }
        public string CeremonyDateTimeLocation { get; set; }
        public string CeremonyDescription { get; set; }
        public string ReceptionDateTimeLocation { get; set; }
        public string ReceptionDescription { get; set; }

        public class CreateWeddingDescriptionCommandHandler : IRequestHandler<CreateWeddingDescriptionCommand, long>
        {
            private readonly IApplicationDbContext _context;

            public CreateWeddingDescriptionCommandHandler(IApplicationDbContext context)
            {
                _context = context;
            }

            public async Task<long> Handle(CreateWeddingDescriptionCommand request, CancellationToken cancellationToken)
            {
                var entity = new Domain.Entities.WeddingDescription
                { 
                    GroomDescription = request.GroomDescription,
                    BrideDescription = request.BrideDescription,
                    CeremonyDateTimeLocation = request.CeremonyDateTimeLocation,
                    CeremonyDescription = request.CeremonyDescription,
                    ReceptionDateTimeLocation = request.ReceptionDateTimeLocation,
                    ReceptionDescription = request.ReceptionDescription
                };

                _context.WeddingDescriptions.Add(entity);

                await _context.SaveChangesAsync(cancellationToken);

                return entity.Id;
            }
        }
    }
}
