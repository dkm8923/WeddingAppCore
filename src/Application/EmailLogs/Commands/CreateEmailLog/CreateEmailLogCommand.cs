using CleanArchitecture.Application.Common.Interfaces;
using CleanArchitecture.Domain.Entities;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace CleanArchitecture.Application.EmailLogs.Commands.CreateEmailLog
{
    public class CreateEmailLogCommand : IRequest<long>
    {
        public int EmailId { get; set; }
        public DateTime SentDate { get; set; }
        public string SentBy { get; set; }

        public class CreateEmailLogCommandHandler : IRequestHandler<CreateEmailLogCommand, long>
        {
            private readonly IApplicationDbContext _context;

            public CreateEmailLogCommandHandler(IApplicationDbContext context)
            {
                _context = context;
            }

            public async Task<long> Handle(CreateEmailLogCommand request, CancellationToken cancellationToken)
            {
                var entity = new EmailLog
                {
                    EmailId = request.EmailId,
                    SentDate = request.SentDate,
                    SentBy = request.SentBy
                };

                _context.EmailLogs.Add(entity);

                await _context.SaveChangesAsync(cancellationToken);

                return entity.Id;
            }
        }
    }
}
