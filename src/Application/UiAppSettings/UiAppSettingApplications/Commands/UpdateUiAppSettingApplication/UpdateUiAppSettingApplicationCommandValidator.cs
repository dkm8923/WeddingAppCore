using CleanArchitecture.Application.Common.Interfaces;
using CleanArchitecture.Application.UiAppSettingApplications.Commands.UpdateUiAppSettingApplication;
using FluentValidation;

namespace CleanArchitecture.Application.UiAppSettingApplications.Commands.UpdateUUiAppSettingApplication
{
    public class UpdateUiAppSettingApplicationCommandValidator : AbstractValidator<UpdateUiAppSettingApplicationCommand>
    {
        private readonly IApplicationDbContext _context;

        public UpdateUiAppSettingApplicationCommandValidator(IApplicationDbContext context)
        {
            _context = context;

            RuleFor(v => v.Name).NotEmpty().WithMessage("Name is required.");
            RuleFor(v => v.Description).NotEmpty().WithMessage("Description is required.");
        }
    }
}