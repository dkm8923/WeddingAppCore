using CleanArchitecture.Application.UiAppSettings.Commands.CreateUiAppSetting;
using CleanArchitecture.Application.UiAppSettings.Commands.DeleteUiAppSetting;
using CleanArchitecture.Application.UiAppSettings.Commands.UpdateUiAppSetting;
using CleanArchitecture.Application.UiAppSettings.Queries;
using CleanArchitecture.WebUI.Common;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CleanArchitecture.WebUI.Controllers
{
    public class UiAppSettingController : ApiController
    {
        private readonly IFormatQueryString _formatQueryString;

        public UiAppSettingController(IFormatQueryString formatQueryString)
        {
            _formatQueryString = formatQueryString;
        }

        [HttpGet]
        public async Task<IEnumerable<UiAppSettingDto>> Get()
        {
            var queryStringReq = _formatQueryString.CreateRequestObject<GetUiAppSettingQuery>(Request);

            return await Mediator.Send(queryStringReq);
        }

        [HttpGet("{id}")]
        public async Task<IEnumerable<UiAppSettingDto>> Get(long id)
        {
            return await Mediator.Send(new GetUiAppSettingQuery { Id = id });
        }

        [HttpPost]
        public async Task<ActionResult<long>> Create(CreateUiAppSettingCommand command)
        {
            return await Mediator.Send(command);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Update(long id, UpdateUiAppSettingCommand command)
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
            await Mediator.Send(new DeleteUiAppSettingCommand { Id = id });

            return NoContent();
        }
    }
}