using CleanArchitecture.Application.Common.Interfaces;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace CleanArchitecture.Application.UiAppSettings.UiAppSettingNavLinks.Commands.UpdateUiAppSettingNavLink
{
    public class UpdateUiAppSettingNavLinkCommandValidator : AbstractValidator<UpdateUiAppSettingNavLinkCommand>
    {
        private readonly IApplicationDbContext _context;

        public UpdateUiAppSettingNavLinkCommandValidator(IApplicationDbContext context)
        {
            _context = context;

            RuleFor(v => v.ApplicationId).NotEmpty().WithMessage("Application Id is required.");
            RuleFor(v => v.Text).NotEmpty().WithMessage("Text is required.");
            RuleFor(v => v.Url).NotEmpty().WithMessage("Url is required.");
        }
    }
}
