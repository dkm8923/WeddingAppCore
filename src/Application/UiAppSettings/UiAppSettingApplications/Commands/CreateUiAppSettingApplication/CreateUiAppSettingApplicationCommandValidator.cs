using CleanArchitecture.Application.Common.Interfaces;
using FluentValidation;

namespace CleanArchitecture.Application.UiAppSettingApplications.Commands.CreateUiAppSettingApplication
{
    public class CreateUiAppSettingApplicationCommandValidator : AbstractValidator<CreateUiAppSettingApplicationCommand>
    {
        private readonly IApplicationDbContext _context;

        public CreateUiAppSettingApplicationCommandValidator(IApplicationDbContext context)
        {
            _context = context;

            RuleFor(v => v.Name).NotEmpty().WithMessage("Name is required.");
            RuleFor(v => v.Description).NotEmpty().WithMessage("Description is required.");
        }
    }
}