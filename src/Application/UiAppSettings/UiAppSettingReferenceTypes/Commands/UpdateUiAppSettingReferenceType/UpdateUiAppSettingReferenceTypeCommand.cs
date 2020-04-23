using CleanArchitecture.Application.Common.Exceptions;
using CleanArchitecture.Application.Common.Interfaces;
using CleanArchitecture.Domain.Entities;
using CleanArchitecture.Domain.Entities.UiAppSettings;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace CleanArchitecture.Application.UiAppSettingReferenceTypes.Commands.UpdateUiAppSettingReferenceType
{
    public class UpdateUiAppSettingReferenceTypeCommand : IRequest
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public class UpdateUiAppSettingReferenceTypeCommandHandler : IRequestHandler<UpdateUiAppSettingReferenceTypeCommand>
        {
            private readonly IApplicationDbContext _context;

            public UpdateUiAppSettingReferenceTypeCommandHandler(IApplicationDbContext context)
            {
                _context = context;
            }

            public async Task<Unit> Handle(UpdateUiAppSettingReferenceTypeCommand request, CancellationToken cancellationToken)
            {
                var entity = await _context.UiAppSettingReferenceTypes.FindAsync(request.Id);

                if (entity == null)
                {
                    throw new NotFoundException(nameof(UiAppSettingReferenceType), request.Id);
                }

                entity.Name = request.Name;
                entity.Description = request.Description;

                await _context.SaveChangesAsync(cancellationToken);

                return Unit.Value;
            }
        }
    }
}
