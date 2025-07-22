using InstaConnect.Posts.Common.Tests.Features.Posts.Utilities.Assertions;
using InstaConnect.Posts.Common.Tests.Features.Posts.Utilities.Builders;
using InstaConnect.Posts.Common.Tests.Features.Posts.Utilities.Factories;
using InstaConnect.Posts.Common.Tests.Features.Users.Utilities.Factories;
using InstaConnect.Posts.Domain.Features.Posts.Models.Entities;

namespace InstaConnect.Posts.Presentation.UnitTests.Features.Posts.Controllers.v1;

public class AddPostControllerUnitTests : BasePostUnitTest
{
    private readonly User _user;
    private readonly Post _post;

    private readonly AddPostApiRequest _request;
    private readonly AddPostApiRequestBuilder _requestBuilder;

    private readonly PostController _postController;

    public AddPostControllerUnitTests()
    {
        _user = UserTestFactory.Create();
        _post = PostTestFactory.Create(_user);

        _requestBuilder = new(_post);
        _request = _requestBuilder.Create();

        _postController = new(ApplicationMapper, ApplicationSender);

        ApplicationSender.SetupAddCommand(_request, _post, CancellationToken);
    }

    [Fact]
    public async Task AddAsync_ShouldReturnOkStatusCode_WhenRequestIsValid()
    {
        // Act
        var response = await _postController.AddAsync(_request, CancellationToken);

        // Assert
        response.ShouldBeActionResultWithOkStatusCode();
    }

    [Fact]
    public async Task AddAsync_ShouldReturnResponse_WhenRequestIsValid()
    {
        // Act
        var response = await _postController.AddAsync(_request, CancellationToken);

        // Assert
        response.ShouldSatisfy(_post);
    }

    [Fact]
    public async Task AddAsync_ShouldCallTheApplicationSenderSendAsync_WhenRequestIsValid()
    {
        // Act
        await _postController.AddAsync(_request, CancellationToken);

        // Assert
        await ApplicationSender.ShouldReceiveOneSendAsync(_request, CancellationToken);
    }
}
