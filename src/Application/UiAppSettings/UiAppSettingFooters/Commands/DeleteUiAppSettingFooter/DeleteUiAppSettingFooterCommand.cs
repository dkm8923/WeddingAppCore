using CleanArchitecture.Application.Common.Exceptions;
using CleanArchitecture.Application.Common.Interfaces;
using CleanArchitecture.Domain.Entities.UiAppSettings;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace CleanArchitecture.Application.UiAppSettings.UiAppSettingFooters.Commands.DeleteUiAppSettingFooter
{
    public class DeleteUiAppSettingFooterCommand : IRequest
    {
        public long Id { get; set; }

        public class DeleteUiAppSettingFooterCommandHandler : IRequestHandler<DeleteUiAppSettingFooterCommand>
        {
            private readonly IApplicationDbContext _context;

            public DeleteUiAppSettingFooterCommandHandler(IApplicationDbContext context)
            {
                _context = context;
            }

            public async Task<Unit> Handle(DeleteUiAppSettingFooterCommand request, CancellationToken cancellationToken)
            {
                var entity = await _context.UiAppSettingFooters.FindAsync(request.Id);

                if (entity == null)
                {
                    throw new NotFoundException(nameof(UiAppSettingFooter), request.Id);
                }

                _context.UiAppSettingFooters.Remove(entity);

                await _context.SaveChangesAsync(cancellationToken);

                return Unit.Value;
            }
        }
    }
}
