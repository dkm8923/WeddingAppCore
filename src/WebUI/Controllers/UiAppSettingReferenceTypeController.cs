using CleanArchitecture.Application.UiAppSettingReferenceTypes.Commands.CreateUiAppSettingReferenceType;
using CleanArchitecture.Application.UiAppSettingReferenceTypes.Commands.DeleteUiAppSettingReferenceType;
using CleanArchitecture.Application.UiAppSettingReferenceTypes.Commands.UpdateUiAppSettingReferenceType;
using CleanArchitecture.Application.UiAppSettingReferenceTypes.Queries;
using CleanArchitecture.WebUI.Common;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CleanArchitecture.WebUI.Controllers
{
    public class UiAppSettingReferenceTypeController : ApiController
    {
        private readonly IFormatQueryString _formatQueryString;

        public UiAppSettingReferenceTypeController(IFormatQueryString formatQueryString)
        {
            _formatQueryString = formatQueryString;
        }

        [HttpGet]
        public async Task<IEnumerable<UiAppSettingReferenceTypeDto>> Get()
        {
            var queryStringReq = _formatQueryString.CreateRequestObject<GetUiAppSettingReferenceTypeQuery>(Request);

            return await Mediator.Send(queryStringReq);
        }

        [HttpGet("{id}")]
        public async Task<IEnumerable<UiAppSettingReferenceTypeDto>> Get(long id)
        {
            return await Mediator.Send(new GetUiAppSettingReferenceTypeQuery { Id = id });
        }

        [HttpPost]
        public async Task<ActionResult<long>> Create(CreateUiAppSettingReferenceTypeCommand command)
        {
            return await Mediator.Send(command);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Update(long id, UpdateUiAppSettingReferenceTypeCommand command)
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
            await Mediator.Send(new DeleteUiAppSettingReferenceTypeCommand { Id = id });

            return NoContent();
        }
    }
}