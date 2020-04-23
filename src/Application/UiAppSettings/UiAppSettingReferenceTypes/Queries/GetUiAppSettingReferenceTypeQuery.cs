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

namespace CleanArchitecture.Application.UiAppSettingReferenceTypes.Queries
{
    public class GetUiAppSettingReferenceTypeQuery : BaseGet, IRequest<IEnumerable<UiAppSettingReferenceTypeDto>>
    {
        public long Id { get; set; }
        public string Name { get; set; }
        
        public class GetUiAppSettingReferenceTypeQueryHandler : IRequestHandler<GetUiAppSettingReferenceTypeQuery, IEnumerable<UiAppSettingReferenceTypeDto>>
        {
            private readonly IApplicationDbContext _context;
            private readonly IMapper _mapper;

            public GetUiAppSettingReferenceTypeQueryHandler(IApplicationDbContext context, IMapper mapper)
            {
                _context = context;
                _mapper = mapper;
            }

            public async Task<IEnumerable<UiAppSettingReferenceTypeDto>> Handle(GetUiAppSettingReferenceTypeQuery req, CancellationToken cancellationToken)
            {
                var ret = new List<UiAppSettingReferenceTypeDto>();
                var query = _context.UiAppSettingReferenceTypes.AsQueryable().AsNoTracking();

                if (req.Id != 0)
                {
                    query = query.Where(q => q.Id == req.Id);
                }

                if (req.Name != null)
                {
                    query = query.Where(q => q.Name == req.Name);
                }

                ret = await query.ProjectTo<UiAppSettingReferenceTypeDto>(_mapper.ConfigurationProvider).ToListAsync(cancellationToken);

                return ret;
            }
        }
    }
}
