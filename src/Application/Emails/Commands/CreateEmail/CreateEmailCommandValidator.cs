using CleanArchitecture.Application.Common.Interfaces;
using FluentValidation;

namespace CleanArchitecture.Application.Emails.Commands.CreateEmail
{
    public class CreateEmailCommandValidator : AbstractValidator<CreateEmailCommand>
    {
        private readonly IApplicationDbContext _context;

        public CreateEmailCommandValidator(IApplicationDbContext context)
        {
            _context = context;

            RuleFor(v => v.Description).NotEmpty().WithMessage("Description is required.");
            RuleFor(v => v.Subject).NotEmpty().WithMessage("Subject is required.");
            RuleFor(v => v.Body).NotEmpty().WithMessage("Body is required.");
        }
    }
}
