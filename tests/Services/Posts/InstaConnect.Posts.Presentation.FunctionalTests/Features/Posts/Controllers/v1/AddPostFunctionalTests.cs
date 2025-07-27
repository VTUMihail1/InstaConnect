using System.Security.Cryptography.Xml;

using InstaConnect.Common.Application.Abstractions;
using InstaConnect.Common.Tests.Utilities.Types.Strings.Base;
using InstaConnect.Posts.Common.Tests.Features.Posts.Utilities.Assertions;
using InstaConnect.Posts.Common.Tests.Features.Posts.Utilities.Builders;
using InstaConnect.Posts.Common.Tests.Features.Posts.Utilities.DataAttributes.Content;
using InstaConnect.Posts.Common.Tests.Features.Posts.Utilities.DataAttributes.Id;
using InstaConnect.Posts.Common.Tests.Features.Posts.Utilities.DataAttributes.Title;
using InstaConnect.Posts.Common.Tests.Features.Posts.Utilities.Factories;
using InstaConnect.Posts.Common.Tests.Features.Users.Utilities.Assertions;
using InstaConnect.Posts.Common.Tests.Features.Users.Utilities.DataAttributes.Id;
using InstaConnect.Posts.Common.Tests.Features.Utilities;

using Microsoft.Extensions.Localization;

namespace InstaConnect.Posts.Presentation.FunctionalTests.Features.Posts.Controllers.v1;

public class AddPostFunctionalTests : BasePostFunctionalTest
{
    private User _user;

    private AddPostApiRequest _request;
    private AddPostApiRequestBuilder _requestBuilder;

    public AddPostFunctionalTests(PostsWebApplicationFactory webApplicationFactory)
        : base(webApplicationFactory)
    {

    }

    protected override async Task OnInitializeAsync()
    {
        _user = await ServiceScope.AddUserAsync(CancellationToken);

        _requestBuilder = new(_user);
        _request = _requestBuilder.Create();
    }

    [Fact]
    public async Task AddAsync_ShouldReturnUnauthorizedStatusCode_WhenRequestIsUnauthorized()
    {
        // Act
        var response = await HttpClient.AddPostStatusCodeUnauthorizedAsync(_request, CancellationToken);

        // Assert
        response.ShouldBeUnauthorized();
    }

    [Fact]
    public async Task AddAsync_ShouldReturnUnauthorizedProblemDetails_WhenRequestIsUnauthorized()
    {
        // Act
        var response = await HttpClient.AddPostProblemDetailsUnauthorizedAsync(_request, CancellationToken);

        // Assert
        response.ShouldSatisfyUnauthorized();
    }

    [Theory]
    [UserIdNullData]
    [UserIdEmptyData]
    [UserIdTooShortData]
    [UserIdTooLongData]
    public async Task AddAsync_ShouldHaveBadRequestStatusCode_WhenUserIdIsInvalid(
        IStringTransformer transformer)
    {
        // Arrange
        var request = _requestBuilder.WithUserId(_request.CurrentUserId, transformer).Create();

        // Act
        var response = await HttpClient.AddPostStatusCodeAsync(request, CancellationToken);

        // Assert
        response.ShouldBeBadRequest();
    }

    [Theory]
    [UserIdNullWithMessageData]
    [UserIdEmptyWithMessageData]
    [UserIdTooShortWithMessageData]
    [UserIdTooLongWithMessageData]
    public async Task AddAsync_ShouldHaveBadRequestProblemDetails_WhenUserIdIsInvalid(
        IStringTransformer transformer, string errorMessage)
    {
        // Arrange
        var request = _requestBuilder.WithUserId(_request.CurrentUserId, transformer).Create();

        // Act
        var response = await HttpClient.AddPostProblemDetailsAsync(request, CancellationToken);

        // Assert
        response.ShouldSatisfyBadRequest(errorMessage);
    }

    [Theory]
    [PostTitleNullData]
    [PostTitleEmptyData]
    [PostTitleTooShortData]
    [PostTitleTooLongData]
    public async Task AddAsync_ShouldHaveBadRequestStatusCode_WhenTitleIsInvalid(
        IStringTransformer transformer)
    {
        // Arrange
        var request = _requestBuilder.WithTitle(_request.Body.Title, transformer).Create();

        // Act
        var response = await HttpClient.AddPostStatusCodeAsync(request, CancellationToken);

        // Assert
        response.ShouldBeBadRequest();
    }

    [Theory]
    [PostTitleNullWithMessageData]
    [PostTitleEmptyWithMessageData]
    [PostTitleTooShortWithMessageData]
    [PostTitleTooLongWithMessageData]
    public async Task AddAsync_ShouldHaveBadRequestProblemDetails_WhenTitleIsInvalid(
        IStringTransformer transformer, string errorMessage)
    {
        // Arrange
        var request = _requestBuilder.WithTitle(_request.Body.Title, transformer).Create();

        // Act
        var response = await HttpClient.AddPostProblemDetailsAsync(request, CancellationToken);

        // Assert
        response.ShouldSatisfyBadRequest(errorMessage);
    }

    [Theory]
    [PostContentNullData]
    [PostContentEmptyData]
    [PostContentTooShortData]
    [PostContentTooLongData]
    public async Task AddAsync_ShouldHaveBadRequestStatusCode_WhenContentIsInvalid(
        IStringTransformer transformer)
    {
        // Arrange
        var request = _requestBuilder.WithContent(_request.Body.Content, transformer).Create();

        // Act
        var response = await HttpClient.AddPostStatusCodeAsync(request, CancellationToken);

        // Assert
        response.ShouldBeBadRequest();
    }

