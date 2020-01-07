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

namespace CleanArchitecture.Application.EmailLogs.Queries
{
    public class GetEmailLogQuery : BaseGet, IRequest<IEnumerable<EmailLogDto>>
    {
        public long Id { get; set; }
        public int EmailId { get; set; }
        public DateTime SentDate { get; set; }
        public string SentBy { get; set; }

        public class GetEmailLogQueryHandler : IRequestHandler<GetEmailLogQuery, IEnumerable<EmailLogDto>>
        {
            private readonly IApplicationDbContext _context;
            private readonly IMapper _mapper;

            public GetEmailLogQueryHandler(IApplicationDbContext context, IMapper mapper)
            {
                _context = context;
                _mapper = mapper;
            }

            public async Task<IEnumerable<EmailLogDto>> Handle(GetEmailLogQuery req, CancellationToken cancellationToken)
            {
                var ret = new List<EmailLogDto>();
                var query = _context.EmailLogs.AsQueryable().AsNoTracking();

                if (req.Id != 0)
                {
                    query = query.Where(q => q.Id == req.Id);
                }

                if (req.EmailId != 0)
                {
                    query = query.Where(q => q.EmailId == req.EmailId);
                }

                if (req.SentDate != null)
                {
                    query = query.Where(q => q.SentDate == req.SentDate);
                }

                if (req.SentBy != null)
                {
                    query = query.Where(q => q.SentBy == req.SentBy);
                }

                ret = await query.ProjectTo<EmailLogDto>(_mapper.ConfigurationProvider).ToListAsync(cancellationToken);

                return ret;
            }
        }
    }
}
