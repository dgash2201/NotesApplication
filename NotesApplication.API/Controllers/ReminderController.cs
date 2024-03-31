using Asp.Versioning;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using NotesApplication.Application.Reminders.Commands.BindTags;
using NotesApplication.Application.Reminders.Commands.Create;
using NotesApplication.Application.Reminders.Commands.Delete;
using NotesApplication.Application.Reminders.Commands.UnbindTag;
using NotesApplication.Application.Reminders.Commands.Update;
using NotesApplication.Application.Reminders.Queries.Get;
using NotesApplication.Application.Reminders.Queries.GetAll;

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


        /// <summary>
        /// Получить все напоминания
        /// </summary>
        /// <param name="query"></param>
        /// <returns></returns>
        [HttpPost("get-all")]
        public async Task<IActionResult> GetAll([FromBody] GetAllRemindersQuery query)
        {
            var response = await _mediator.Send(query);
            return Ok(response);
        }

        [HttpPost("get")]
        public async Task<IActionResult> Get([FromBody] GetReminderQuery query)
        {
            var response = await _mediator.Send(query);
            return Ok(response);
        }

        [HttpPost("create")]
        public async Task<IActionResult> Create([FromBody] CreateReminderCommand command)
        {
            var response = await _mediator.Send(command);
            return Ok(response);
        }

        [HttpPost("update")]
        public async Task<IActionResult> Update([FromBody] UpdateReminderCommand command)
        {
            var response = await _mediator.Send(command);
            return Ok(response);
        }

        [HttpPost("delete")]
        public async Task<IActionResult> Delete([FromBody] DeleteReminderCommand command)
        {
            var response = await _mediator.Send(command);
            return Ok(response);
        }

        [HttpPost("bind-tags")]
        public async Task<IActionResult> BindReminders([FromBody] BindReminderTagsCommand command)
        {
            var response = await _mediator.Send(command);
            return Ok(response);
        }

        [HttpPost("unbind-tag")]
        public async Task<IActionResult> UnbindReminder([FromBody] UnbindReminderTagCommand command)
        {
            var response = await _mediator.Send(command);
            return Ok(response);
        }
    }
}
