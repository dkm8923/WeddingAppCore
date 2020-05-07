using CleanArchitecture.Application.Common.Interfaces;
using CleanArchitecture.Application.UiAppSettingNavLinks.Commands.CreateUiAppSettingNavLink;
using FluentValidation;

namespace CleanArchitecture.Application.UiAppSettings.UiAppSettingNavLinks.Commands.CreateUiAppSettingNavLink
{
    public class CreateUiAppSettingNavLinkCommandValidator : AbstractValidator<CreateUiAppSettingNavLinkCommand>
    {
        private readonly IApplicationDbContext _context;

        public CreateUiAppSettingNavLinkCommandValidator(IApplicationDbContext context)
        {
            _context = context;

            RuleFor(v => v.ApplicationId).NotEmpty().WithMessage("Application Id is required.");
            RuleFor(v => v.Text).NotEmpty().WithMessage("Text is required.");
            RuleFor(v => v.Url).NotEmpty().WithMessage("Url is required.");
        }
    }
}
