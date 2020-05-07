using CleanArchitecture.Application.Common.Exceptions;
using CleanArchitecture.Application.Common.Interfaces;
using CleanArchitecture.Domain.Entities;
using CleanArchitecture.Domain.Entities.UiAppSettings;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
namespace CleanArchitecture.Application.UiAppSettings.UiAppSettingNavLinks.Commands.UpdateUiAppSettingNavLink
{
    public class UpdateUiAppSettingNavLinkCommand : IRequest
    {
        public long Id { get; set; }
        public long ApplicationId { get; set; }
        public long? NavLinkSectionId { get; set; }
        public string Text { get; set; }
        public string FontAwesomeCss { get; set; }
        public string Url { get; set; }
        public string BadgeText { get; set; }

        public class UpdateUiAppSettingNavLinkCommandHandler : IRequestHandler<UpdateUiAppSettingNavLinkCommand>
        {
            private readonly IApplicationDbContext _context;

            public UpdateUiAppSettingNavLinkCommandHandler(IApplicationDbContext context)
            {
                _context = context;
            }

            public async Task<Unit> Handle(UpdateUiAppSettingNavLinkCommand request, CancellationToken cancellationToken)
            {
                var entity = await _context.UiAppSettingNavLinks.FindAsync(request.Id);

                if (entity == null)
                {
                    throw new NotFoundException(nameof(UiAppSettingNavLink), request.Id);
                }

                entity.ApplicationId = request.ApplicationId;
                entity.ApplicationId = request.ApplicationId;
                entity.NavLinkSectionId = request.NavLinkSectionId;
                entity.Text = request.Text;
                entity.FontAwesomeCss = request.FontAwesomeCss;
                entity.Url = request.Url;
                entity.BadgeText = request.BadgeText;

                await _context.SaveChangesAsync(cancellationToken);

                return Unit.Value;
            }
        }
    }
}
