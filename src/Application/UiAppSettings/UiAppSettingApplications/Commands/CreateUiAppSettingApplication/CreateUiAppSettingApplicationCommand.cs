using CleanArchitecture.Application.Common.Interfaces;
using CleanArchitecture.Domain.Entities;
using CleanArchitecture.Domain.Entities.UiAppSettings;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace CleanArchitecture.Application.UiAppSettingApplications.Commands.CreateUiAppSettingApplication
{
    public class CreateUiAppSettingApplicationCommand : IRequest<long>
    {
        public string Name { get; set; }
        public string Description { get; set; }

        public class CreateUiAppSettingApplicationCommandHandler : IRequestHandler<CreateUiAppSettingApplicationCommand, long>
        {
            private readonly IApplicationDbContext _context;

            public CreateUiAppSettingApplicationCommandHandler(IApplicationDbContext context)
            {
                _context = context;
            }

            public async Task<long> Handle(CreateUiAppSettingApplicationCommand request, CancellationToken cancellationToken)
            {
                var entity = new UiAppSettingApplication
                {
                    Name = request.Name,
                    Description = request.Description
                };
                
                _context.UiAppSettingApplications.Add(entity);

                await _context.SaveChangesAsync(cancellationToken);

                return entity.Id;
            }
        }
    }
}