using InstaConnect.Posts.Application.Features.Posts.Commands.Add;
using InstaConnect.Posts.Application.Features.Posts.Models;
using InstaConnect.Posts.Application.Features.Posts.Queries.GetAll;
using InstaConnect.Posts.Common.Tests.Features.Posts.Utilities.Assertions;
using InstaConnect.Posts.Common.Tests.Features.Posts.Utilities.Builders;
using InstaConnect.Posts.Domain.Features.Posts.Models;

namespace InstaConnect.Posts.Presentation.UnitTests.Features.Posts.Controllers.v1;

public class GetAllPostsControllerUnitTests : BasePostUnitTest
{
    private readonly User _user;
    private readonly Post _post;
    private readonly GetAllPostsRequestBuilder _requestBuilder;
    private readonly PostController _postController;

    public GetAllPostsControllerUnitTests()
    {
        _user = SetupUser();
        _post = SetupPost(_user);
        _requestBuilder = new(_post, _user);
        _postController = new(
            InstaConnectMapper,
            InstaConnectSender);

        var request = _requestBuilder.Create();
        var postQueryResponse = new PostQueryResponse(
            _post.Id,
            _post.Title,
            _post.Content,
            new(
                _user.Id,
                _user.UserName,
                _user.ProfileImage));
        var postQueryResponses = new List<PostQueryResponse>() { postQueryResponse };

        var response = new GetAllPostsQueryResponse(
            postQueryResponses,
            request.Pagination.Page,
            request.Pagination.PageSize,
            postQueryResponses.Count,
            false,
            false);

        InstaConnectSender.SetupGetAllQuery(request, response, CancellationToken);
    }

    [Fact]
    public async Task GetAllAsync_ShouldReturnOkStatusCode_WhenRequestIsValid()
    {
        // Arrange
        var request = _requestBuilder.Create();

        // Act
        var response = await _postController.GetAllAsync(request, CancellationToken);

        // Assert
        response.ShouldBeActionResultWithOkStatusCode();
    }

    [Fact]
    public async Task GetAllAsync_ShouldReturnResponse_WhenRequestIsValid()
    {
        // Arrange
        var request = _requestBuilder.Create();

        // Act
        var response = await _postController.GetAllAsync(request, CancellationToken);

        // Assert
        response.ShouldSatisfy(_post, _user, request);
    }

    [Fact]
    public async Task GetAllAsync_ShouldCallTheSender_WhenRequestIsValid()
    {
        // Arrange
        var request = _requestBuilder.Create();

        // Act
        await _postController.GetAllAsync(request, CancellationToken);

        // Assert
        await InstaConnectSender.ShouldReceiveOneSendAsync(request, CancellationToken);
    }
}
