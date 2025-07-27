using InstaConnect.Common.Tests.Utilities.Types.Strings.Base;
using InstaConnect.Posts.Common.Tests.Features.Posts.Utilities;
using InstaConnect.Posts.Common.Tests.Features.Posts.Utilities.Assertions;
using InstaConnect.Posts.Common.Tests.Features.Posts.Utilities.Builders;
using InstaConnect.Posts.Common.Tests.Features.Posts.Utilities.DataAttributes.Id;
using InstaConnect.Posts.Common.Tests.Features.Posts.Utilities.DataAttributes.Title;
using InstaConnect.Posts.Common.Tests.Features.Posts.Utilities.Factories;
using InstaConnect.Posts.Common.Tests.Features.Users.Utilities.DataAttributes.Id;
using InstaConnect.Posts.Common.Tests.Features.Utilities;

using Microsoft.AspNetCore.TestHost;

namespace InstaConnect.Posts.Presentation.FunctionalTests.Features.Posts.Controllers.v1;

public class DeletePostFunctionalTests : BasePostFunctionalTest
{
    private User _user;
    private Post _post;

    private DeletePostApiRequest _request;
    private DeletePostApiRequestBuilder _requestBuilder;

    public DeletePostFunctionalTests(PostsWebApplicationFactory webApplicationFactory)
        : base(webApplicationFactory)
    {

    }

    protected override async Task OnInitializeAsync()
    {
        _user = await ServiceScope.AddUserAsync(CancellationToken);
        _post = PostTestFactory.Create(_user);

        _requestBuilder = new(_post);
        _request = _requestBuilder.Create();
    }

    [Fact]
    public async Task DeleteAsync_ShouldReturnUnauthorizedStatusCode_WhenRequestIsUnauthorized()
    {
        // Act
        var response = await HttpClient.DeletePostStatusCodeUnauthorizedAsync(_request, CancellationToken);

        // Assert
        response.ShouldBeUnauthorized();
    }

    [Fact]
    public async Task DeleteAsync_ShouldReturnUnauthorizedProblemDetails_WhenRequestIsUnauthorized()
    {
        // Act
        var response = await HttpClient.DeletePostProblemDetailsUnauthorizedAsync(_request, CancellationToken);

        // Assert
        response.ShouldSatisfyUnauthorized();
    }

    [Theory]
    [PostIdNullData]
    [PostIdEmptyData]
    [PostIdTooShortData]
    [PostIdTooLongData]
    public async Task DeleteAsync_ShouldHaveBadRequestStatusCode_WhenIdIsInvalid(
        IStringTransformer transformer)
    {
        // Arrange
        var request = _requestBuilder.WithId(_request.Id, transformer).Create();

        // Act
        var response = await HttpClient.DeletePostStatusCodeAsync(request, CancellationToken);

        // Assert
        response.ShouldBeBadRequest();
    }

    [Theory]
    [PostIdNullWithMessageData]
    [PostIdEmptyWithMessageData]
    [PostIdTooShortWithMessageData]
    [PostIdTooLongWithMessageData]
    public async Task DeleteAsync_ShouldHaveBadRequestProblemDetails_WhenIdIsInvalid(
        IStringTransformer transformer, string errorMessage)
    {
        // Arrange
        var request = _requestBuilder.WithId(_request.Id, transformer).Create();

        // Act
        var response = await HttpClient.DeletePostProblemDetailsAsync(request, CancellationToken);

        // Assert
        response.ShouldSatisfyBadRequest(errorMessage);
    }

    [Theory]
    [UserIdNullData]
    [UserIdEmptyData]
    [UserIdTooShortData]
    [UserIdTooLongData]
    public async Task DeleteAsync_ShouldHaveBadRequestStatusCode_WhenUserIdIsInvalid(
        IStringTransformer transformer)
    {
        // Arrange
        var request = _requestBuilder.WithUserId(_request.CurrentUserId, transformer).Create();

        // Act
        var response = await HttpClient.DeletePostStatusCodeAsync(request, CancellationToken);

        // Assert
        response.ShouldBeBadRequest();
    }

    [Theory]
    [UserIdNullWithMessageData]
    [UserIdEmptyWithMessageData]
    [UserIdTooShortWithMessageData]
    [UserIdTooLongWithMessageData]
    public async Task DeleteAsync_ShouldHaveBadRequestProblemDetails_WhenUserIdIsInvalid(
        IStringTransformer transformer, string errorMessage)
    {
        // Arrange
        var request = _requestBuilder.WithUserId(_request.CurrentUserId, transformer).Create();

        // Act
        var response = await HttpClient.DeletePostProblemDetailsAsync(request, CancellationToken);

        // Assert
        response.ShouldSatisfyBadRequest(errorMessage);
    }

    [Theory]
    [PostIdNotFoundData]
    public async Task DeleteAsync_ShouldHaveNotFoundStatusCode_WhenIdIsInvalid(
        IStringTransformer transformer)
    {
        // Arrange
        var request = _requestBuilder.WithId(_request.Id, transformer).Create();

        // Act
        var response = await HttpClient.DeletePostStatusCodeAsync(request, CancellationToken);

        // Assert
        response.ShouldBeNotFound();
    }

