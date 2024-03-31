using NotesApplication.Application.Common.Repository;
using NotesApplication.Application.Notes.Queries.Get;
using NotesApplication.Application.Tests.Common;
using NotesApplication.Domain;
using Xunit;

namespace NotesApplication.Application.Tests.Notes
{
    public class GetNoteQueryHandlerTests
    {
        private readonly GetNoteQueryHandler _handler;
        private readonly IRepository<Note> _repository;

        public GetNoteQueryHandlerTests()
        {
            _repository = new TestRepository<Note>();
            _handler = new GetNoteQueryHandler(_repository);
        }

        [Fact]
        public async Task Success()
        {
            // Arrange
            var note = new Note()
            {
                Id = 1,
                Title = "note1"
            };

            _repository.Add(note);

            // Act
            var noteResponse = await _handler.Handle(new GetNoteQuery { Id = note.Id }, CancellationToken.None);


            // Assert
            Assert.NotNull(noteResponse);
            Assert.True(noteResponse.IsSuccess);
            Assert.Equal(note.Title, noteResponse.Value.Title);
        }
    }
}
