using CleanArchitecture.Application.Common.Exceptions;
using CleanArchitecture.Application.Common.Interfaces;
using CleanArchitecture.Domain.Entities;
using MediatR;
using System.Threading;
using System.Threading.Tasks;



namespace CleanArchitecture.Application.Email.Commands.UpdateEmail
{
    public class UpdateEmailCommand : IRequest
    {
        public long Id { get; set; }
        public string Description { get; set; }
        public string Subject { get; set; }
        public string Body { get; set; }

        public class UpdateEmailCommandHandler : IRequestHandler<UpdateEmailCommand>
        {
            private readonly IApplicationDbContext _context;

            public UpdateEmailCommandHandler(IApplicationDbContext context)
            {
                _context = context;
            }

            public async Task<Unit> Handle(UpdateEmailCommand request, CancellationToken cancellationToken)
            {
                var entity = await _context.Emails.FindAsync(request.Id);

                if (entity == null)
                {
                    throw new NotFoundException(nameof(Email), request.Id);
                }

                entity.Description = request.Description;
                entity.Subject = request.Subject;
                entity.Body = request.Body;
                
                await _context.SaveChangesAsync(cancellationToken);

                return Unit.Value;
            }
        }
    }
}
