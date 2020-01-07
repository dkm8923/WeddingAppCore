using AutoMapper;
using AutoMapper.QueryableExtensions;
using System;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using CleanArchitecture.Application.Common.Models;
using CleanArchitecture.Application.Common.Interfaces;
namespace CleanArchitecture.Application.Families.Queries
{
    public class GetFamilyQuery : BaseGet, IRequest<IEnumerable<FamilyDto>>
    {
        public long Id { get; set; }
        public string ConfirmationCode { get; set; }
        public string Address1 { get; set; }
        public string Address2 { get; set; }
        public string City { get; set; }
        public long StateId { get; set; }
        public string Zip { get; set; }
        public bool? Attending { get; set; }

        public class GetFamilyQueryHandler : IRequestHandler<GetFamilyQuery, IEnumerable<FamilyDto>>
        {
            private readonly IApplicationDbContext _context;
            private readonly IMapper _mapper;

            public GetFamilyQueryHandler(IApplicationDbContext context, IMapper mapper)
            {
                _context = context;
                _mapper = mapper;
            }

            public async Task<IEnumerable<FamilyDto>> Handle(GetFamilyQuery req, CancellationToken cancellationToken)
            {
                var ret = new List<FamilyDto>();
                var query = _context.Families.AsQueryable().AsNoTracking();

                if (req.Id != 0)
                {
                    query = query.Where(q => q.Id == req.Id);
                }

                if (req.ConfirmationCode != null)
                {
                    query = query.Where(q => q.ConfirmationCode == req.ConfirmationCode);
                }

                if (req.Address1 != null)
                {
                    query = query.Where(q => q.Address1 == req.Address1);
                }

                if (req.Address2 != null)
                {
                    query = query.Where(q => q.Address2 == req.Address2);
                }

                if (req.City != null)
                {
                    query = query.Where(q => q.City == req.City);
                }

                if (req.StateId != 0)
                {
                    query = query.Where(q => q.StateId == req.StateId);
                }

                if (req.Zip != null)
                {
                    query = query.Where(q => q.Zip == req.Zip);
                }

                if (req.Attending != null)
                {
                    query = query.Where(q => q.Attending == req.Attending);
                }

                ret = await query.ProjectTo<FamilyDto>(_mapper.ConfigurationProvider).ToListAsync(cancellationToken);

                return ret;
            }
        }
    }
}
