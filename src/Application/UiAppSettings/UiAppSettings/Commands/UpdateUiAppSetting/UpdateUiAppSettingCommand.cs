using CleanArchitecture.Application.Common.Exceptions;
using CleanArchitecture.Application.Common.Interfaces;
using CleanArchitecture.Domain.Entities;
using CleanArchitecture.Domain.Entities.UiAppSettings;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace CleanArchitecture.Application.UiAppSettings.Commands.UpdateUiAppSetting
{
    public class UpdateUiAppSettingCommand : IRequest
    {
        public long Id { get; set; }
        public long ApplicationId { get; set; }
        public long ReferenceTypeId { get; set; }
        public string Json { get; set; }

        public class UpdateUiAppSettingCommandHandler : IRequestHandler<UpdateUiAppSettingCommand>
        {
            private readonly IApplicationDbContext _context;

            public UpdateUiAppSettingCommandHandler(IApplicationDbContext context)
            {
                _context = context;
            }

            public async Task<Unit> Handle(UpdateUiAppSettingCommand request, CancellationToken cancellationToken)
            {
                var entity = await _context.UiAppSettings.FindAsync(request.Id);

                if (entity == null)
                {
                    throw new NotFoundException(nameof(UiAppSetting), request.Id);
                }

                entity.ApplicationId = request.ApplicationId;
                entity.ReferenceTypeId = request.ReferenceTypeId;
                entity.Json = request.Json;

                await _context.SaveChangesAsync(cancellationToken);

                return Unit.Value;
            }
        }
    }
}
