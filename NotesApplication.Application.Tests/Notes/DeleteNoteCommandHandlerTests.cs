using NotesApplication.Application.Notes.Commands.Delete;
using NotesApplication.Application.Tests.Common;
using NotesApplication.Domain;
using Xunit;

namespace NotesApplication.Application.Tests.Notes
{
    public class DeleteNoteCommandHandlerTests
    {
        private readonly DeleteNoteCommandHandler _handler;
        private readonly Application.Common.Repository.IRepository<Note> _repository;

        public DeleteNoteCommandHandlerTests()
        {
            _repository = new TestRepository<Note>();
            _handler = new DeleteNoteCommandHandler(_repository);
        }

        [Fact]
        public async Task Success()
        {
            // Arrange
            var id = 1;
            var title = "Note1";
            var toDelete = new Note
            {
                Id = id,
                Title = title,
            };

            _repository.Add(toDelete);

            // Act
            var noteResponse = await _handler.Handle(new DeleteNoteCommand { Id = id }, CancellationToken.None);


            // Assert
            Assert.NotNull(noteResponse);
            Assert.True(noteResponse.IsSuccess);
            Assert.False(await _repository.ContainsAsync(x => x.Id == id));
        }

    }
}
