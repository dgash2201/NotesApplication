using MediatR;
using NotesApplication.Application.Common.Repository;
using NotesApplication.Application.Common.Responses;
using NotesApplication.Domain;

namespace NotesApplication.Application.Notes.Commands.Create
{
    public class CreateNoteCommandHandler : IRequestHandler<CreateNoteCommand, Response<Note>>
    {
        private IRepository<Note> _repository;

        public CreateNoteCommandHandler(IRepository<Note> repository)
        {
            _repository = repository;
        }

        public async Task<Response<Note>> Handle(CreateNoteCommand request, CancellationToken cancellationToken)
        {
            var contains = await _repository.ContainsAsync(x => x.Title == request.Title);

            if (!contains)
            {
                return new Response<Note>()
                {
                    IsSuccess = false,
                    Errors = new List<string>() { "Заметка с таким заголовком уже существует\n" },
                };
            }

            var note = new Note()
            {
                Title = request.Title,
                Text = request.Text,
            };

            _repository.Add(note);
            await _repository.SaveChangesAsync();

            return new Response<Note>
            {
                IsSuccess = true,
                Value = note,
            };
        }
    }
}
