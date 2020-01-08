using CleanArchitecture.Application.Common.Interfaces;
using FluentValidation;

namespace CleanArchitecture.Application.Guests.Commands.UpdateGuest
{
    public class UpdateGuestCommandValidator : AbstractValidator<UpdateGuestCommand>
    {
        private readonly IApplicationDbContext _context;

        public UpdateGuestCommandValidator(IApplicationDbContext context)
        {
            _context = context;

            RuleFor(v => v.FirstName).NotEmpty().WithMessage("FirstName is required.");
            RuleFor(v => v.LastName).NotEmpty().WithMessage("LastName is required.");
            RuleFor(v => v.Email).NotEmpty().WithMessage("Email is required.");
        }
    }
}