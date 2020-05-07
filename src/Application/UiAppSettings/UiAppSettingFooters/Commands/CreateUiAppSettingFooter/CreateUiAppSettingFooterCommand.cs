using CleanArchitecture.Application.Common.Interfaces;
using CleanArchitecture.Domain.Entities;
using CleanArchitecture.Domain.Entities.UiAppSettings;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace CleanArchitecture.Application.UiAppSettingFooters.Commands.CreateUiAppSettingFooter
{
    public class CreateUiAppSettingFooterCommand : IRequest<long>
    {
        public long? ApplicationId { get; set; }
        public string TextLeft { get; set; }
        public string TextMiddle { get; set; }
        public string TextRight { get; set; }

        public class CreateUiAppSettingFooterCommandHandler : IRequestHandler<CreateUiAppSettingFooterCommand, long>
        {
            private readonly IApplicationDbContext _context;

            public CreateUiAppSettingFooterCommandHandler(IApplicationDbContext context)
            {
                _context = context;
            }

            public async Task<long> Handle(CreateUiAppSettingFooterCommand request, CancellationToken cancellationToken)
            {
                var entity = new UiAppSettingFooter
                {
                    ApplicationId = request.ApplicationId,
                    TextLeft = request.TextLeft,
                    TextMiddle = request.TextMiddle,
                    TextRight = request.TextRight
                };

                _context.UiAppSettingFooters.Add(entity);

                await _context.SaveChangesAsync(cancellationToken);

                return entity.Id;
            }
        }
    }
}