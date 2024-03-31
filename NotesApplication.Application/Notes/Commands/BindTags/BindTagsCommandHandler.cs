using MediatR;
using NotesApplication.Application.Common.Repository;
using NotesApplication.Application.Common.Responses;
using NotesApplication.Application.Tags.Commands.Create;
using NotesApplication.Application.Tags.Queries.GetByName;
using NotesApplication.Domain;

namespace NotesApplication.Application.Notes.Commands.BindTags
{
    public class BindTagsCommandHandler : IRequestHandler<BindNoteTagsCommand, Response<Note>>
    {
        private readonly IRepository<Note> _repository;
        private readonly IMediator _mediator;

        public BindTagsCommandHandler(IRepository<Note> repository, IMediator mediator)
        {
            _repository = repository;
            _mediator = mediator;
        }

        public async Task<Response<Note>> Handle(BindNoteTagsCommand request, CancellationToken cancellationToken)
        {
            var contains = await _repository.ContainsAsync(x => x.Id == request.NoteId);

            if (!contains)
            {
                return new Response<Note>()
                {
                    IsSuccess = false,
                    Errors = new List<string>() { "Такой заметки не существует\n" },
                };
            }

            var note = await _repository.GetAsync(x => x.Id == request.NoteId);

            foreach (var tagName in request.TagNames)
            {
                var tagQuery = new GetTagByNameQuery() { Name = tagName };
                var tagResponse = await _mediator.Send(tagQuery);

                if (!tagResponse.IsSuccess)
                {
                    var createTagCommand = new CreateTagCommand()
                    {
                        Name = tagName,
                    };

                    tagResponse = await _mediator.Send(createTagCommand);
                }

                if (tagResponse.IsSuccess)
                {
                    note.Tags.Add(tagResponse.Value);
                }
            }

            await _repository.SaveChangesAsync();

            return new Response<Note>()
            {
                IsSuccess = true,
                Value = note
            };
        }
    }
}
