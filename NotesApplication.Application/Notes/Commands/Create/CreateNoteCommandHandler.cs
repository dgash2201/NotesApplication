using MediatR;
using NotesApplication.Application.Common.Repository;
using NotesApplication.Application.Common.Response;
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
