using CleanArchitecture.Application.UiAppSettingFooters.Commands.CreateUiAppSettingFooter;
using CleanArchitecture.Application.UiAppSettings.UiAppSettingFooters.Commands.DeleteUiAppSettingFooter;
using CleanArchitecture.Application.UiAppSettings.UiAppSettingFooters.Commands.UpdateUiAppSettingFooter;
using CleanArchitecture.Application.UiAppSettings.UiAppSettingFooters.Queries;
using CleanArchitecture.WebUI.Common;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CleanArchitecture.WebUI.Controllers
{
    public class UiAppSettingFooterController : ApiController
    {
        private readonly IFormatQueryString _formatQueryString;

        public UiAppSettingFooterController(IFormatQueryString formatQueryString)
        {
            _formatQueryString = formatQueryString;
        }

        [HttpGet]
        public async Task<IEnumerable<UiAppSettingFooterDto>> Get()
        {
            var queryStringReq = _formatQueryString.CreateRequestObject<GetUiAppSettingFooterQuery>(Request);

            return await Mediator.Send(queryStringReq);
        }

        [HttpGet("{id}")]
        public async Task<IEnumerable<UiAppSettingFooterDto>> Get(long id)
        {
            return await Mediator.Send(new GetUiAppSettingFooterQuery { Id = id });
        }

        [HttpPost]
        public async Task<ActionResult<long>> Create(CreateUiAppSettingFooterCommand command)
        {
            return await Mediator.Send(command);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Update(long id, UpdateUiAppSettingFooterCommand command)
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
            await Mediator.Send(new DeleteUiAppSettingFooterCommand { Id = id });

            return NoContent();
        }
    }
}