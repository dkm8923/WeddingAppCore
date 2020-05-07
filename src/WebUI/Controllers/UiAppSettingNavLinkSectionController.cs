using CleanArchitecture.Application.UiAppSettingNavLinkSections.Commands.CreateUiAppSettingNavLinkSection;
using CleanArchitecture.Application.UiAppSettings.UiAppSettingNavLinkSections.Commands.DeleteUiAppSettingNavLinkSection;
using CleanArchitecture.Application.UiAppSettings.UiAppSettingNavLinkSections.Commands.UpdateUiAppSettingNavLinkSection;
using CleanArchitecture.Application.UiAppSettings.UiAppSettingNavLinkSections.Queries;
using CleanArchitecture.WebUI.Common;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CleanArchitecture.WebUI.Controllers
{
    public class UiAppSettingNavLinkSectionController : ApiController
    {
        private readonly IFormatQueryString _formatQueryString;

        public UiAppSettingNavLinkSectionController(IFormatQueryString formatQueryString)
        {
            _formatQueryString = formatQueryString;
        }

        [HttpGet]
        public async Task<IEnumerable<UiAppSettingNavLinkSectionDto>> Get()
        {
            var queryStringReq = _formatQueryString.CreateRequestObject<GetUiAppSettingNavLinkSectionQuery>(Request);

            return await Mediator.Send(queryStringReq);
        }

        [HttpGet("{id}")]
        public async Task<IEnumerable<UiAppSettingNavLinkSectionDto>> Get(long id)
        {
            return await Mediator.Send(new GetUiAppSettingNavLinkSectionQuery { Id = id });
        }

        [HttpPost]
        public async Task<ActionResult<long>> Create(CreateUiAppSettingNavLinkSectionCommand command)
        {
            return await Mediator.Send(command);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Update(long id, UpdateUiAppSettingNavLinkSectionCommand command)
        {
            if (id != command.Id)
            {
                return BadRequest();
            }

            await Mediator.Send(command);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(long id)
        {
            await Mediator.Send(new DeleteUiAppSettingNavLinkSectionCommand { Id = id });

            return NoContent();
        }
    }
}