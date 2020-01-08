using CleanArchitecture.Application.Common.Exceptions;
using CleanArchitecture.Application.Common.Interfaces;
using CleanArchitecture.Domain.Entities;
using MediatR;
using System.Threading;
using System.Threading.Tasks;


namespace CleanArchitecture.Application.Emails.Commands.CreateEmail
{
    public class CreateEmailCommand : IRequest<long>
    {
        public string Description { get; set; }
        public string Subject { get; set; }
        public string Body { get; set; }

        public class CreateEmailCommandHandler : IRequestHandler<CreateEmailCommand, long>
        {
            private readonly IApplicationDbContext _context;

            public CreateEmailCommandHandler(IApplicationDbContext context)
            {
                _context = context;
            }

            public async Task<long> Handle(CreateEmailCommand request, CancellationToken cancellationToken)
            {
                var entity = new Email
                {
                    Description = request.Description,
                    Subject = request.Subject,
                    Body = request.Body
                };

                _context.Emails.Add(entity);

                await _context.SaveChangesAsync(cancellationToken);

                return entity.Id;
            }
        }
    }
}
