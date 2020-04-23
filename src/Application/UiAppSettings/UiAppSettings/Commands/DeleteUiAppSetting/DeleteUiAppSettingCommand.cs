using CleanArchitecture.Application.Common.Exceptions;
using CleanArchitecture.Application.Common.Interfaces;
using CleanArchitecture.Domain.Entities.UiAppSettings;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace CleanArchitecture.Application.UiAppSettings.Commands.DeleteUiAppSetting
{
    public class DeleteUiAppSettingCommand : IRequest
    {
        public long Id { get; set; }

        public class DeleteUiAppSettingCommandHandler : IRequestHandler<DeleteUiAppSettingCommand>
        {
            private readonly IApplicationDbContext _context;

            public DeleteUiAppSettingCommandHandler(IApplicationDbContext context)
            {
                _context = context;
            }

            public async Task<Unit> Handle(DeleteUiAppSettingCommand request, CancellationToken cancellationToken)
            {
                var entity = await _context.UiAppSettings.FindAsync(request.Id);

                if (entity == null)
                {
                    throw new NotFoundException(nameof(UiAppSetting), request.Id);
                }

                _context.UiAppSettings.Remove(entity);

                await _context.SaveChangesAsync(cancellationToken);

                return Unit.Value;
            }
        }
    }
}
