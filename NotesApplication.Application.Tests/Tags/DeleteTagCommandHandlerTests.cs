using NotesApplication.Application.Tags.Commands.Delete;
using NotesApplication.Application.Tests.Common;
using NotesApplication.Domain;
using Xunit;

namespace NotesApplication.Application.Tests.Tags
{
    public class DeleteTagCommandHandlerTests
    {
        private readonly DeleteTagCommandHandler _handler;
        private readonly Application.Common.Repository.IRepository<Tag> _repository;

        public DeleteTagCommandHandlerTests()
        {
            _repository = new TestRepository<Tag>();
            _handler = new DeleteTagCommandHandler(_repository);
        }

        [Fact]
        public async Task Success()
        {
            // Arrange
            var id = 1;
            var title = "Tag1";
            var toDelete = new Tag
            {
                Id = id,
                Name = title,
            };

            _repository.Add(toDelete);

            // Act
            var tagResponse = await _handler.Handle(new DeleteTagCommand { Id = id }, CancellationToken.None);


            // Assert
            Assert.NotNull(tagResponse);
            Assert.True(tagResponse.IsSuccess);
            Assert.False(await _repository.ContainsAsync(x => x.Id == id));
        }
    }
}
