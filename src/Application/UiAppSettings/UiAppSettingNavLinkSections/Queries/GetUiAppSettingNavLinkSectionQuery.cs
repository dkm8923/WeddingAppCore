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

namespace CleanArchitecture.Application.UiAppSettings.UiAppSettingNavLinkSections.Queries
{
    public class GetUiAppSettingNavLinkSectionQuery : BaseGet, IRequest<IEnumerable<UiAppSettingNavLinkSectionDto>>
    {
        public long Id { get; set; }
        public long? ApplicationId { get; set; }
        
        public class GetUiAppSettingNavLinkSectionQueryHandler : IRequestHandler<GetUiAppSettingNavLinkSectionQuery, IEnumerable<UiAppSettingNavLinkSectionDto>>
        {
            private readonly IApplicationDbContext _context;
            private readonly IMapper _mapper;

            public GetUiAppSettingNavLinkSectionQueryHandler(IApplicationDbContext context, IMapper mapper)
            {
                _context = context;
                _mapper = mapper;
            }

            public async Task<IEnumerable<UiAppSettingNavLinkSectionDto>> Handle(GetUiAppSettingNavLinkSectionQuery req, CancellationToken cancellationToken)
            {
                var ret = new List<UiAppSettingNavLinkSectionDto>();
                var query = _context.UiAppSettingNavLinkSections.AsQueryable().AsNoTracking();

                if (req.Id != 0)
                {
                    query = query.Where(q => q.Id == req.Id);
                }

                if (req.ApplicationId != null && req.ApplicationId != 0)
                {
                    query = query.Where(q => q.ApplicationId == req.ApplicationId);
                }

                ret = await query.ProjectTo<UiAppSettingNavLinkSectionDto>(_mapper.ConfigurationProvider).ToListAsync(cancellationToken);

                return ret;
            }
        }
    }
}
