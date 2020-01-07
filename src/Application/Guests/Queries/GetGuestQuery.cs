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

namespace CleanArchitecture.Application.Guests.Queries
{
    public class GetGuestQuery : BaseGet, IRequest<IEnumerable<GuestDto>>
    {
        public long Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }

        public class GetGuestQueryHandler : IRequestHandler<GetGuestQuery, IEnumerable<GuestDto>>
        {
            private readonly IApplicationDbContext _context;
            private readonly IMapper _mapper;

            public GetGuestQueryHandler(IApplicationDbContext context, IMapper mapper)
            {
                _context = context;
                _mapper = mapper;
            }

            public async Task<IEnumerable<GuestDto>> Handle(GetGuestQuery req, CancellationToken cancellationToken)
            {
                var ret = new List<GuestDto>();
                var query = _context.Guests.AsQueryable().AsNoTracking();

                if (req.Id != 0)
                {
                    query = query.Where(q => q.Id == req.Id);
                }

                if (req.FirstName != null)
                {
                    query = query.Where(q => q.FirstName == req.FirstName);
                }

                if (req.LastName != null)
                {
                    query = query.Where(q => q.LastName == req.LastName);
                }

                if (req.Email != null)
                {
                    query = query.Where(q => q.Email == req.Email);
                }

                ret = await query.ProjectTo<GuestDto>(_mapper.ConfigurationProvider).ToListAsync(cancellationToken);

                return ret;
            }
        }
    }
}