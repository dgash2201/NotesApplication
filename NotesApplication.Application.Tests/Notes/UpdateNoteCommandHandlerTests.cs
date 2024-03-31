using NotesApplication.Application.Common.Repository;
using NotesApplication.Application.Notes.Commands.Update;
using NotesApplication.Application.Tests.Common;
using NotesApplication.Domain;
using Xunit;

namespace NotesApplication.Application.Tests.Notes
{
    public class UpdateNoteCommandHandlerTests
    {
        private readonly UpdateNoteCommandHandler _handler;
        private readonly IRepository<Note> _repository;

        public UpdateNoteCommandHandlerTests()
        {
            _repository = new TestRepository<Note>();
            _handler = new UpdateNoteCommandHandler(_repository);
        }

        [Fact]
        public async Task Success()
        {
            // Arrange
            var id = 1;
            var title = "Note1";
            var newTitle = "Note2";
            var toUpdate = new Note
            {
                Id = id,
                Title = title,
            };

            _repository.Add(toUpdate);

            // Act
            var noteResponse = await _handler.Handle(new UpdateNoteCommand { Id = id, Title = newTitle }, CancellationToken.None);


            // Assert
            Assert.NotNull(noteResponse);
            Assert.True(noteResponse.IsSuccess);
            Assert.Equal(toUpdate.Title, newTitle);
        }
    }
}
