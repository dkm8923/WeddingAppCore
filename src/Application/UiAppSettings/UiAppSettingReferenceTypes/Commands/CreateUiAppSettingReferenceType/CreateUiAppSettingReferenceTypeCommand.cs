using CleanArchitecture.Application.Common.Interfaces;
using CleanArchitecture.Domain.Entities.UiAppSettings;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace CleanArchitecture.Application.UiAppSettingReferenceTypes.Commands.CreateUiAppSettingReferenceType
{
    public class CreateUiAppSettingReferenceTypeCommand : IRequest<long>
    {
        public string Name { get; set; }
        public string Description { get; set; }

        public class CreateUiAppSettingReferenceTypeCommandHandler : IRequestHandler<CreateUiAppSettingReferenceTypeCommand, long>
        {
            private readonly IApplicationDbContext _context;

            public CreateUiAppSettingReferenceTypeCommandHandler(IApplicationDbContext context)
            {
                _context = context;
            }

            public async Task<long> Handle(CreateUiAppSettingReferenceTypeCommand request, CancellationToken cancellationToken)
            {
                var entity = new UiAppSettingReferenceType
                {
                    Name = request.Name,
                    Description = request.Description
                };
                
                _context.UiAppSettingReferenceTypes.Add(entity);

                await _context.SaveChangesAsync(cancellationToken);

                return entity.Id;
            }
        }
    }
}