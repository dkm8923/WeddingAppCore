using CleanArchitecture.Application.GuestBookEntries.Commands.CreateGuestBookEntry;
using CleanArchitecture.Application.GuestBookEntries.Commands.DeleteGuestBookEntry;
using CleanArchitecture.Application.GuestBookEntries.Commands.UpdateGuestBookEntry;
using CleanArchitecture.Application.GuestBookEntries.Queries;
using CleanArchitecture.WebUI.Common;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CleanArchitecture.WebUI.Controllers
{
    public class GuestBookEntryController : ApiController
    {
        private readonly IFormatQueryString _formatQueryString;

        public GuestBookEntryController(IFormatQueryString formatQueryString)
        {
            _formatQueryString = formatQueryString;
        }

        [HttpGet]
        public async Task<IEnumerable<GuestBookEntryDto>> Get()
        {
            var queryStringReq = _formatQueryString.CreateRequestObject<GetGuestBookEntryQuery>(Request);

            return await Mediator.Send(queryStringReq);
        }

        [HttpGet("{id}")]
        public async Task<IEnumerable<GuestBookEntryDto>> Get(long id)
        {
            return await Mediator.Send(new GetGuestBookEntryQuery { Id = id });
        }

        [HttpPost]
        public async Task<ActionResult<long>> Create(CreateGuestBookEntryCommand command)
        {
            return await Mediator.Send(command);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Update(long id, UpdateGuestBookEntryCommand command)
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
            await Mediator.Send(new DeleteGuestBookEntryCommand { Id = id });

            return NoContent();
        }
    }
}