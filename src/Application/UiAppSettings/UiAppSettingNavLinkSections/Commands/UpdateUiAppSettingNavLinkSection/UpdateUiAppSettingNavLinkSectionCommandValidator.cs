using CleanArchitecture.Application.Common.Interfaces;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace CleanArchitecture.Application.UiAppSettings.UiAppSettingNavLinkSections.Commands.UpdateUiAppSettingNavLinkSection
{
    public class UpdateUiAppSettingNavLinkSectionCommandValidator : AbstractValidator<UpdateUiAppSettingNavLinkSectionCommand>
    {
        private readonly IApplicationDbContext _context;

        public UpdateUiAppSettingNavLinkSectionCommandValidator(IApplicationDbContext context)
        {
            _context = context;

            RuleFor(v => v.ApplicationId).NotEmpty().WithMessage("Application Id is required.");
            RuleFor(v => v.Text).NotEmpty().WithMessage("Text is required.");
        }
    }
}
