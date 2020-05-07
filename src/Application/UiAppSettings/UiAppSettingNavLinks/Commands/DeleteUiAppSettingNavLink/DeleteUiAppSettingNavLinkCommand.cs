using CleanArchitecture.Application.Common.Exceptions;
using CleanArchitecture.Application.Common.Interfaces;
using CleanArchitecture.Domain.Entities.UiAppSettings;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace CleanArchitecture.Application.UiAppSettings.UiAppSettingNavLinks.Commands.DeleteUiAppSettingNavLink
{
    public class DeleteUiAppSettingNavLinkCommand : IRequest
    {
        public long Id { get; set; }

        public class DeleteUiAppSettingNavLinkCommandHandler : IRequestHandler<DeleteUiAppSettingNavLinkCommand>
        {
            private readonly IApplicationDbContext _context;

            public DeleteUiAppSettingNavLinkCommandHandler(IApplicationDbContext context)
            {
                _context = context;
            }

            public async Task<Unit> Handle(DeleteUiAppSettingNavLinkCommand request, CancellationToken cancellationToken)
            {
                var entity = await _context.UiAppSettingNavLinks.FindAsync(request.Id);

                if (entity == null)
                {
                    throw new NotFoundException(nameof(UiAppSettingNavLink), request.Id);
                }

                _context.UiAppSettingNavLinks.Remove(entity);

                await _context.SaveChangesAsync(cancellationToken);

                return Unit.Value;
            }
        }
    }
}
