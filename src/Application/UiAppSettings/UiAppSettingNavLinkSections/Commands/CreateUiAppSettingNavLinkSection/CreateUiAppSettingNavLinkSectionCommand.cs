using CleanArchitecture.Application.Common.Interfaces;
using CleanArchitecture.Domain.Entities;
using CleanArchitecture.Domain.Entities.UiAppSettings;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace CleanArchitecture.Application.UiAppSettingNavLinkSections.Commands.CreateUiAppSettingNavLinkSection
{
    public class CreateUiAppSettingNavLinkSectionCommand : IRequest<long>
    {
        public long ApplicationId { get; set; }
        public string Text { get; set; }
        public string FontAwesomeCss { get; set; }
        public string BadgeText { get; set; }

        public class CreateUiAppSettingNavLinkSectionCommandHandler : IRequestHandler<CreateUiAppSettingNavLinkSectionCommand, long>
        {
            private readonly IApplicationDbContext _context;

            public CreateUiAppSettingNavLinkSectionCommandHandler(IApplicationDbContext context)
            {
                _context = context;
            }

            public async Task<long> Handle(CreateUiAppSettingNavLinkSectionCommand request, CancellationToken cancellationToken)
            {
                var entity = new UiAppSettingNavLinkSection
                {
                    ApplicationId = request.ApplicationId,
                    Text = request.Text,
                    FontAwesomeCss = request.FontAwesomeCss,
                    BadgeText = request.BadgeText
                };

                _context.UiAppSettingNavLinkSections.Add(entity);

                await _context.SaveChangesAsync(cancellationToken);

                return entity.Id;
            }
        }
    }
}