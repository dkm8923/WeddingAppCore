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

namespace CleanArchitecture.Application.UiAppSettings.UiAppSettingNavLinks.Queries
{
    public class GetUiAppSettingNavLinkQuery : BaseGet, IRequest<IEnumerable<UiAppSettingNavLinkDto>>
    {
        public long Id { get; set; }
        public long? ApplicationId { get; set; }
        public long? NavLinkSectionId { get; set; }

        public class GetUiAppSettingNavLinkQueryHandler : IRequestHandler<GetUiAppSettingNavLinkQuery, IEnumerable<UiAppSettingNavLinkDto>>
        {
            private readonly IApplicationDbContext _context;
            private readonly IMapper _mapper;

            public GetUiAppSettingNavLinkQueryHandler(IApplicationDbContext context, IMapper mapper)
            {
                _context = context;
                _mapper = mapper;
            }

            public async Task<IEnumerable<UiAppSettingNavLinkDto>> Handle(GetUiAppSettingNavLinkQuery req, CancellationToken cancellationToken)
            {
                var ret = new List<UiAppSettingNavLinkDto>();
                var query = _context.UiAppSettingNavLinks.AsQueryable().AsNoTracking();

                if (req.Id != 0)
                {
                    query = query.Where(q => q.Id == req.Id);
                }

                if (req.ApplicationId != null && req.ApplicationId != 0)
                {
                    query = query.Where(q => q.ApplicationId == req.ApplicationId);
                }

                if (req.NavLinkSectionId != null && req.NavLinkSectionId != 0)
                {
                    query = query.Where(q => q.NavLinkSectionId == req.NavLinkSectionId);
                }

                ret = await query.ProjectTo<UiAppSettingNavLinkDto>(_mapper.ConfigurationProvider).ToListAsync(cancellationToken);

                return ret;
            }
        }
    }
}
