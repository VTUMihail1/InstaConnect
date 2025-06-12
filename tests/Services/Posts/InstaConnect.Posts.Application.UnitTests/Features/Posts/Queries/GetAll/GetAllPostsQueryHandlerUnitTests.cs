using InstaConnect.Common.Domain.Models.Pagination;
using InstaConnect.Posts.Application.Features.Posts.Queries.GetAll;
using InstaConnect.Posts.Domain.Features.Posts.Models;
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
        _user = SetupUser();
        _post = SetupPost(_user);
        _queryBuilder = new(_post, _user);
        _queryHandler = new(
            InstaConnectMapper,
            PostReadRepository);

        var query = _queryBuilder.Create();
        var posts = new List<Post>() { _post };

        var response = new PostQueryCollection(
            posts,
            query.Pagination.Page,
            query.Pagination.PageSize,
            posts.Count);

        PostReadRepository.SetupGetAllAsync(query, response, CancellationToken);
    }

    [Fact]
    public async Task Handle_ShouldGetAllPosts_WhenQueryIsValid()
    {
        // Arrange
        var query = _queryBuilder.Create();

        // Act
        await _queryHandler.Handle(query, CancellationToken);

        // Assert
        await PostReadRepository.ShouldReceiveOneGetAllAsync(query, CancellationToken);
    }

    [Fact]
    public async Task Handle_ShouldReturnResponse_WhenQueryIsValid()
    {
        // Arrange
        var query = _queryBuilder.Create();

        // Act
        var response = await _queryHandler.Handle(query, CancellationToken);

        // Assert
        response.ShouldSatisfy(_post, _user, query);
    }
}
