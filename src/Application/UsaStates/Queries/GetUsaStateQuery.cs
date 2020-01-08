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

namespace CleanArchitecture.Application.UsaStates.Queries
{
    public class GetUsaStateQuery : BaseGet, IRequest<IEnumerable<UsaStateDto>>
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string AbbreviatedName { get; set; }

        public class GetUsaStateQueryHandler : IRequestHandler<GetUsaStateQuery, IEnumerable<UsaStateDto>>
        {
            private readonly IApplicationDbContext _context;
            private readonly IMapper _mapper;

            public GetUsaStateQueryHandler(IApplicationDbContext context, IMapper mapper)
            {
                _context = context;
                _mapper = mapper;
            }

            public async Task<IEnumerable<UsaStateDto>> Handle(GetUsaStateQuery req, CancellationToken cancellationToken)
            {
                var ret = new List<UsaStateDto>();
                var query = _context.UsaStates.AsQueryable().AsNoTracking();

                if (req.Id != 0)
                {
                    query = query.Where(q => q.Id == req.Id);
                }

                if (req.Name != null)
                {
                    query = query.Where(q => q.Name == req.Name);
                }

                if (req.AbbreviatedName != null)
                {
                    query = query.Where(q => q.AbbreviatedName == req.AbbreviatedName);
                }

                ret = await query.ProjectTo<UsaStateDto>(_mapper.ConfigurationProvider).ToListAsync(cancellationToken);

                return ret;
            }
        }
    }
}
