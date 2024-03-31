using MediatR;
using NotesApplication.Application.Common.Repository;
using NotesApplication.Application.Common.Responses;
using NotesApplication.Domain;

namespace NotesApplication.Application.Notes.Commands.Update
{
    public class UpdateNoteCommandHandler : IRequestHandler<UpdateNoteCommand, Response>
    {
        private IRepository<Note> _repository;

        public UpdateNoteCommandHandler(IRepository<Note> repository)
        {
            _repository = repository;
        }

        public async Task<Response> Handle(UpdateNoteCommand request, CancellationToken cancellationToken)
        {
            var contains = await _repository.ContainsAsync(x => x.Id == request.Id);

            if (!contains)
            {
                return new Response()
                {
                    IsSuccess = false,
                    Errors = new List<string>() { "Такой заметки не существует\n" },
                };
            }

            var note = await _repository.GetAsync(request.Id);

            note.Title = request.Title;
            note.Text = request.Text;

            return new Response()
            {
                IsSuccess = true,
            };
        }
    }
}