    [Theory]
    [PostIdNotFoundData]
    public async Task DeleteAsync_ShouldHavePostNotFoundProblemDetails_WhenIdIsInvalid(
        IStringTransformer transformer)
    {
        // Arrange
        var request = _requestBuilder.WithId(_request.Id, transformer).Create();

        // Act
        var response = await HttpClient.DeletePostProblemDetailsAsync(request, CancellationToken);

        // Assert
        response.ShouldSatisfyPostNotFoundProblemDetails(request.Id);
    }

    [Theory]
    [UserIdNotFoundData]
    public async Task DeleteAsync_ShouldHaveForbiddenStatusCode_WhenUserIdIsInvalid(
        IStringTransformer transformer)
    {
        // Arrange
        var request = _requestBuilder.WithId(_request.CurrentUserId, transformer).Create();

        // Act
        var response = await HttpClient.DeletePostStatusCodeAsync(request, CancellationToken);

        // Assert
        response.ShouldBeForbidden();
    }

    [Theory]
    [UserIdNotFoundData]
    public async Task DeleteAsync_ShouldHavePostForbiddenProblemDetails_WhenUserIdIsInvalid(
        IStringTransformer transformer)
    {
        // Arrange
        var request = _requestBuilder.WithId(_request.CurrentUserId, transformer).Create();

        // Act
        var response = await HttpClient.DeletePostProblemDetailsAsync(request, CancellationToken);

        // Assert
        response.ShouldSatisfyPostForbiddenProblemDetails(request.Id, request.CurrentUserId);
    }

    [Fact]
    public async Task DeleteAsync_ShouldHaveNoContentStatusCode_WhenRequestIsValid()
    {
        // Act
        var response = await HttpClient.DeletePostStatusCodeAsync(_request, CancellationToken);

        // Assert
        response.ShouldBeNoContent();
    }

    [Theory]
    [PostIdDifferentCaseData]
    public async Task DeleteAsync_ShouldHaveNoContentStatusCode_WhenRequestAndIdAreValid(
        IStringTransformer transformer)
    {
        // Arrange
        var request = _requestBuilder.WithId(_request.Id, transformer).Create();

        // Act
        var response = await HttpClient.DeletePostStatusCodeAsync(request, CancellationToken);

        // Assert
        response.ShouldBeNoContent();
    }

    [Theory]
    [UserIdDifferentCaseData]
    public async Task DeleteAsync_ShouldHaveNoContentStatusCode_WhenRequestAndUserIdAreValid(
        IStringTransformer transformer)
    {
        // Arrange
        var request = _requestBuilder.WithUserId(_request.CurrentUserId, transformer).Create();

        // Act
        var response = await HttpClient.DeletePostStatusCodeAsync(request, CancellationToken);

        // Assert
        response.ShouldBeNoContent();
    }

    [Fact]
    public async Task DeleteAsync_ShouldDeletePost_WhenRequestIsValid()
    {
        // Act
        await HttpClient.DeletePostAsync(_request, CancellationToken);
        var post = await ServiceScope.GetPostByIdAsync(_request.Id, CancellationToken);

        // Assert
        post.ShouldBeNull();
    }

    [Theory]
    [PostIdDifferentCaseData]
    public async Task DeleteAsync_ShouldDeletePost_WhenRequestAndIdAreValid(
        IStringTransformer transformer)
    {
        // Arrange
        var request = _requestBuilder.WithId(_request.Id, transformer).Create();

        // Act
        await HttpClient.DeletePostAsync(request, CancellationToken);
        var post = await ServiceScope.GetPostByIdAsync(_request.Id, CancellationToken);

        // Assert
        post.ShouldBeNull();
    }

    [Theory]
    [UserIdDifferentCaseData]
    public async Task DeleteAsync_ShouldDeletePost_WhenRequestAndUserIdAreValid(
        IStringTransformer transformer)
    {
        // Arrange
        var request = _requestBuilder.WithUserId(_request.CurrentUserId, transformer).Create();

        // Act
        await HttpClient.DeletePostAsync(request, CancellationToken);
        var post = await ServiceScope.GetPostByIdAsync(_request.Id, CancellationToken);

        // Assert
        post.ShouldBeNull();
    }

    [Fact]
    public async Task DeleteAsync_ShouldPublishEvent_WhenRequestIsValid()
    {
        // Act
        await HttpClient.DeletePostAsync(_request, CancellationToken);
        var hasPublshed = await EventHarness.HasPublishPostDeletedEventAsync(_post, CancellationToken);

        // Assert
        hasPublshed.ShouldBeTrue();
    }

    [Theory]
    [PostIdDifferentCaseData]
    public async Task DeleteAsync_ShouldPublishEvent_WhenRequestAndIdAreValid(
        IStringTransformer transformer)
    {
        // Arrange
        var request = _requestBuilder.WithId(_request.Id, transformer).Create();

        // Act
        await HttpClient.DeletePostAsync(request, CancellationToken);
        var hasPublshed = await EventHarness.HasPublishPostDeletedEventAsync(_post, CancellationToken);

        // Assert
        hasPublshed.ShouldBeTrue();
    }

    [Theory]
    [UserIdDifferentCaseData]
    public async Task DeleteAsync_ShouldPublishEvent_WhenRequestAndUserIdAreValid(
        IStringTransformer transformer)
    {
        // Arrange
        var request = _requestBuilder.WithUserId(_request.CurrentUserId, transformer).Create();

        // Act
        await HttpClient.DeletePostAsync(request, CancellationToken);
        var hasPublshed = await EventHarness.HasPublishPostDeletedEventAsync(_post, CancellationToken);

        // Assert
        hasPublshed.ShouldBeTrue();
    }
}
