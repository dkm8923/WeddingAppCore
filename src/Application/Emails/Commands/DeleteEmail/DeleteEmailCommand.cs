using CleanArchitecture.Application.Common.Exceptions;
using CleanArchitecture.Application.Common.Interfaces;
using CleanArchitecture.Domain.Entities;
using MediatR;
using System.Threading;
using System.Threading.Tasks;


namespace CleanArchitecture.Application.Emails.Commands.DeleteEmail
{
    public class DeleteEmailCommand : IRequest
    {
        public long Id { get; set; }

        public class DeleteEmailCommandHandler : IRequestHandler<DeleteEmailCommand>
        {
            private readonly IApplicationDbContext _context;

            public DeleteEmailCommandHandler(IApplicationDbContext context)
            {
                _context = context;
            }

            public async Task<Unit> Handle(DeleteEmailCommand request, CancellationToken cancellationToken)
            {
                var entity = await _context.Emails.FindAsync(request.Id);

                if (entity == null)
                {
                    throw new NotFoundException(nameof(Email), request.Id);
                }

                _context.Emails.Remove(entity);

                await _context.SaveChangesAsync(cancellationToken);

                return Unit.Value;
            }
        }
    }
}
