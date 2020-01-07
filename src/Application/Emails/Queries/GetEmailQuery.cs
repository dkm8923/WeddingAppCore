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

namespace CleanArchitecture.Application.Emails.Queries
{
    public class GetEmailQuery : BaseGet, IRequest<IEnumerable<EmailDto>>
    {
        public long Id { get; set; }
        public string Description { get; set; }
        public string Subject { get; set; }
        public string Body { get; set; }

        public class GetEmailQueryHandler : IRequestHandler<GetEmailQuery, IEnumerable<EmailDto>>
        {
            private readonly IApplicationDbContext _context;
            private readonly IMapper _mapper;

            public GetEmailQueryHandler(IApplicationDbContext context, IMapper mapper)
            {
                _context = context;
                _mapper = mapper;
            }

            public async Task<IEnumerable<EmailDto>> Handle(GetEmailQuery req, CancellationToken cancellationToken)
            {
                var ret = new List<EmailDto>();
                var query = _context.Emails.AsQueryable().AsNoTracking();

                if (req.Id != 0)
                {
                    query = query.Where(q => q.Id == req.Id);
                }

                if (req.Description != null)
                {
                    query = query.Where(q => q.Description == req.Description);
                }

                if (req.Subject != null)
                {
                    query = query.Where(q => q.Subject == req.Subject);
                }

                if (req.Body != null)
                {
                    query = query.Where(q => q.Body == req.Body);
                }

                ret = await query.ProjectTo<EmailDto>(_mapper.ConfigurationProvider).ToListAsync(cancellationToken);

                return ret;
            }
        }
    }
}
