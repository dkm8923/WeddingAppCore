using CleanArchitecture.Application.Common.Interfaces;
using CleanArchitecture.Application.WeddingDescriptions.Commands.CreateWeddingDescription;
using FluentValidation;

namespace CleanArchitecture.Application.WeddingDescriptions.Commands.CreateWeddingDescription
{
    public class CreateWeddingDescriptionCommandValidator : AbstractValidator<CreateWeddingDescriptionCommand>
    {
        private readonly IApplicationDbContext _context;

        public CreateWeddingDescriptionCommandValidator(IApplicationDbContext context)
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
