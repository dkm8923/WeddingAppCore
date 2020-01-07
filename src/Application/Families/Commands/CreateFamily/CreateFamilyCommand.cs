using CleanArchitecture.Application.Common.Interfaces;
using CleanArchitecture.Domain.Entities;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace CleanArchitecture.Application.Families.Commands.CreateFamily
{
    public class CreateFamilyCommand : IRequest<long>
    {
        public long GuestId { get; set; }
        public string ConfirmationCode { get; set; }
        public string Address1 { get; set; }
        public string Address2 { get; set; }
        public string City { get; set; }
        public long StateId { get; set; }
        public string Zip { get; set; }

        public class CreateFamilyCommandHandler : IRequestHandler<CreateFamilyCommand, long>
        {
            private readonly IApplicationDbContext _context;

            public CreateFamilyCommandHandler(IApplicationDbContext context)
            {
                _context = context;
            }

            public async Task<long> Handle(CreateFamilyCommand request, CancellationToken cancellationToken)
            {
                var entity = new Family
                {
                    GuestId = request.GuestId,
                    ConfirmationCode = request.ConfirmationCode,
                    Address1 = request.Address1,
                    Address2 = request.Address2,
                    City = request.City,
                    StateId = request.StateId,
                    Zip = request.Zip
                };

                _context.Families.Add(entity);

                await _context.SaveChangesAsync(cancellationToken);

                return entity.Id;
            }
        }
    }
}
