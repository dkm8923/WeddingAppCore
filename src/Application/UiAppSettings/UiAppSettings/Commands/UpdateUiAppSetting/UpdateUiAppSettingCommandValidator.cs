using CleanArchitecture.Application.Common.Interfaces;
using CleanArchitecture.Application.UiAppSettings.Commands.UpdateUiAppSetting;
using FluentValidation;

namespace CleanArchitecture.Application.UUiAppSettings.Commands.UpdateUUiAppSetting
{
    public class UpdateUUiAppSettingCommandValidator : AbstractValidator<UpdateUiAppSettingCommand>
    {
        private readonly IApplicationDbContext _context;

        public UpdateUUiAppSettingCommandValidator(IApplicationDbContext context)
        {
            _context = context;

            RuleFor(v => v.ApplicationId).NotEmpty().WithMessage("ApplicationId is required.");
            RuleFor(v => v.ReferenceTypeId).NotEmpty().WithMessage("ReferenceTypeId is required.");
            RuleFor(v => v.Json).NotEmpty().WithMessage("Json is required.");
        }
    }
}