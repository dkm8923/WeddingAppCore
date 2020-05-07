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

namespace CleanArchitecture.Application.UiAppSettings.UiAppSettingFooters.Queries
{
    public class GetUiAppSettingFooterQuery : BaseGet, IRequest<IEnumerable<UiAppSettingFooterDto>>
    {
        public long Id { get; set; }
        public long? ApplicationId { get; set; }

        public class GetUiAppSettingFooterQueryHandler : IRequestHandler<GetUiAppSettingFooterQuery, IEnumerable<UiAppSettingFooterDto>>
        {
            private readonly IApplicationDbContext _context;
            private readonly IMapper _mapper;

            public GetUiAppSettingFooterQueryHandler(IApplicationDbContext context, IMapper mapper)
            {
                _context = context;
                _mapper = mapper;
            }

            public async Task<IEnumerable<UiAppSettingFooterDto>> Handle(GetUiAppSettingFooterQuery req, CancellationToken cancellationToken)
            {
                var ret = new List<UiAppSettingFooterDto>();
                var query = _context.UiAppSettingFooters.AsQueryable().AsNoTracking();

                if (req.Id != 0)
                {
                    query = query.Where(q => q.Id == req.Id);
                }

                if (req.ApplicationId != null && req.ApplicationId != 0)
                {
                    query = query.Where(q => q.ApplicationId == req.ApplicationId);
                }

                ret = await query.ProjectTo<UiAppSettingFooterDto>(_mapper.ConfigurationProvider).ToListAsync(cancellationToken);

                return ret;
            }
        }
    }
}
