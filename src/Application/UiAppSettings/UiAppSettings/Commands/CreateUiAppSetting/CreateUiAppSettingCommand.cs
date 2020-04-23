using CleanArchitecture.Application.Common.Interfaces;
using CleanArchitecture.Domain.Entities.UiAppSettings;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace CleanArchitecture.Application.UiAppSettings.Commands.CreateUiAppSetting
{
    public class CreateUiAppSettingCommand : IRequest<long>
    {
        public long ApplicationId { get; set; }
        public long ReferenceTypeId { get; set; }
        public string Json { get; set; }

        public class CreateUiAppSettingCommandHandler : IRequestHandler<CreateUiAppSettingCommand, long>
        {
            private readonly IApplicationDbContext _context;

            public CreateUiAppSettingCommandHandler(IApplicationDbContext context)
            {
                _context = context;
            }

            public async Task<long> Handle(CreateUiAppSettingCommand request, CancellationToken cancellationToken)
            {
                var entity = new UiAppSetting
                {
                    ApplicationId = request.ApplicationId,
                    ReferenceTypeId = request.ReferenceTypeId,
                    Json = request.Json
                };
                
                _context.UiAppSettings.Add(entity);

                await _context.SaveChangesAsync(cancellationToken);

                return entity.Id;
            }
        }
    }
}