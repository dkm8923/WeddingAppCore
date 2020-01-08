using CleanArchitecture.Application.Guests.Commands.CreateGuest;
using CleanArchitecture.Application.Guests.Commands.DeleteGuest;
using CleanArchitecture.Application.Guests.Commands.UpdateGuest;
using CleanArchitecture.Application.Guests.Queries;
using CleanArchitecture.WebUI.Common;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CleanArchitecture.WebUI.Controllers
{
    public class GuestController : ApiController
    {
        private readonly IFormatQueryString _formatQueryString;

        public GuestController(IFormatQueryString formatQueryString)
        {
            _formatQueryString = formatQueryString;
        }

        [HttpGet]
        public async Task<IEnumerable<GuestDto>> Get()
        {
            var queryStringReq = _formatQueryString.CreateRequestObject<GetGuestQuery>(Request);

            return await Mediator.Send(queryStringReq);
        }

        [HttpGet("{id}")]
        public async Task<IEnumerable<GuestDto>> Get(long id)
        {
            return await Mediator.Send(new GetGuestQuery { Id = id });
        }

        [HttpPost]
        public async Task<ActionResult<long>> Create(CreateGuestCommand command)
        {
            return await Mediator.Send(command);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Update(long id, UpdateGuestCommand command)
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
            await Mediator.Send(new DeleteGuestCommand { Id = id });

            return NoContent();
        }
    }
}