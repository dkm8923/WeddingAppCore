using CleanArchitecture.Application.Common.Interfaces;
using CleanArchitecture.Application.UiAppSettingApplications.Commands.UpdateUiAppSettingApplication;
using FluentValidation;

namespace CleanArchitecture.Application.UUiAppSettingApplications.Commands.UpdateUUiAppSettingApplication
{
    public class UpdateUUiAppSettingApplicationCommandValidator : AbstractValidator<UpdateUiAppSettingApplicationCommand>
    {
        private readonly IApplicationDbContext _context;

        public UpdateUUiAppSettingApplicationCommandValidator(IApplicationDbContext context)
        {
            _context = context;

            RuleFor(v => v.Name).NotEmpty().WithMessage("Name is required.");
            RuleFor(v => v.Description).NotEmpty().WithMessage("Description is required.");
        }
    }
}