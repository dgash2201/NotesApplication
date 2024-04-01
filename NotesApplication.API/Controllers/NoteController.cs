using Asp.Versioning;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using NotesApplication.Application.Notes.Commands.BindTags;
using NotesApplication.Application.Notes.Commands.UnbindTag;
using NotesApplication.Application.Notes.Commands.Create;
using NotesApplication.Application.Notes.Commands.Delete;
using NotesApplication.Application.Notes.Commands.Update;
using NotesApplication.Application.Notes.Queries.Get;
using NotesApplication.Application.Notes.Queries.GetAll;

namespace NotesApplication.API.Controllers
{
    [Route("api/v{version:apiVersion}/function/note")]
    [ApiController]
    [ApiVersion("1")]
    public class NoteController : ControllerBase
    {
        private readonly IMediator _mediator;

        public NoteController(IMediator mediator)
        {
            _mediator = mediator;
        }

        /// <summary>
        /// Получить все заметки
        /// </summary>
        /// <param name="query"></param>
        /// <returns></returns>
        [HttpPost("get-all")]
        public async Task<IActionResult> GetAll([FromBody] GetAllNotesQuery query)
        {
            var response = await _mediator.Send(query);
            return Ok(response);
        }

        /// <summary>
        /// Получить заметку
        /// </summary>
        /// <param name="query"></param>
        /// <returns></returns>
        [HttpPost("get")]
        public async Task<IActionResult> Get([FromBody] GetNoteQuery query)
        {
            var response = await _mediator.Send(query);
            return Ok(response);
        }

        /// <summary>
        /// Создать заметку
        /// </summary>
        /// <param name="query"></param>
        /// <returns></returns>
        [HttpPost("create")]
        public async Task<IActionResult> Create([FromBody] CreateNoteCommand command)
        {
            var response = await _mediator.Send(command);
            return Ok(response);
        }

        /// <summary>
        /// Обновить заметку
        /// </summary>
        /// <param name="query"></param>
        /// <returns></returns>
        [HttpPost("update")]
        public async Task<IActionResult> Update([FromBody] UpdateNoteCommand command)
        {
            var response = await _mediator.Send(command);
            return Ok(response);
        }

        /// <summary>
        /// Удалить заметку
        /// </summary>
        /// <param name="query"></param>
        /// <returns></returns>
        [HttpPost("delete")]
        public async Task<IActionResult> Delete([FromBody] DeleteNoteCommand command)
        {
            var response = await _mediator.Send(command);
            return Ok(response);
        }

        /// <summary>
        /// Привязать тэги к заметке
        /// </summary>
        /// <param name="query"></param>
        /// <returns></returns>
        [HttpPost("bind-tags")]
        public async Task<IActionResult> BindTags([FromBody] BindNoteTagsCommand command)
        {
            var response = await _mediator.Send(command);
            return Ok(response);
        }

        /// <summary>
        /// Отвязать тэг от заметки
        /// </summary>
        /// <param name="query"></param>
        /// <returns></returns>
        [HttpPost("unbind-tag")]
        public async Task<IActionResult> UnbindTag([FromBody] UnbindNoteTagCommand command)
        {
            var response = await _mediator.Send(command);
            return Ok(response);
        }
    }
}
