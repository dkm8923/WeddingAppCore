using CleanArchitecture.Application.Common.Exceptions;
using CleanArchitecture.Application.Common.Interfaces;
using CleanArchitecture.Domain.Entities.UiAppSettings;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace CleanArchitecture.Application.UiAppSettings.UiAppSettingNavLinkSections.Commands.DeleteUiAppSettingNavLinkSection
{
    public class DeleteUiAppSettingNavLinkSectionCommand : IRequest
    {
        public long Id { get; set; }

        public class DeleteUiAppSettingNavLinkSectionCommandHandler : IRequestHandler<DeleteUiAppSettingNavLinkSectionCommand>
        {
            private readonly IApplicationDbContext _context;

            public DeleteUiAppSettingNavLinkSectionCommandHandler(IApplicationDbContext context)
            {
                _context = context;
            }

            public async Task<Unit> Handle(DeleteUiAppSettingNavLinkSectionCommand request, CancellationToken cancellationToken)
            {
                var entity = await _context.UiAppSettingNavLinkSections.FindAsync(request.Id);

                if (entity == null)
                {
                    throw new NotFoundException(nameof(UiAppSettingNavLinkSection), request.Id);
                }

                _context.UiAppSettingNavLinkSections.Remove(entity);

                await _context.SaveChangesAsync(cancellationToken);

                return Unit.Value;
            }
        }
    }
}
