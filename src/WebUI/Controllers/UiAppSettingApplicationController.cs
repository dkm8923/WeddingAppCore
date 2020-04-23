using CleanArchitecture.Application.UiAppSettingApplications.Commands.CreateUiAppSettingApplication;
using CleanArchitecture.Application.UiAppSettingApplications.Commands.DeleteUiAppSettingApplication;
using CleanArchitecture.Application.UiAppSettingApplications.Commands.UpdateUiAppSettingApplication;
using CleanArchitecture.Application.UiAppSettingApplications.Queries;
using CleanArchitecture.Application.UiAppSettings.UiAppSettingApplications.Queries;
using CleanArchitecture.WebUI.Common;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CleanArchitecture.WebUI.Controllers
{
    public class UiAppSettingApplicationController : ApiController
    {
        private readonly IFormatQueryString _formatQueryString;

        public UiAppSettingApplicationController(IFormatQueryString formatQueryString)
        {
            _formatQueryString = formatQueryString;
        }

        [HttpGet]
        public async Task<IEnumerable<UiAppSettingApplicationDto>> Get()
        {
            var queryStringReq = _formatQueryString.CreateRequestObject<GetUiAppSettingApplicationQuery>(Request);

            return await Mediator.Send(queryStringReq);
        }

        [HttpGet("{id}")]
        public async Task<IEnumerable<UiAppSettingApplicationDto>> Get(long id)
        {
            return await Mediator.Send(new GetUiAppSettingApplicationQuery { Id = id });
        }

        [HttpPost]
        public async Task<ActionResult<long>> Create(CreateUiAppSettingApplicationCommand command)
        {
            return await Mediator.Send(command);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Update(long id, UpdateUiAppSettingApplicationCommand command)
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
            await Mediator.Send(new DeleteUiAppSettingApplicationCommand { Id = id });

            return NoContent();
        }
    }
}