using CleanArchitecture.Application.Common.Interfaces;
using FluentValidation;

namespace CleanArchitecture.Application.UiAppSettingReferenceTypes.Commands.CreateUiAppSettingReferenceType
{
    public class CreateUiAppSettingReferenceTypeCommandValidator : AbstractValidator<CreateUiAppSettingReferenceTypeCommand>
    {
        private readonly IApplicationDbContext _context;

        public CreateUiAppSettingReferenceTypeCommandValidator(IApplicationDbContext context)
        {
            _context = context;

            RuleFor(v => v.Name).NotEmpty().WithMessage("Name is required.");
            RuleFor(v => v.Description).NotEmpty().WithMessage("Description is required.");
        }
    }
}