    [Theory]
    [PostContentNullWithMessageData]
    [PostContentEmptyWithMessageData]
    [PostContentTooShortWithMessageData]
    [PostContentTooLongWithMessageData]
    public async Task AddAsync_ShouldHaveBadRequestProblemDetails_WhenContentIsInvalid(
        IStringTransformer transformer, string errorMessage)
    {
        // Arrange
        var request = _requestBuilder.WithContent(_request.Body.Content, transformer).Create();

        // Act
        var response = await HttpClient.AddPostProblemDetailsAsync(request, CancellationToken);

        // Assert
        response.ShouldSatisfyBadRequest(errorMessage);
    }

    [Theory]
    [UserIdNotFoundData]
    public async Task AddAsync_ShouldHaveNotFoundStatusCode_WhenUserIdIsInvalid(
        IStringTransformer transformer)
    {
        // Arrange
        var request = _requestBuilder.WithUserId(_request.CurrentUserId, transformer).Create();

        // Act
        var response = await HttpClient.AddPostStatusCodeAsync(request, CancellationToken);

        // Assert
        response.ShouldBeNotFound();
    }

    [Theory]
    [UserIdNotFoundData]
    public async Task AddAsync_ShouldHaveUserNotFoundProblemDetails_WhenUserIdIsInvalid(
        IStringTransformer transformer)
    {
        // Arrange
        var request = _requestBuilder.WithUserId(_request.CurrentUserId, transformer).Create();

        // Act
        var response = await HttpClient.AddPostProblemDetailsAsync(request, CancellationToken);

        // Assert
        response.ShouldSatisfyUserNotFoundProblemDetails(request.CurrentUserId);
    }

    [Fact]
    public async Task AddAsync_ShouldHaveOkStatusCode_WhenRequestIsValid()
    {
        // Act
        var response = await HttpClient.AddPostStatusCodeAsync(_request, CancellationToken);

        // Assert
        response.ShouldBeOk();
    }

    [Theory]
    [UserIdDifferentCaseData]
    public async Task AddAsync_ShouldHaveOkStatusCode_WhenRequestAndUserIdAreValid(
        IStringTransformer transformer)
    {
        // Arrange
        var request = _requestBuilder.WithUserId(_request.CurrentUserId, transformer).Create();

        // Act
        var response = await HttpClient.AddPostStatusCodeAsync(request, CancellationToken);

        // Assert
        response.ShouldBeOk();
    }

    [Fact]
    public async Task AddAsync_ShouldReturnResponse_WhenRequestIsValid()
    {
        // Act
        var response = await HttpClient.AddPostAsync(_request, CancellationToken);
        var post = await ServiceScope.GetPostByIdAsync(response.Id, CancellationToken);

        // Assert
        response.ShouldSatisfy(post);
    }

    [Theory]
    [UserIdDifferentCaseData]
    public async Task AddAsync_ShouldReturnResponse_WhenRequestAndUserIdAreValid(
        IStringTransformer transformer)
    {
        // Arrange
        var request = _requestBuilder.WithUserId(_request.CurrentUserId, transformer).Create();

        // Act
        var response = await HttpClient.AddPostAsync(request, CancellationToken);
        var post = await ServiceScope.GetPostByIdAsync(response.Id, CancellationToken);

        // Assert
        response.ShouldSatisfy(post);
    }

    [Fact]
    public async Task AddAsync_ShouldAddPost_WhenRequestIsValid()
    {
        // Act
        var response = await HttpClient.AddPostAsync(_request, CancellationToken);
        var post = await ServiceScope.GetPostByIdAsync(response.Id, CancellationToken);

        // Assert
        post.ShouldSatisfy(_request);
    }

    [Theory]
    [UserIdDifferentCaseData]
    public async Task AddAsync_ShouldAddPost_WhenRequestAndUserIdAreValid(
        IStringTransformer transformer)
    {
        // Arrange
        var request = _requestBuilder.WithUserId(_request.CurrentUserId, transformer).Create();

        // Act
        var response = await HttpClient.AddPostAsync(request, CancellationToken);
        var post = await ServiceScope.GetPostByIdAsync(response.Id, CancellationToken);

        // Assert
        post.ShouldSatisfy(_request);
    }

    [Fact]
    public async Task AddAsync_ShouldPublishEvent_WhenRequestIsValid()
    {
        // Act
        var response = await HttpClient.AddPostAsync(_request, CancellationToken);
        var post = await ServiceScope.GetPostByIdAsync(response.Id, CancellationToken);
        var eventWasPublished = await EventHarness.HasPublishPostAddedEventAsync(post, CancellationToken);

        // Assert
        eventWasPublished.ShouldBeTrue();
    }

    [Theory]
    [UserIdDifferentCaseData]
    public async Task AddAsync_ShouldPublishEvent_WhenRequestAndUserIdAreValid(
        IStringTransformer transformer)
    {
        // Arrange
        var request = _requestBuilder.WithUserId(_request.CurrentUserId, transformer).Create();

        // Act
        var response = await HttpClient.AddPostAsync(request, CancellationToken);
        var post = await ServiceScope.GetPostByIdAsync(response.Id, CancellationToken);
        var eventWasPublished = await EventHarness.HasPublishPostAddedEventAsync(post, CancellationToken);

        // Assert
        eventWasPublished.ShouldBeTrue();
    }
}
