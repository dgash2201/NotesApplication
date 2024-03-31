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

        [HttpPost("get")]
        public async Task<IActionResult> Get([FromBody] GetNoteQuery query)
        {
            var response = await _mediator.Send(query);
            return Ok(response);
        }

        [HttpPost("create")]
        public async Task<IActionResult> Create([FromBody] CreateNoteCommand command)
        {
            var response = await _mediator.Send(command);
            return Ok(response);
        }

        [HttpPost("update")]
        public async Task<IActionResult> Update([FromBody] UpdateNoteCommand command)
        {
            var response = await _mediator.Send(command);
            return Ok(response);
        }

        [HttpPost("delete")]
        public async Task<IActionResult> Delete([FromBody] DeleteNoteCommand command)
        {
            var response = await _mediator.Send(command);
            return Ok(response);
        }

        [HttpPost("bind-tags")]
        public async Task<IActionResult> BindNotes([FromBody] BindNoteTagsCommand command)
        {
            var response = await _mediator.Send(command);
            return Ok(response);
        }

        [HttpPost("unbind-tag")]
        public async Task<IActionResult> UnbindNote([FromBody] UnbindNoteTagCommand command)
        {
            var response = await _mediator.Send(command);
            return Ok(response);
        }
    }
}
