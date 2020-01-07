using CleanArchitecture.Application.Common.Interfaces;
using CleanArchitecture.Domain.Entities;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace CleanArchitecture.Application.UsaStates.Commands.CreateUsaState
{
    public class CreateUsaStateCommand : IRequest<long>
    {
        public string Name { get; set; }
        public string AbbreviatedName { get; set; }

        public class CreateUsaStateCommandHandler : IRequestHandler<CreateUsaStateCommand, long>
        {
            private readonly IApplicationDbContext _context;

            public CreateUsaStateCommandHandler(IApplicationDbContext context)
            {
                _context = context;
            }

            public async Task<long> Handle(CreateUsaStateCommand request, CancellationToken cancellationToken)
            {
                var entity = new UsaState
                {
                    Name = request.Name,
                    AbbreviatedName = request.AbbreviatedName
                };

                _context.UsaStates.Add(entity);

                await _context.SaveChangesAsync(cancellationToken);

                return entity.Id;
            }
        }
    }
}