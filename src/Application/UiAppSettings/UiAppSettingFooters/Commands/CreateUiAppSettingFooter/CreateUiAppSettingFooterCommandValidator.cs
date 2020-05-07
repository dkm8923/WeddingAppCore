using CleanArchitecture.Application.Common.Interfaces;
using CleanArchitecture.Application.UiAppSettingFooters.Commands.CreateUiAppSettingFooter;
using FluentValidation;

namespace CleanArchitecture.Application.UiAppSettings.UiAppSettingFooters.Commands.CreateUiAppSettingFooter
{
    public class CreateUiAppSettingFooterCommandValidator : AbstractValidator<CreateUiAppSettingFooterCommand>
    {
        private readonly IApplicationDbContext _context;

        public CreateUiAppSettingFooterCommandValidator(IApplicationDbContext context)
        {
            _context = context;

            //RuleFor(v => v.Name).NotEmpty().WithMessage("Name is required.");
            //RuleFor(v => v.Description).NotEmpty().WithMessage("Description is required.");
        }
    }
}
