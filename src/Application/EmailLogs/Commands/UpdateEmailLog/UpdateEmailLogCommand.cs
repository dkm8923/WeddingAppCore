using CleanArchitecture.Application.Common.Exceptions;
using CleanArchitecture.Application.Common.Interfaces;
using CleanArchitecture.Domain.Entities;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace CleanArchitecture.Application.EmailLogs.Commands.UpdateEmailLog
{
    public class UpdateEmailLogCommand : IRequest
    {
        public long Id { get; set; }
        public int EmailId { get; set; }
        public DateTime SentDate { get; set; }
        public string SentBy { get; set; }

        public class UpdateEmailLogCommandHandler : IRequestHandler<UpdateEmailLogCommand>
        {
            private readonly IApplicationDbContext _context;

            public UpdateEmailLogCommandHandler(IApplicationDbContext context)
            {
                _context = context;
            }

            public async Task<Unit> Handle(UpdateEmailLogCommand request, CancellationToken cancellationToken)
            {
                var entity = await _context.EmailLogs.FindAsync(request.Id);

                if (entity == null)
                {
                    throw new NotFoundException(nameof(EmailLog), request.Id);
                }

                entity.EmailId = request.EmailId;
                entity.SentDate = request.SentDate;
                entity.SentBy = request.SentBy;

                await _context.SaveChangesAsync(cancellationToken);

                return Unit.Value;
            }
        }
    }
}
