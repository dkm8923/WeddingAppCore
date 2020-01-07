using CleanArchitecture.Application.Common.Interfaces;
using CleanArchitecture.Domain.Entities;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace CleanArchitecture.Application.Guests.Commands.CreateGuest
{
    public class CreateGuestCommand : IRequest<long>
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }

        public class CreateGuestCommandHandler : IRequestHandler<CreateGuestCommand, long>
        {
            private readonly IApplicationDbContext _context;

            public CreateGuestCommandHandler(IApplicationDbContext context)
            {
                _context = context;
            }

            public async Task<long> Handle(CreateGuestCommand request, CancellationToken cancellationToken)
            {
                var entity = new Guest
                {
                    FirstName = request.FirstName,
                    LastName = request.LastName,
                    Email = request.Email
                };

                _context.Guests.Add(entity);

                await _context.SaveChangesAsync(cancellationToken);

                return entity.Id;
            }
        }
    }
}
