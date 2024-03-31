using MediatR;
using NotesApplication.Application.Common.Repository;
using NotesApplication.Application.Common.Responses;
using NotesApplication.Domain;

namespace NotesApplication.Application.Notes.Queries.Get
{
    public class GetNoteQueryHandler : IRequestHandler<GetNoteQuery, Response<Note>>
    {
        private IRepository<Note> _repository;

        public GetNoteQueryHandler(IRepository<Note> repository)
        {
            _repository = repository;
        }

        public async Task<Response<Note>> Handle(GetNoteQuery request, CancellationToken cancellationToken)
        {
            var contains = await _repository.ContainsAsync(x => x.Id == request.Id);

            if (!contains)
            {
                return new Response<Note>()
                {
                    IsSuccess = false,
                    Errors = new List<string>() { "Такого напоминания не существует\n" },
                };
            }

            var note = await _repository.GetAsync(x => x.Id == request.Id);

            return new Response<Note>()
            {
                IsSuccess = true,
                Value = note,
            };
        }
    }
}
