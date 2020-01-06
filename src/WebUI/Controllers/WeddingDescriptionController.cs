using CleanArchitecture.Application.WeddingDescriptions.Commands.CreateWeddingDescription;
using CleanArchitecture.Application.WeddingDescriptions.Commands.DeleteWeddingDescription;
using CleanArchitecture.Application.WeddingDescriptions.Commands.UpdateWeddingDescription;
using CleanArchitecture.Application.WeddingDescriptions.Queries;
using CleanArchitecture.WebUI.Common;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CleanArchitecture.WebUI.Controllers
{
    [Authorize]
    public class WeddingDescriptionController : ApiController
    {
        private readonly IFormatQueryString _formatQueryString;

        public WeddingDescriptionController(IFormatQueryString formatQueryString)
        {
            _formatQueryString = formatQueryString;
        }

        [HttpGet]
        public async Task<IEnumerable<WeddingDescriptionDto>> Get()
        {
            var queryStringReq = _formatQueryString.CreateRequestObject<GetWeddingDescriptionQuery>(Request);

            return await Mediator.Send(queryStringReq);
        }

        [HttpGet("{id}")]
        public async Task<IEnumerable<WeddingDescriptionDto>> Get(long id)
        {
            return await Mediator.Send(new GetWeddingDescriptionQuery { Id = id });
        }

        [HttpPost]
        public async Task<ActionResult<long>> Create(CreateWeddingDescriptionCommand command)
        {
            return await Mediator.Send(command);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Update(long id, UpdateWeddingDescriptionCommand command)
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
            await Mediator.Send(new DeleteWeddingDescriptionCommand { Id = id });

            return NoContent();
        }
    }
}