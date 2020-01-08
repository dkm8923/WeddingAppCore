using CleanArchitecture.Application.Families.Commands.CreateFamily;
using CleanArchitecture.Application.Families.Commands.DeleteFamily;
using CleanArchitecture.Application.Families.Commands.UpdateFamily;
using CleanArchitecture.Application.Families.Queries;
using CleanArchitecture.WebUI.Common;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CleanArchitecture.WebUI.Controllers
{
    public class FamilyController : ApiController
    {
        private readonly IFormatQueryString _formatQueryString;

        public FamilyController(IFormatQueryString formatQueryString)
        {
            _formatQueryString = formatQueryString;
        }

        [HttpGet]
        public async Task<IEnumerable<FamilyDto>> Get()
        {
            var queryStringReq = _formatQueryString.CreateRequestObject<GetFamilyQuery>(Request);

            return await Mediator.Send(queryStringReq);
        }

        [HttpGet("{id}")]
        public async Task<IEnumerable<FamilyDto>> Get(long id)
        {
            return await Mediator.Send(new GetFamilyQuery { Id = id });
        }

        [HttpPost]
        public async Task<ActionResult<long>> Create(CreateFamilyCommand command)
        {
            return await Mediator.Send(command);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Update(long id, UpdateFamilyCommand command)
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
            await Mediator.Send(new DeleteFamilyCommand { Id = id });

            return NoContent();
        }
    }
}