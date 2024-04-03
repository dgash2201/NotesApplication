using Asp.Versioning;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using NotesApplication.Application.Common.Responses;
using NotesApplication.Application.Tags.Commands.Create;
using NotesApplication.Application.Tags.Commands.Delete;
using NotesApplication.Application.Tags.Commands.Update;
using NotesApplication.Application.Tags.Queries.Get;
using NotesApplication.Application.Tags.Queries.GetAll;
using NotesApplication.Domain;

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

        /// <summary>
        /// Получить все тэги
        /// </summary>
        /// <param name="query"></param>
        /// <returns></returns>
        [HttpPost("get-all")]
        public async Task<IActionResult> GetAll([FromBody] GetAllTagsQuery query)
        {
            var response = await _mediator.Send(query);
            return Ok(response);
        }

        /// <summary>
        /// Получить тэг
        /// </summary>
        /// <param name="query"></param>
        /// <returns></returns>
        [HttpPost("get")]
        [ProducesResponseType(typeof(Response<Tag>), 200)]
        public async Task<IActionResult> Get([FromBody] GetTagQuery query)
        {
            var response = await _mediator.Send(query);
            return Ok(response);
        }

        /// <summary>
        /// Создать тэг
        /// </summary>
        /// <param name="query"></param>
        /// <returns></returns>
        [HttpPost("create")]
        public async Task<IActionResult> Create([FromBody] CreateTagCommand command)
        {
            var response = await _mediator.Send(command);
            return Ok(response);
        }

        /// <summary>
        /// Обновить тэг
        /// </summary>
        /// <param name="query"></param>
        /// <returns></returns>
        [HttpPost("update")]
        public async Task<IActionResult> Update([FromBody] UpdateTagCommand command)
        {
            var response = await _mediator.Send(command);
            return Ok(response);
        }

        /// <summary>
        /// Удалить тэг
        /// </summary>
        /// <param name="query"></param>
        /// <returns></returns>
        [HttpPost("delete")]
        public async Task<IActionResult> Delete([FromBody] DeleteTagCommand command)
        {
            var response = await _mediator.Send(command);
            return Ok(response);
        }
    }
}
