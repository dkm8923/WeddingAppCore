using CleanArchitecture.Application.Common.Interfaces;
using CleanArchitecture.Domain.Entities;
using CleanArchitecture.Domain.Entities.UiAppSettings;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace CleanArchitecture.Application.UiAppSettingNavLinks.Commands.CreateUiAppSettingNavLink
{
    public class CreateUiAppSettingNavLinkCommand : IRequest<long>
    {
        public long ApplicationId { get; set; }
        public long? NavLinkSectionId { get; set; }
        public string Text { get; set; }
        public string FontAwesomeCss { get; set; }
        public string Url { get; set; }
        public string BadgeText { get; set; }

        public class CreateUiAppSettingNavLinkCommandHandler : IRequestHandler<CreateUiAppSettingNavLinkCommand, long>
        {
            private readonly IApplicationDbContext _context;

            public CreateUiAppSettingNavLinkCommandHandler(IApplicationDbContext context)
            {
                _context = context;
            }

            public async Task<long> Handle(CreateUiAppSettingNavLinkCommand request, CancellationToken cancellationToken)
            {
                var entity = new UiAppSettingNavLink
                {
                    ApplicationId = request.ApplicationId,
                    NavLinkSectionId = request.NavLinkSectionId,
                    Text = request.Text,
                    FontAwesomeCss = request.FontAwesomeCss,
                    Url = request.Url,
                    BadgeText = request.BadgeText
                };

                _context.UiAppSettingNavLinks.Add(entity);

                await _context.SaveChangesAsync(cancellationToken);

                return entity.Id;
            }
        }
    }
}