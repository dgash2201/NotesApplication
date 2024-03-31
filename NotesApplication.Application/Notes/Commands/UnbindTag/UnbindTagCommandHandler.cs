using MediatR;
using NotesApplication.Application.Common.Repository;
using NotesApplication.Application.Common.Responses;
using NotesApplication.Application.Tags.Queries.GetByName;
using NotesApplication.Domain;

namespace NotesApplication.Application.Notes.Commands.UnbindTag
{
    public class UnbindTagCommandHandler : IRequestHandler<UnbindNoteTagCommand, Response>
    {
        private readonly IRepository<Note> _repository;
        private readonly IMediator _mediator;

        public UnbindTagCommandHandler(IRepository<Note> repository, IMediator mediator)
        {
            _repository = repository;
            _mediator = mediator;
        }

        public async Task<Response> Handle(UnbindNoteTagCommand request, CancellationToken cancellationToken)
        {
            var contains = await _repository.ContainsAsync(x => x.Id == request.NoteId);

            if (!contains)
            {
                return new Response<Reminder>()
                {
                    IsSuccess = false,
                    Errors = new List<string>() { "Такой заметки не существует\n" },
                };
            }

            var tagName = request.TagName;
            var tagQuery = new GetTagByNameQuery() { Name = tagName };
            var tagResponse = await _mediator.Send(tagQuery);

            if (!tagResponse.IsSuccess)
            {
                return new Response<Reminder>()
                {
                    IsSuccess = false,
                    Errors = new List<string>() { "Такого тэга не сущетвует\n" },
                };
            }

            var note = await _repository.GetAsync(x => x.Id == request.NoteId);
            note.Tags.Remove(tagResponse.Value);

            await _repository.SaveChangesAsync();

            return new Response<Note>()
            {
                IsSuccess = true,
                Value = note
            };
        }
    }
}
