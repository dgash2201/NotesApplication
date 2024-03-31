using MediatR;
using NotesApplication.Application.Common.Repository;
using NotesApplication.Application.Common.Responses;
using NotesApplication.Domain;

namespace NotesApplication.Application.Notes.Commands.Delete
{
    public class DeleteNoteCommandHandler : IRequestHandler<DeleteNoteCommand, Response>
    {
        private IRepository<Note> _repository;

        public DeleteNoteCommandHandler(IRepository<Note> repository)
        {
            _repository = repository;
        }

        public async Task<Response> Handle(DeleteNoteCommand request, CancellationToken cancellationToken)
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

            var note = await _repository.GetAsync(x => x.Id == request.Id);

            _repository.Delete(note);

            return new Response()
            {
                IsSuccess = true
            };
        }
    }
}
