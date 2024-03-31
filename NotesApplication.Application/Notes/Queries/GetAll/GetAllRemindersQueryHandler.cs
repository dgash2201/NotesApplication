using MediatR;
using NotesApplication.Application.Common.Repository;
using NotesApplication.Application.Common.Responses;
using NotesApplication.Domain;

namespace NotesApplication.Application.Notes.Queries.GetAll
{
    public class GetAllNotesQueryHandler 
        : IRequestHandler<GetAllNotesQuery, Response<IEnumerable<Note>>>
    {
        private IRepository<Note> _repository;

        public GetAllNotesQueryHandler(IRepository<Note> repository)
        {
            _repository = repository;
        }

        public async Task<Response<IEnumerable<Note>>> Handle(GetAllNotesQuery request, CancellationToken cancellationToken)
        {
            var notes = await _repository.GetAllAsync();

            return new Response<IEnumerable<Note>>
            {
                IsSuccess = true,
                Value = notes
            };
        }
    }
}
