using CleanArchitecture.Application.Common.Interfaces;
using FluentValidation;

namespace CleanArchitecture.Application.UiAppSettingReferenceTypes.Commands.UpdateUiAppSettingReferenceType
{
    public class UpdateUiAppSettingReferenceTypeCommandValidator : AbstractValidator<UpdateUiAppSettingReferenceTypeCommand>
    {
        private readonly IApplicationDbContext _context;

        public UpdateUiAppSettingReferenceTypeCommandValidator(IApplicationDbContext context)
        {
            _context = context;

            RuleFor(v => v.Name).NotEmpty().WithMessage("Name is required.");
            RuleFor(v => v.Description).NotEmpty().WithMessage("Description is required.");
        }
    }
}