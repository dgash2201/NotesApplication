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


        /// <summary>
        /// Получить напоминание
        /// </summary>
        /// <param name="query"></param>
        /// <returns></returns>
        [HttpPost("get")]
        public async Task<IActionResult> Get([FromBody] GetReminderQuery query)
        {
            var response = await _mediator.Send(query);
            return Ok(response);
        }

        /// <summary>
        /// Создать напоминание
        /// </summary>
        /// <param name="query"></param>
        /// <returns></returns>
        [HttpPost("create")]
        public async Task<IActionResult> Create([FromBody] CreateReminderCommand command)
        {
            var response = await _mediator.Send(command);
            return Ok(response);
        }

        /// <summary>
        /// Обновить напоминание
        /// </summary>
        /// <param name="query"></param>
        /// <returns></returns>
        [HttpPost("update")]
        public async Task<IActionResult> Update([FromBody] UpdateReminderCommand command)
        {
            var response = await _mediator.Send(command);
            return Ok(response);
        }

        /// <summary>
        /// Удалить напоминание
        /// </summary>
        /// <param name="query"></param>
        /// <returns></returns>
        [HttpPost("delete")]
        public async Task<IActionResult> Delete([FromBody] DeleteReminderCommand command)
        {
            var response = await _mediator.Send(command);
            return Ok(response);
        }

        /// <summary>
        /// Привязать тэги к напоминанию
        /// </summary>
        /// <param name="query"></param>
        /// <returns></returns>
        [HttpPost("bind-tags")]
        public async Task<IActionResult> BindTags([FromBody] BindReminderTagsCommand command)
        {
            var response = await _mediator.Send(command);
            return Ok(response);
        }

        /// <summary>
        /// Отвязать тэг от напоминания
        /// </summary>
        /// <param name="query"></param>
        /// <returns></returns>
        [HttpPost("unbind-tag")]
        public async Task<IActionResult> UnbindTag([FromBody] UnbindReminderTagCommand command)
        {
            var response = await _mediator.Send(command);
            return Ok(response);
        }
    }
}
