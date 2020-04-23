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
using CleanArchitecture.Application.UiAppSettings.UiAppSettingApplications.Queries;

namespace CleanArchitecture.Application.UiAppSettingApplications.Queries
{
    public class GetUiAppSettingApplicationQuery : BaseGet, IRequest<IEnumerable<UiAppSettingApplicationDto>>
    {
        public long Id { get; set; }
        public string Name { get; set; }
        
        public class GetUiAppSettingApplicationQueryHandler : IRequestHandler<GetUiAppSettingApplicationQuery, IEnumerable<UiAppSettingApplicationDto>>
        {
            private readonly IApplicationDbContext _context;
            private readonly IMapper _mapper;

            public GetUiAppSettingApplicationQueryHandler(IApplicationDbContext context, IMapper mapper)
            {
                _context = context;
                _mapper = mapper;
            }

            public async Task<IEnumerable<UiAppSettingApplicationDto>> Handle(GetUiAppSettingApplicationQuery req, CancellationToken cancellationToken)
            {
                var ret = new List<UiAppSettingApplicationDto>();
                var query = _context.UiAppSettingApplications.AsQueryable().AsNoTracking();

                if (req.Id != 0)
                {
                    query = query.Where(q => q.Id == req.Id);
                }

                if (req.Name != null)
                {
                    query = query.Where(q => q.Name == req.Name);
                }

                ret = await query.ProjectTo<UiAppSettingApplicationDto>(_mapper.ConfigurationProvider).ToListAsync(cancellationToken);

                return ret;
            }
        }
    }
}
