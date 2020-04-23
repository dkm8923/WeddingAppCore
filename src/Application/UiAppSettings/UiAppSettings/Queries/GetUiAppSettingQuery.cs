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

namespace CleanArchitecture.Application.UiAppSettings.Queries
{
    public class GetUiAppSettingQuery : BaseGet, IRequest<IEnumerable<UiAppSettingDto>>
    {
        public long Id { get; set; }
        public long ApplicationId { get; set; }
        public long ReferenceTypeId { get; set; }

        public class GetUiAppSettingQueryHandler : IRequestHandler<GetUiAppSettingQuery, IEnumerable<UiAppSettingDto>>
        {
            private readonly IApplicationDbContext _context;
            private readonly IMapper _mapper;

            public GetUiAppSettingQueryHandler(IApplicationDbContext context, IMapper mapper)
            {
                _context = context;
                _mapper = mapper;
            }

            public async Task<IEnumerable<UiAppSettingDto>> Handle(GetUiAppSettingQuery req, CancellationToken cancellationToken)
            {
                var ret = new List<UiAppSettingDto>();
                var query = _context.UiAppSettings.AsQueryable().AsNoTracking();

                if (req.Id != 0)
                {
                    query = query.Where(q => q.Id == req.Id);
                }

                if (req.ApplicationId != 0)
                {
                    query = query.Where(q => q.ApplicationId == req.ApplicationId);
                }

                if (req.ReferenceTypeId != 0)
                {
                    query = query.Where(q => q.ReferenceTypeId == req.ReferenceTypeId);
                }

                ret = await query.ProjectTo<UiAppSettingDto>(_mapper.ConfigurationProvider).ToListAsync(cancellationToken);

                return ret;
            }
        }
    }
}
