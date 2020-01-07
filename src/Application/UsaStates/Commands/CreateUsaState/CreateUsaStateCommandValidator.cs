using CleanArchitecture.Application.Common.Interfaces;
using FluentValidation;

namespace CleanArchitecture.Application.UsaStates.Commands.CreateUsaState
{
    public class CreateUsaStateCommandValidator : AbstractValidator<CreateUsaStateCommand>
    {
        private readonly IApplicationDbContext _context;

        public CreateUsaStateCommandValidator(IApplicationDbContext context)
        {
            _context = context;

            RuleFor(v => v.Name).NotEmpty().WithMessage("Name is required.");
            RuleFor(v => v.AbbreviatedName).NotEmpty().WithMessage("AbbreviatedName is required.");
        }
    }
}