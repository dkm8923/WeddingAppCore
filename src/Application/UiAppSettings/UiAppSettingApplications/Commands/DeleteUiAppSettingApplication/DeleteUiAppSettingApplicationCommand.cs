using CleanArchitecture.Application.Common.Exceptions;
using CleanArchitecture.Application.Common.Interfaces;
using CleanArchitecture.Domain.Entities.UiAppSettings;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace CleanArchitecture.Application.UiAppSettingApplications.Commands.DeleteUiAppSettingApplication
{
    public class DeleteUiAppSettingApplicationCommand : IRequest
    {
        public long Id { get; set; }

        public class DeleteUiAppSettingApplicationCommandHandler : IRequestHandler<DeleteUiAppSettingApplicationCommand>
        {
            private readonly IApplicationDbContext _context;

            public DeleteUiAppSettingApplicationCommandHandler(IApplicationDbContext context)
            {
                _context = context;
            }

            public async Task<Unit> Handle(DeleteUiAppSettingApplicationCommand request, CancellationToken cancellationToken)
            {
                var entity = await _context.UiAppSettingApplications.FindAsync(request.Id);

                if (entity == null)
                {
                    throw new NotFoundException(nameof(UiAppSettingApplication), request.Id);
                }

                _context.UiAppSettingApplications.Remove(entity);

                await _context.SaveChangesAsync(cancellationToken);

                return Unit.Value;
            }
        }
    }
}
