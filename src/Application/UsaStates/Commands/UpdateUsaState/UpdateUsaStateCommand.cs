using CleanArchitecture.Application.Common.Exceptions;
using CleanArchitecture.Application.Common.Interfaces;
using CleanArchitecture.Domain.Entities;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace CleanArchitecture.Application.UsaStates.Commands.UpdateUsaState
{
    public class UpdateUsaStateCommand : IRequest
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string AbbreviatedName { get; set; }

        public class UpdateUsaStateCommandHandler : IRequestHandler<UpdateUsaStateCommand>
        {
            private readonly IApplicationDbContext _context;

            public UpdateUsaStateCommandHandler(IApplicationDbContext context)
            {
                _context = context;
            }

            public async Task<Unit> Handle(UpdateUsaStateCommand request, CancellationToken cancellationToken)
            {
                var entity = await _context.UsaStates.FindAsync(request.Id);

                if (entity == null)
                {
                    throw new NotFoundException(nameof(UsaState), request.Id);
                }

                entity.Name = request.Name;
                entity.AbbreviatedName = request.AbbreviatedName;
                
                await _context.SaveChangesAsync(cancellationToken);

                return Unit.Value;
            }
        }
    }
}
