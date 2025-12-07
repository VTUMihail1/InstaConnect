using InstaConnect.Common.Domain.Models;
using InstaConnect.Posts.Domain.Features.PostComments.Models.Requests;

namespace InstaConnect.Posts.Application.Tests.Integration.Features.PostComments.Queries;

public class GetAllPostCommentsQueryHandlerIntegrationTests : BasePostCommentApplicationIntegrationTest
{
    private readonly GetAllPostCommentsQueryRequestBuilderFactory _requestBuilderFactory;
    private readonly GetAllPostCommentsQueryRequestBuilder _requestBuilder;
    private readonly GetAllPostCommentsQueryRequest _request;

    public GetAllPostCommentsQueryHandlerIntegrationTests(PostsWebApplicationFactory webApplicationFactory)
        : base(webApplicationFactory)
    {
        _requestBuilderFactory = new();
        _requestBuilder = _requestBuilderFactory.Create(PostComment, User);
        _request = _requestBuilder.Build();
    }

    protected override async Task OnInitializeAsync()
    {
        await ServiceScope.AddUserAsync(User, CancellationToken);
        await ServiceScope.AddPostAsync(Post, CancellationToken);
        await ServiceScope.AddPostCommentAsync(PostComment, CancellationToken);
    }

    [Theory]
    [PostIdNullWithMessageData]
    [PostIdEmptyWithMessageData]
    [PostIdTooShortWithMessageData]
    [PostIdTooLongWithMessageData]
    public async Task SendAsync_ShouldThrowValidationException_WhenIdIsInvalid(
        IStringTransformer transformer, IStringMessageTransformer messageTransformer)
    {
        // Arrange
        var request = _requestBuilder.WithId(transformer).Build();

        // Act


        // Assert
        await ApplicationSender.ShouldThrowInvalidValidationExceptionForIdAsync(messageTransformer, request, CancellationToken);
    }

    [Theory]
    [UserIdTooLongWithMessageData]
    public async Task SendAsync_ShouldThrowValidationException_WhenUserIdIsInvalid(
        IStringTransformer transformer, IStringMessageTransformer messageTransformer)
    {
        // Arrange
        var request = _requestBuilder.WithUserId(transformer).Build();

        // Act


        // Assert
        await ApplicationSender.ShouldThrowInvalidValidationExceptionForUserIdAsync(messageTransformer, request, CancellationToken);
    }

    [Theory]
    [UserNameTooLongWithMessageData]
    public async Task SendAsync_ShouldThrowValidationException_WhenUserNameIsInvalid(
        IStringTransformer transformer, IStringMessageTransformer messageTransformer)
    {
        // Arrange
        var request = _requestBuilder.WithUserName(transformer).Build();

        // Assert
        await ApplicationSender.ShouldThrowInvalidValidationExceptionForUserNameAsync(
            messageTransformer, request, CancellationToken);
    }

    [Theory]
    [SortOrderEmptyWithMessageData]
    public async Task SendAsync_ShouldThrowValidationException_WhenSortOrderIsInvalid(
        IEnumTransformer<CommonSortOrder> transformer, IEnumMessageTransformer<CommonSortOrder> messageTransformer)
    {
        // Arrange
        var request = _requestBuilder.WithSortOrder(transformer).Build();

        // Assert
        await ApplicationSender.ShouldThrowInvalidValidationExceptionForSortOrderAsync(
            messageTransformer, request, CancellationToken);
    }

    [Theory]
    [PostCommentSortPropertyEmptyWithMessageData]
    public async Task SendAsync_ShouldThrowValidationException_WhenSortPropertyIsInvalid(
        IEnumTransformer<PostCommentSortProperty> transformer, IEnumMessageTransformer<PostCommentSortProperty> messageTransformer)
    {
        // Arrange
        var request = _requestBuilder.WithSortProperty(transformer).Build();

        // Assert
        await ApplicationSender.ShouldThrowInvalidValidationExceptionForSortPropertyAsync(
            messageTransformer, request, CancellationToken);
    }

    [Theory]
    [PostCommentPageTooSmallWithMessageData]
    [PostCommentPageTooLargeWithMessageData]
    public async Task SendAsync_ShouldThrowValidationException_WhenPageIsInvalid(
        IIntTransformer transformer, IIntMessageTransformer messageTransformer)
    {
        // Arrange
        var request = _requestBuilder.WithPage(transformer).Build();

        // Assert
        await ApplicationSender.ShouldThrowInvalidValidationExceptionForPageAsync(
            messageTransformer, request, CancellationToken);
    }

    [Theory]
    [PostCommentPageSizeTooSmallWithMessageData]
    [PostCommentPageSizeTooLargeWithMessageData]
    public async Task SendAsync_ShouldThrowValidationException_WhenPageSizeIsInvalid(
        IIntTransformer transformer, IIntMessageTransformer messageTransformer)
    {
        // Arrange
        var request = _requestBuilder.WithPageSize(transformer).Build();

        // Assert
        await ApplicationSender.ShouldThrowInvalidValidationExceptionForPageSizeAsync(
            messageTransformer, request, CancellationToken);
    }

    [Fact]
    public async Task SendAsync_ShouldThrowPostNotFoundException_WhenIdIsInvalid()
    {
        // Arrange
        await ServiceScope.DeletePostAsync(Post, CancellationToken);

        // Assert
        await ApplicationSender.ShouldThrowPostNotFoundExceptionAsync(_request, CancellationToken);
    }

    [Fact]
    public async Task SendAsync_ShouldReturnResponse_WhenRequestIsValid()
    {
        // Act
        var response = await ApplicationSender.SendAsync(_request, CancellationToken);

        // Assert
        response.ShouldSatisfy(PostComment, User, _request);
    }

    [Theory]
    [PostIdDifferentCaseData]
    public async Task SendAsync_ShouldReturnResponse_WhenRequestAndIdAreValid(
        IStringTransformer transformer)
    {
        // Arrange
        var request = _requestBuilder.WithId(transformer).Build();

        // Act
        var response = await ApplicationSender.SendAsync(request, CancellationToken);

        // Assert
        response.ShouldSatisfy(PostComment, User, _request);
    }

    [Theory]
    [UserIdNullData]
    [UserIdEmptyData]
    [UserIdDifferentCaseData]
    public async Task SendAsync_ShouldReturnResponse_WhenRequestAndUserIdAreValid(
        IStringTransformer transformer)
    {
        // Arrange
        var request = _requestBuilder.WithUserId(transformer).Build();

        // Act
        var response = await ApplicationSender.SendAsync(request, CancellationToken);

        // Assert
        response.ShouldSatisfy(PostComment, User, _request);
    }

    [Theory]
    [UserNameNullData]
    [UserNameEmptyData]
    [UserNameDifferentCaseData]
    public async Task SendAsync_ShouldReturnResponse_WhenRequestAndUserNameAreValid(
        IStringTransformer transformer)
    {
        // Arrange
        var request = _requestBuilder.WithUserName(transformer).Build();

        // Act
        var response = await ApplicationSender.SendAsync(request, CancellationToken);

        // Assert
        response.ShouldSatisfy(PostComment, User, _request);
    }
}
