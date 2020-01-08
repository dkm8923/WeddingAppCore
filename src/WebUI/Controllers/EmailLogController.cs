using CleanArchitecture.Application.EmailLogs.Commands.CreateEmailLog;
using CleanArchitecture.Application.EmailLogs.Commands.DeleteEmailLog;
using CleanArchitecture.Application.EmailLogs.Commands.UpdateEmailLog;
using CleanArchitecture.Application.EmailLogs.Queries;
using CleanArchitecture.WebUI.Common;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CleanArchitecture.WebUI.Controllers
{
    public class EmailLogController : ApiController
    {
        private readonly IFormatQueryString _formatQueryString;

        public EmailLogController(IFormatQueryString formatQueryString)
        {
            _formatQueryString = formatQueryString;
        }

        [HttpGet]
        public async Task<IEnumerable<EmailLogDto>> Get()
        {
            var queryStringReq = _formatQueryString.CreateRequestObject<GetEmailLogQuery>(Request);

            return await Mediator.Send(queryStringReq);
        }

        [HttpGet("{id}")]
        public async Task<IEnumerable<EmailLogDto>> Get(long id)
        {
            return await Mediator.Send(new GetEmailLogQuery { Id = id });
        }

        [HttpPost]
        public async Task<ActionResult<long>> Create(CreateEmailLogCommand command)
        {
            return await Mediator.Send(command);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Update(long id, UpdateEmailLogCommand command)
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
            await Mediator.Send(new DeleteEmailLogCommand { Id = id });

            return NoContent();
        }
    }
}