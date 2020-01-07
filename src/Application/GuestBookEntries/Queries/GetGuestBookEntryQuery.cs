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

namespace CleanArchitecture.Application.GuestBookEntries.Queries
{
    public class GetGuestBookEntryQuery : BaseGet, IRequest<IEnumerable<GuestBookEntryDto>>
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string Entry { get; set; }
        public bool? Approved { get; set; }
        public DateTime? ApprovedOn { get; set; }

        public class GetGuestBookEntryQueryHandler : IRequestHandler<GetGuestBookEntryQuery, IEnumerable<GuestBookEntryDto>>
        {
            private readonly IApplicationDbContext _context;
            private readonly IMapper _mapper;

            public GetGuestBookEntryQueryHandler(IApplicationDbContext context, IMapper mapper)
            {
                _context = context;
                _mapper = mapper;
            }

            public async Task<IEnumerable<GuestBookEntryDto>> Handle(GetGuestBookEntryQuery req, CancellationToken cancellationToken)
            {
                var ret = new List<GuestBookEntryDto>();
                var query = _context.GuestBookEntries.AsQueryable().AsNoTracking();

                if (req.Id != 0)
                {
                    query = query.Where(q => q.Id == req.Id);
                }

                if (req.Name != null)
                {
                    query = query.Where(q => q.Name == req.Name);
                }

                if (req.Approved != null)
                {
                    query = query.Where(q => q.Approved == req.Approved);
                }

                if (req.ApprovedOn != null)
                {
                    query = query.Where(q => q.ApprovedOn == req.ApprovedOn);
                }

                ret = await query.ProjectTo<GuestBookEntryDto>(_mapper.ConfigurationProvider).ToListAsync(cancellationToken);

                return ret;
            }
        }
    }
}