using MediatR;
using NotesApplication.Application.Common.Responses;

namespace NotesApplication.Application.Tags.Commands.Delete
{
    public class DeleteTagCommand : IRequest<Response>
    {
        public int Id { get; set; }
    }
}
