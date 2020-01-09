using CleanArchitecture.Application.Common.Exceptions;
using CleanArchitecture.Application.Common.Interfaces;
using CleanArchitecture.Domain.Entities;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace CleanArchitecture.Application.EmailLogs.Commands.DeleteEmailLog
{
    public class DeleteEmailLogCommand : IRequest
    {
        public long Id { get; set; }

        public class DeleteEmailLogCommandHandler : IRequestHandler<DeleteEmailLogCommand>
        {
            private readonly IApplicationDbContext _context;

            public DeleteEmailLogCommandHandler(IApplicationDbContext context)
            {
                _context = context;
            }

            public async Task<Unit> Handle(DeleteEmailLogCommand request, CancellationToken cancellationToken)
            {
                var entity = await _context.EmailLogs.FindAsync(request.Id);

                if (entity == null)
                {
                    throw new NotFoundException(nameof(EmailLog), request.Id);
                }

                _context.EmailLogs.Remove(entity);

                await _context.SaveChangesAsync(cancellationToken);

                return Unit.Value;
            }
        }
    }
}