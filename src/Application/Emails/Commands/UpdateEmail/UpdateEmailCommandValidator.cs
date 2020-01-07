using CleanArchitecture.Application.Common.Interfaces;
using CleanArchitecture.Application.Email.Commands.UpdateEmail;
using FluentValidation;

namespace CleanArchitecture.Application.Emails.Commands.UpdateEmail
{
    public class UpdateEmailCommandValidator : AbstractValidator<UpdateEmailCommand>
    {
        private readonly IApplicationDbContext _context;

        public UpdateEmailCommandValidator(IApplicationDbContext context)
        {
            _context = context;

            RuleFor(v => v.Description).NotEmpty().WithMessage("Description is required.");
            RuleFor(v => v.Subject).NotEmpty().WithMessage("Subject is required.");
            RuleFor(v => v.Body).NotEmpty().WithMessage("Body is required.");
        }
    }
}
