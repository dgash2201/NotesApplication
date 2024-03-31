using MediatR;
using NotesApplication.Application.Common.Repository;
using NotesApplication.Application.Common.Responses;
using NotesApplication.Domain;

namespace NotesApplication.Application.Notes.Commands.UnbindTag
{
    public class UnbindTagCommandHandler : IRequestHandler<UnbindNoteTagCommand, Response>
    {
        private readonly IRepository<Note> _repository;

        public UnbindTagCommandHandler(IRepository<Note> repository)
        {
            _repository = repository;
        }

        public Task<Response> Handle(UnbindNoteTagCommand request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
