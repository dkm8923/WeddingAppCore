using CleanArchitecture.Application.Common.Interfaces;
using FluentValidation;

namespace CleanArchitecture.Application.UiAppSettings.Commands.CreateUiAppSetting
{
    public class CreateUiAppSettingCommandValidator : AbstractValidator<CreateUiAppSettingCommand>
    {
        private readonly IApplicationDbContext _context;

        public CreateUiAppSettingCommandValidator(IApplicationDbContext context)
        {
            _context = context;

            RuleFor(v => v.ApplicationId).NotEmpty().WithMessage("ApplicationId is required.");
            RuleFor(v => v.ReferenceTypeId).NotEmpty().WithMessage("ReferenceTypeId is required.");
            RuleFor(v => v.Json).NotEmpty().WithMessage("Json is required.");
        }
    }
}