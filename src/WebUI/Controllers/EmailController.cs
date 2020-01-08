using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CleanArchitecture.Application.Emails.Commands.CreateEmail;
using CleanArchitecture.Application.Emails.Commands.DeleteEmail;
using CleanArchitecture.Application.Emails.Commands.UpdateEmail;
using CleanArchitecture.Application.Emails.Queries;
using CleanArchitecture.WebUI.Common;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CleanArchitecture.WebUI.Controllers
{
    [Authorize]
    public class EmailController : ApiController
    {
        private readonly IFormatQueryString _formatQueryString;

        public EmailController(IFormatQueryString formatQueryString)
        {
            _formatQueryString = formatQueryString;
        }

        [HttpGet]
        public async Task<IEnumerable<EmailDto>> Get()
        {
            var queryStringReq = _formatQueryString.CreateRequestObject<GetEmailQuery>(Request);

            return await Mediator.Send(queryStringReq);
        }

        [HttpGet("{id}")]
        public async Task<IEnumerable<EmailDto>> Get(long id)
        {
            return await Mediator.Send(new GetEmailQuery { Id = id });
        }

        [HttpPost]
        public async Task<ActionResult<long>> Create(CreateEmailCommand command)
        {
            return await Mediator.Send(command);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Update(long id, UpdateEmailCommand command)
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
            await Mediator.Send(new DeleteEmailCommand { Id = id });

            return NoContent();
        }
    }
}