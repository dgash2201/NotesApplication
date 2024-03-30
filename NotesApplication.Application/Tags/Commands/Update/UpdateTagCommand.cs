using MediatR;
using NotesApplication.Application.Common.Response;
using NotesApplication.Domain;

namespace NotesApplication.Application.Tags.Commands.Update
{
    public class UpdateTagCommand : IRequest<Response<Tag>>
    {
        public int Id { get; set; }

        public required string Name { get; set; }
    }
}
