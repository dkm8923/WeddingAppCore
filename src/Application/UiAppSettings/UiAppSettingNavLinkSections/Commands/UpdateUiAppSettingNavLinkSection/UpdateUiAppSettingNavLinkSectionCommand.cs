using CleanArchitecture.Application.Common.Exceptions;
using CleanArchitecture.Application.Common.Interfaces;
using CleanArchitecture.Domain.Entities.UiAppSettings;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
namespace CleanArchitecture.Application.UiAppSettings.UiAppSettingNavLinkSections.Commands.UpdateUiAppSettingNavLinkSection
{
    public class UpdateUiAppSettingNavLinkSectionCommand : IRequest
    {
        public long Id { get; set; }
        public long ApplicationId { get; set; }
        public string Text { get; set; }
        public string FontAwesomeCss { get; set; }
        public string BadgeText { get; set; }

        public class UpdateUiAppSettingNavLinkSectionCommandHandler : IRequestHandler<UpdateUiAppSettingNavLinkSectionCommand>
        {
            private readonly IApplicationDbContext _context;

            public UpdateUiAppSettingNavLinkSectionCommandHandler(IApplicationDbContext context)
            {
                _context = context;
            }

            public async Task<Unit> Handle(UpdateUiAppSettingNavLinkSectionCommand request, CancellationToken cancellationToken)
            {
                var entity = await _context.UiAppSettingNavLinkSections.FindAsync(request.Id);

                if (entity == null)
                {
                    throw new NotFoundException(nameof(UiAppSettingNavLinkSection), request.Id);
                }

                entity.ApplicationId = request.ApplicationId;
                entity.Text = request.Text;
                entity.FontAwesomeCss = request.FontAwesomeCss;
                entity.BadgeText = request.BadgeText;

                await _context.SaveChangesAsync(cancellationToken);

                return Unit.Value;
            }
        }
    }
}
