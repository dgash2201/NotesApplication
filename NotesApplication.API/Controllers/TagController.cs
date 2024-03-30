using Asp.Versioning;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using NotesApplication.Application.Tags.Commands.Create;
using NotesApplication.Application.Tags.Commands.Delete;
using NotesApplication.Application.Tags.Commands.Update;
using NotesApplication.Application.Tags.Queries.Get;
using NotesApplication.Application.Tags.Queries.GetAll;

namespace NotesApplication.API.Controllers
{
    [Route("api/v{version:apiVersion}/function/tag")]
    [ApiController]
    [ApiVersion("1")]
    public class TagController : ControllerBase
    {
        private readonly IMediator _mediator;

        public TagController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("get-all")]
        public async Task<IActionResult> GetAll([FromBody] GetAllTagsQuery query)
        {
            var response = await _mediator.Send(query);

            return Ok(response);
        }

        [HttpPost("get")]
        public async Task<IActionResult> Get([FromBody] GetTagQuery query)
        {
            var response = await _mediator.Send(query);

            return Ok(response);
        }

        [HttpPost("create")]
        public async Task<IActionResult> Create([FromBody] CreateTagCommand command)
        {
            var response = await _mediator.Send(command);

            return Ok(response);
        }

        [HttpPost("update")]
        public async Task<IActionResult> Update([FromBody] UpdateTagCommand command)
        {
            var response = await _mediator.Send(command);

            return Ok(response);
        }

        [HttpPost("delete")]
        public async Task<IActionResult> Delete([FromBody] DeleteTagCommand command)
        {
            await _mediator.Send(command);

            return Ok();
        }
    }
}
