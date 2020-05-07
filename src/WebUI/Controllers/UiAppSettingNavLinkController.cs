using CleanArchitecture.Application.UiAppSettingNavLinks.Commands.CreateUiAppSettingNavLink;
using CleanArchitecture.Application.UiAppSettings.UiAppSettingNavLinks.Commands.DeleteUiAppSettingNavLink;
using CleanArchitecture.Application.UiAppSettings.UiAppSettingNavLinks.Commands.UpdateUiAppSettingNavLink;
using CleanArchitecture.Application.UiAppSettings.UiAppSettingNavLinks.Queries;
using CleanArchitecture.WebUI.Common;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CleanArchitecture.WebUI.Controllers
{
    public class UiAppSettingNavLinkController : ApiController
    {
        private readonly IFormatQueryString _formatQueryString;

        public UiAppSettingNavLinkController(IFormatQueryString formatQueryString)
        {
            _formatQueryString = formatQueryString;
        }

        [HttpGet]
        public async Task<IEnumerable<UiAppSettingNavLinkDto>> Get()
        {
            var queryStringReq = _formatQueryString.CreateRequestObject<GetUiAppSettingNavLinkQuery>(Request);

            return await Mediator.Send(queryStringReq);
        }

        [HttpGet("{id}")]
        public async Task<IEnumerable<UiAppSettingNavLinkDto>> Get(long id)
        {
            return await Mediator.Send(new GetUiAppSettingNavLinkQuery { Id = id });
        }

        [HttpPost]
        public async Task<ActionResult<long>> Create(CreateUiAppSettingNavLinkCommand command)
        {
            return await Mediator.Send(command);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Update(long id, UpdateUiAppSettingNavLinkCommand command)
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
            await Mediator.Send(new DeleteUiAppSettingNavLinkCommand { Id = id });

            return NoContent();
        }
    }
}