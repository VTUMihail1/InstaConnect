using InstaConnect.Posts.Application.Features.PostComments.Queries.GetById;

namespace InstaConnect.Posts.Application.UnitTests.Features.PostComments.Queries.GetById;

public class GetPostCommentByIdQueryHandlerUnitTests : BasePostCommentUnitTest
{
    private readonly GetPostCommentByIdQueryHandler _queryHandler;

    public GetPostCommentByIdQueryHandlerUnitTests()
    {
        _queryHandler = new(
            InstaConnectMapper,
            PostCommentReadRepository);
    }

    [Fact]
    public async Task Handle_ShouldThrowPostCommentNotFoundException_WhenIdIsInvalid()
    {
        // Arrange
        var existingPostComment = CreatePostComment();
        var query = new GetPostCommentByIdQuery(PostCommentTestUtilities.InvalidId);

        // Act
        var action = async () => await _queryHandler.Handle(query, CancellationToken);

        // Assert
        await action.Should().ThrowAsync<PostCommentNotFoundException>();
    }

    [Fact]
    public async Task Handle_ShouldCallRepositoryWithGetByIdMethod_WhenQueryIsValid()
    {
        // Arrange
        var existingPostComment = CreatePostComment();
        var query = new GetPostCommentByIdQuery(existingPostComment.Id);

        // Act
        await _queryHandler.Handle(query, CancellationToken);

        // Assert
        await PostCommentReadRepository
            .Received(1)
            .GetByIdAsync(existingPostComment.Id, CancellationToken);
    }

    [Fact]
    public async Task Handle_ShouldReturnPostCommentViewModelCollection_WhenQueryIsValid()
    {
        // Arrange
        var existingPostComment = CreatePostComment();
        var query = new GetPostCommentByIdQuery(existingPostComment.Id);

        // Act
        var response = await _queryHandler.Handle(query, CancellationToken);

        // Assert
        response
            .Should()
            .Match<PostCommentQueryViewModel>(m => m.Id == existingPostComment.Id &&
                                              m.UserId == existingPostComment.UserId &&
                                              m.UserName == existingPostComment.User.UserName &&
                                              m.UserProfileImage == existingPostComment.User.ProfileImage &&
                                              m.PostId == existingPostComment.PostId &&
                                              m.Content == existingPostComment.Content);
    }
}
