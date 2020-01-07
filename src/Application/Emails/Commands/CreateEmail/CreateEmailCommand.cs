using CleanArchitecture.Application.Common.Exceptions;
using CleanArchitecture.Application.Common.Interfaces;
using CleanArchitecture.Domain.Entities;
using MediatR;
using System.Threading;
using System.Threading.Tasks;


namespace CleanArchitecture.Application.Email.Commands.CreateEmail
{
    public class CreateEmailCommand : IRequest
    {
        public long Id { get; set; }
        public string Description { get; set; }
        public string Subject { get; set; }
        public string Body { get; set; }

        public class CreateEmailCommandHandler : IRequestHandler<CreateEmailCommand>
        {
            private readonly IApplicationDbContext _context;

            public CreateEmailCommandHandler(IApplicationDbContext context)
            {
                _context = context;
            }

            public async Task<Unit> Handle(CreateEmailCommand request, CancellationToken cancellationToken)
            {
                var entity = await _context.Emails.FindAsync(request.Id);

                if (entity == null)
                {
                    throw new NotFoundException(nameof(TodoItem), request.Id);
                }

                _context.Emails.Remove(entity);

                await _context.SaveChangesAsync(cancellationToken);

                return Unit.Value;
            }
        }
    }
}
