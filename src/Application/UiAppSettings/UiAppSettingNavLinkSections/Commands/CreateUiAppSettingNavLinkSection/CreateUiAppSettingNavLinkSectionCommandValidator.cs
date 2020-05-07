using CleanArchitecture.Application.Common.Interfaces;
using CleanArchitecture.Application.UiAppSettingNavLinkSections.Commands.CreateUiAppSettingNavLinkSection;
using FluentValidation;

namespace CleanArchitecture.Application.UiAppSettings.UiAppSettingNavLinkSections.Commands.CreateUiAppSettingNavLinkSection
{
    public class CreateUiAppSettingNavLinkSectionCommandValidator : AbstractValidator<CreateUiAppSettingNavLinkSectionCommand>
    {
        private readonly IApplicationDbContext _context;

        public CreateUiAppSettingNavLinkSectionCommandValidator(IApplicationDbContext context)
        {
            _context = context;

            RuleFor(v => v.ApplicationId).NotEmpty().WithMessage("Application Id is required.");
            RuleFor(v => v.Text).NotEmpty().WithMessage("Text is required.");
        }
    }
}
