using Asp.Versioning;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using NotesApplication.Application.Reminders.Commands.BindTags;
using NotesApplication.Application.Reminders.Commands.UnbindTag;
using NotesApplication.Application.Tags.Commands.Create;
using NotesApplication.Application.Tags.Commands.Delete;
using NotesApplication.Application.Tags.Commands.Update;
using NotesApplication.Application.Tags.Queries.Get;
using NotesApplication.Application.Tags.Queries.GetAll;

namespace NotesApplication.API.Controllers
{
    [Route("api/v{version:apiVersion}/function/reminder")]
    [ApiController]
    [ApiVersion("1")]
    public class ReminderController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ReminderController(IMediator mediator)
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
            var response = await _mediator.Send(command);
            return Ok(response);
        }

        [HttpPost("bind-tags")]
        public async Task<IActionResult> BindTags([FromBody] BindTagsCommand command)
        {
            var response = await _mediator.Send(command);
            return Ok(response);
        }

        [HttpPost("unbind-tag")]
        public async Task<IActionResult> UnbindTag([FromBody] UnbindTagCommand command)
        {
            var response = await _mediator.Send(command);
            return Ok(response);
        }
    }
}
