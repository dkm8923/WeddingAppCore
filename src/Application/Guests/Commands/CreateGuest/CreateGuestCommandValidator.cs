using CleanArchitecture.Application.Common.Interfaces;
using FluentValidation;

namespace CleanArchitecture.Application.Guests.Commands.CreateGuest
{
    public class CreateGuestCommandValidator : AbstractValidator<CreateGuestCommand>
    {
        private readonly IApplicationDbContext _context;

        public CreateGuestCommandValidator(IApplicationDbContext context)
        {
            _context = context;

            RuleFor(v => v.FirstName).NotEmpty().WithMessage("FirstName is required.");
            RuleFor(v => v.LastName).NotEmpty().WithMessage("LastName is required.");
            RuleFor(v => v.Email).NotEmpty().WithMessage("Email is required.");
        }
    }
}