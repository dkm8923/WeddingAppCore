using CleanArchitecture.Application.Common.Interfaces;
using FluentValidation;

namespace CleanArchitecture.Application.GuestBookEntries.Commands.CreateGuestBookEntry
{
    public class CreateGuestBookEntryCommandValidator : AbstractValidator<CreateGuestBookEntryCommand>
    {
        private readonly IApplicationDbContext _context;

        public CreateGuestBookEntryCommandValidator(IApplicationDbContext context)
        {
            _context = context;

            RuleFor(v => v.Name).NotEmpty().WithMessage("Name is required.");
            RuleFor(v => v.Entry).NotEmpty().WithMessage("Entry is required.");
        }
    }
}
