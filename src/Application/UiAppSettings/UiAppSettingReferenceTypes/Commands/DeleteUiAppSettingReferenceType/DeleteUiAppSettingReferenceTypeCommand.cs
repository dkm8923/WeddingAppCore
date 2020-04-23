using CleanArchitecture.Application.Common.Exceptions;
using CleanArchitecture.Application.Common.Interfaces;
using CleanArchitecture.Domain.Entities.UiAppSettings;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace CleanArchitecture.Application.UiAppSettingReferenceTypes.Commands.DeleteUiAppSettingReferenceType
{
    public class DeleteUiAppSettingReferenceTypeCommand : IRequest
    {
        public long Id { get; set; }

        public class DeleteUiAppSettingReferenceTypeCommandHandler : IRequestHandler<DeleteUiAppSettingReferenceTypeCommand>
        {
            private readonly IApplicationDbContext _context;

            public DeleteUiAppSettingReferenceTypeCommandHandler(IApplicationDbContext context)
            {
                _context = context;
            }

            public async Task<Unit> Handle(DeleteUiAppSettingReferenceTypeCommand request, CancellationToken cancellationToken)
            {
                var entity = await _context.UiAppSettingReferenceTypes.FindAsync(request.Id);

                if (entity == null)
                {
                    throw new NotFoundException(nameof(UiAppSettingReferenceType), request.Id);
                }

                _context.UiAppSettingReferenceTypes.Remove(entity);

                await _context.SaveChangesAsync(cancellationToken);

                return Unit.Value;
            }
        }
    }
}
