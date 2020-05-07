using CleanArchitecture.Application.Common.Interfaces;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace CleanArchitecture.Application.UiAppSettings.UiAppSettingFooters.Commands.UpdateUiAppSettingFooter
{
    public class UpdateUiAppSettingFooterCommandValidator : AbstractValidator<UpdateUiAppSettingFooterCommand>
    {
        private readonly IApplicationDbContext _context;

        public UpdateUiAppSettingFooterCommandValidator(IApplicationDbContext context)
        {
            _context = context;

            //RuleFor(v => v.Name).NotEmpty().WithMessage("Name is required.");
            //RuleFor(v => v.Description).NotEmpty().WithMessage("Description is required.");
        }
    }
}
