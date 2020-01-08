using CleanArchitecture.Application.UsaStates.Commands.CreateUsaState;
using CleanArchitecture.Application.UsaStates.Commands.DeleteUsaState;
using CleanArchitecture.Application.UsaStates.Commands.UpdateUsaState;
using CleanArchitecture.Application.UsaStates.Queries;
using CleanArchitecture.WebUI.Common;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CleanArchitecture.WebUI.Controllers
{
    public class UsaStateController : ApiController
    {
        private readonly IFormatQueryString _formatQueryString;

        public UsaStateController(IFormatQueryString formatQueryString)
        {
            _formatQueryString = formatQueryString;
        }

        [HttpGet]
        public async Task<IEnumerable<UsaStateDto>> Get()
        {
            var queryStringReq = _formatQueryString.CreateRequestObject<GetUsaStateQuery>(Request);

            return await Mediator.Send(queryStringReq);
        }

        [HttpGet("{id}")]
        public async Task<IEnumerable<UsaStateDto>> Get(long id)
        {
            return await Mediator.Send(new GetUsaStateQuery { Id = id });
        }

        [HttpPost]
        public async Task<ActionResult<long>> Create(CreateUsaStateCommand command)
        {
            return await Mediator.Send(command);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Update(long id, UpdateUsaStateCommand command)
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
            await Mediator.Send(new DeleteUsaStateCommand { Id = id });

            return NoContent();
        }
    }
}