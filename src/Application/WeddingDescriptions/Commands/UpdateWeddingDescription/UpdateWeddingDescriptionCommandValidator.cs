using CleanArchitecture.Application.Common.Interfaces;
using FluentValidation;

namespace CleanArchitecture.Application.WeddingDescriptions.Commands.UpdateWeddingDescription
{
    public class UpdateWeddingDescriptionCommandValidator : AbstractValidator<UpdateWeddingDescriptionCommand>
    {
        private readonly IApplicationDbContext _context;

        public UpdateWeddingDescriptionCommandValidator(IApplicationDbContext context)
        {
            _context = context;

            RuleFor(v => v.GroomDescription).NotEmpty().WithMessage("GroomDescription is required.");
            RuleFor(v => v.BrideDescription).NotEmpty().WithMessage("BrideDescription is required.");
            RuleFor(v => v.CeremonyDateTimeLocation).NotEmpty().WithMessage("CeremonyDateTimeLocation is required.");
            RuleFor(v => v.CeremonyDescription).NotEmpty().WithMessage("CeremonyDescription is required.");
            RuleFor(v => v.ReceptionDateTimeLocation).NotEmpty().WithMessage("ReceptionDateTimeLocation is required.");
            RuleFor(v => v.ReceptionDescription).NotEmpty().WithMessage("ReceptionDescription is required.");
        }
    }
}
