using CleanArchitecture.Application.Common.Exceptions;
using CleanArchitecture.Application.Common.Interfaces;
using CleanArchitecture.Domain.Entities;
using CleanArchitecture.Domain.Entities.UiAppSettings;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
namespace CleanArchitecture.Application.UiAppSettings.UiAppSettingFooters.Commands.UpdateUiAppSettingFooter
{
    public class UpdateUiAppSettingFooterCommand : IRequest
    {
        public long Id { get; set; }
        public long? ApplicationId { get; set; }
        public string TextLeft { get; set; }
        public string TextMiddle { get; set; }
        public string TextRight { get; set; }

        public class UpdateUiAppSettingFooterCommandHandler : IRequestHandler<UpdateUiAppSettingFooterCommand>
        {
            private readonly IApplicationDbContext _context;

            public UpdateUiAppSettingFooterCommandHandler(IApplicationDbContext context)
            {
                _context = context;
            }

            public async Task<Unit> Handle(UpdateUiAppSettingFooterCommand request, CancellationToken cancellationToken)
            {
                var entity = await _context.UiAppSettingFooters.FindAsync(request.Id);

                if (entity == null)
                {
                    throw new NotFoundException(nameof(UiAppSettingFooter), request.Id);
                }

                entity.ApplicationId = request.ApplicationId;
                entity.TextLeft = request.TextLeft;
                entity.TextMiddle = request.TextMiddle;
                entity.TextRight = request.TextRight;

                await _context.SaveChangesAsync(cancellationToken);

                return Unit.Value;
            }
        }
    }
}
