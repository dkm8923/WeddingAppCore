using CleanArchitecture.Application.Common.Interfaces;
using FluentValidation;

namespace CleanArchitecture.Application.EmailLogs.Commands.UpdateEmailLog
{
    public class UpdateEmailLogCommandValidator : AbstractValidator<UpdateEmailLogCommand>
    {
        private readonly IApplicationDbContext _context;

        public UpdateEmailLogCommandValidator(IApplicationDbContext context)
        {
            _context = context;

            RuleFor(v => v.EmailId).NotEmpty().WithMessage("EmailId is required.");
            RuleFor(v => v.SentDate).NotEmpty().WithMessage("SentDate is required.");
            RuleFor(v => v.SentBy).NotEmpty().WithMessage("SentBy is required.");
        }
    }
}