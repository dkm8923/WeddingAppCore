using CleanArchitecture.Application.Common.Interfaces;
using FluentValidation;

namespace CleanArchitecture.Application.EmailLogs.Commands.CreateEmailLog
{
    public class CreateEmailLogCommandValidator : AbstractValidator<CreateEmailLogCommand>
    {
        private readonly IApplicationDbContext _context;

        public CreateEmailLogCommandValidator(IApplicationDbContext context)
        {
            _context = context;

            RuleFor(v => v.EmailId).NotEmpty().WithMessage("EmailId is required.");
            RuleFor(v => v.SentDate).NotEmpty().WithMessage("SentDate is required.");
            RuleFor(v => v.SentBy).NotEmpty().WithMessage("SentBy is required.");
        }
    }
}
