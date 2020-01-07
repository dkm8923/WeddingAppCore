using CleanArchitecture.Application.Common.Interfaces;
using FluentValidation;

namespace CleanArchitecture.Application.Families.Commands.CreateFamily
{
    public class CreateFamilyCommandValidator : AbstractValidator<CreateFamilyCommand>
    {
        private readonly IApplicationDbContext _context;

        public CreateFamilyCommandValidator(IApplicationDbContext context)
        {
            _context = context;

            RuleFor(v => v.GuestId).NotEmpty().WithMessage("GuestId is required.");
            RuleFor(v => v.ConfirmationCode).NotEmpty().WithMessage("ConfirmationCode is required.");
            RuleFor(v => v.Address1).NotEmpty().WithMessage("Address1 is required.");
            RuleFor(v => v.Address2).NotEmpty().WithMessage("Address2 is required.");
            RuleFor(v => v.City).NotEmpty().WithMessage("City is required.");
            RuleFor(v => v.StateId).NotEmpty().WithMessage("StateId is required.");
            RuleFor(v => v.Zip).NotEmpty().WithMessage("Zip is required.");
        }
    }
}
