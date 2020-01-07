using CleanArchitecture.Application.Common.Interfaces;
using FluentValidation;

namespace CleanArchitecture.Application.GuestBookEntries.Commands.UpdateGuestBookEntry
{
    public class UpdateGuestBookEntryCommandValidator : AbstractValidator<UpdateGuestBookEntryCommand>
    {
        private readonly IApplicationDbContext _context;

        public UpdateGuestBookEntryCommandValidator(IApplicationDbContext context)
        {
            _context = context;

            RuleFor(v => v.Name).NotEmpty().WithMessage("Name is required.");
            RuleFor(v => v.Entry).NotEmpty().WithMessage("Entry is required.");
        }
    }
}
