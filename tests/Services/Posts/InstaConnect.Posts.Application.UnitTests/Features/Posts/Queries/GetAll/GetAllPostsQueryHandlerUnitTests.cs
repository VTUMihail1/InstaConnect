using InstaConnect.Posts.Application.Features.Posts.Queries.GetAll;
using InstaConnect.Posts.Domain.Features.Posts.Models.Responses;
using InstaConnect.Posts.Domain.Features.Users.Models.Entities;

namespace InstaConnect.Posts.Application.UnitTests.Features.Posts.Queries.GetAll;

public class GetAllPostsQueryHandlerUnitTests : BasePostUnitTest
{
    private readonly User _user;
    private readonly Post _post;
    private readonly GetAllPostsQueryBuilder _queryBuilder;
    private readonly GetAllPostsQueryHandler _queryHandler;

    public GetAllPostsQueryHandlerUnitTests()
    {
        _user = new UserBuilder().Create();
        _post = new PostBuilder(_user).Create();
        _queryBuilder = new(_post, _user);
        _queryHandler = new(
            PostService,
            ApplicationMapper);

        var request = _queryBuilder.Create();

        PostService.SetupGetAllRequest(request, _post, _user, CancellationToken);
    }

    [Fact]
    public async Task Handle_ShouldReturnResponse_WhenRequestIsValid()
    {
        // Arrange
        var request = _queryBuilder.Create();

        // Act
        var response = await _queryHandler.Handle(request, CancellationToken);

        // Assert
        response.ShouldSatisfy(_post, _user, request);
    }

    [Fact]
    public async Task Handle_ShouldCallPostServiceGetAllAsync_WhenRequestIsValid()
    {
        // Arrange
        var request = _queryBuilder.Create();

        // Act
        await _queryHandler.Handle(request, CancellationToken);

        // Assert
        await PostService.ShouldReceiveOneGetAllAsync(request, CancellationToken);
    }
}
