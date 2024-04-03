using NotesApplication.Application.Common.Repository;
using NotesApplication.Application.Tags.Commands.Create;
using NotesApplication.Application.Tests.Common;
using NotesApplication.Domain;
using Xunit;

namespace NotesApplication.Application.Tests.Tags
{
    public class CreateTagCommandHandlerTests
    {
        private readonly CreateTagCommandHandler _handler;
        private readonly IRepository<Tag> _repository;
        private static int _c = 0;

        public CreateTagCommandHandlerTests()
        {
            _repository = new TestRepository<Tag>();
            _handler = new CreateTagCommandHandler(_repository);    
        }

        [Fact]
        public async Task Success()
        {
            // Arrange
            var name = "Tag1";

            // Act
            var tagResponse = await _handler.Handle(new CreateTagCommand { Name = name }, CancellationToken.None);


            // Assert
            Assert.NotNull(tagResponse);
            Assert.True(tagResponse.IsSuccess);
            Assert.Equal(name, tagResponse.Value.Name);
        }

        [Fact]
        public async Task NotCreateExistingTag()
        {
            // Arrange
            var name = "Tag1";
            _repository.Add(new Tag { Name = name });
            await _repository.SaveChangesAsync();

            // Act
            var tagResponse = await _handler.Handle(new CreateTagCommand { Name = name }, CancellationToken.None);

            // Assert
            Assert.NotNull(tagResponse);
            Assert.False(tagResponse.IsSuccess);
        }
    }
}
