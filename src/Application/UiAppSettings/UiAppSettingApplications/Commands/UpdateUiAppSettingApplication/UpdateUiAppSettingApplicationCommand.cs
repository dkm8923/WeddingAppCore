using CleanArchitecture.Application.Common.Exceptions;
using CleanArchitecture.Application.Common.Interfaces;
using CleanArchitecture.Domain.Entities;
using CleanArchitecture.Domain.Entities.UiAppSettings;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace CleanArchitecture.Application.UiAppSettingApplications.Commands.UpdateUiAppSettingApplication
{
    public class UpdateUiAppSettingApplicationCommand : IRequest
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public class UpdateUiAppSettingApplicationCommandHandler : IRequestHandler<UpdateUiAppSettingApplicationCommand>
        {
            private readonly IApplicationDbContext _context;

            public UpdateUiAppSettingApplicationCommandHandler(IApplicationDbContext context)
            {
                _context = context;
            }

            public async Task<Unit> Handle(UpdateUiAppSettingApplicationCommand request, CancellationToken cancellationToken)
            {
                var entity = await _context.UiAppSettingApplications.FindAsync(request.Id);

                if (entity == null)
                {
                    throw new NotFoundException(nameof(UiAppSettingApplication), request.Id);
                }

                entity.Name = request.Name;
                entity.Description = request.Description;

                await _context.SaveChangesAsync(cancellationToken);

                return Unit.Value;
            }
        }
    }
}
