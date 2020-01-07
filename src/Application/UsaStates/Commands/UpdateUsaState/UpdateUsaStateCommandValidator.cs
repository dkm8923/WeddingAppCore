using CleanArchitecture.Application.Common.Interfaces;
using CleanArchitecture.Application.UsaState.Commands.UpdateUsaState;
using FluentValidation;

namespace CleanArchitecture.Application.UsaStates.Commands.UpdateUsaState
{
    public class UpdateUsaStateCommandValidator : AbstractValidator<UpdateUsaStateCommand>
    {
        private readonly IApplicationDbContext _context;

        public UpdateUsaStateCommandValidator(IApplicationDbContext context)
        {
            _context = context;

            RuleFor(v => v.Name).NotEmpty().WithMessage("Name is required.");
            RuleFor(v => v.AbbreviatedName).NotEmpty().WithMessage("AbbreviatedName is required.");
        }
    }
}