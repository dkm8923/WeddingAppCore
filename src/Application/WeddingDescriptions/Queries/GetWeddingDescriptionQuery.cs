using AutoMapper;
using AutoMapper.QueryableExtensions;
using CleanArchitecture.Application.Common.Interfaces;
using CleanArchitecture.Application.Common.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace CleanArchitecture.Application.WeddingDescriptions.Queries
{
    public class GetWeddingDescriptionQuery : BaseGet, IRequest<IEnumerable<WeddingDescriptionDto>>
    {
        public long Id { get; set; }
        public string GroomDescription { get; set; }
        public string BrideDescription { get; set; }
        public string CeremonyDateTimeLocation { get; set; }
        public string CeremonyDescription { get; set; }
        public string ReceptionDateTimeLocation { get; set; }
        public string ReceptionDescription { get; set; }

        public class GetWeddingDescriptionQueryHandler : IRequestHandler<GetWeddingDescriptionQuery, IEnumerable<WeddingDescriptionDto>>
        {
            private readonly IApplicationDbContext _context;
            private readonly IMapper _mapper;

            public GetWeddingDescriptionQueryHandler(IApplicationDbContext context, IMapper mapper)
            {
                _context = context;
                _mapper = mapper;
            }

            public async Task<IEnumerable<WeddingDescriptionDto>> Handle(GetWeddingDescriptionQuery req, CancellationToken cancellationToken)
            {
                var ret = new List<WeddingDescriptionDto>();
                var query = _context.WeddingDescriptions.AsQueryable().AsNoTracking();

                if (req.Id != 0) 
                {
                    query = query.Where(q => q.Id == req.Id);
                }

                if (req.GroomDescription != null)
                {
                    query = query.Where(q => q.GroomDescription == req.GroomDescription);
                }

                if (req.BrideDescription != null)
                {
                    query = query.Where(q => q.BrideDescription == req.BrideDescription);
                }

                if (req.CeremonyDateTimeLocation != null)
                {
                    query = query.Where(q => q.CeremonyDateTimeLocation == req.CeremonyDateTimeLocation);
                }

                if (req.CeremonyDescription != null)
                {
                    query = query.Where(q => q.CeremonyDescription == req.CeremonyDescription);
                }

                if (req.ReceptionDateTimeLocation != null)
                {
                    query = query.Where(q => q.ReceptionDateTimeLocation == req.ReceptionDateTimeLocation);
                }

                if (req.ReceptionDescription != null)
                {
                    query = query.Where(q => q.ReceptionDescription == req.ReceptionDescription);
                }

                ret = await query.ProjectTo<WeddingDescriptionDto>(_mapper.ConfigurationProvider).ToListAsync(cancellationToken);

                return ret;
            }
        }
    }
}
