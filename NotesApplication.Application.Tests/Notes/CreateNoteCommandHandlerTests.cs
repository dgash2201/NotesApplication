using NotesApplication.Application.Common.Repository;
using NotesApplication.Application.Notes.Commands.Create;
using NotesApplication.Application.Tests.Common;
using NotesApplication.Domain;
using Xunit;

namespace NotesApplication.Application.Tests.Notes
{
    public class CreateNoteCommandHandlerTests
    {
        private readonly CreateNoteCommandHandler _handler;
        private readonly Application.Common.Repository.IRepository<Note> _repository;

        public CreateNoteCommandHandlerTests()
        {
            _repository = new TestRepository<Note>();
            _handler = new CreateNoteCommandHandler(_repository);
        }

        [Fact]
        public async Task Success()
        {
            // Arrange
            var title = "Note1";

            // Act
            var noteResponse = await _handler.Handle(new CreateNoteCommand { Title = title }, CancellationToken.None);


            // Assert
            Assert.NotNull(noteResponse);
            Assert.True(noteResponse.IsSuccess);
            Assert.Equal(title, noteResponse.Value.Title);
        }

        [Fact]
        public async Task NotCreateExistingNote()
        {
            // Arrange
            var title = "Note1";
            _repository.Add(new Note { Title = title });
            await _repository.SaveChangesAsync();

            // Act
            var noteResponse = await _handler.Handle(new CreateNoteCommand { Title = title }, CancellationToken.None);

            // Assert
            Assert.NotNull(noteResponse);
            Assert.False(noteResponse.IsSuccess);
        }
    }
}
