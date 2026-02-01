using InstaConnect.Common.Domain.Models;
using InstaConnect.Common.Tests.DataAttributes.Enums.Sort;
using InstaConnect.Posts.Domain.Features.PostComments.Models.Requests;

namespace InstaConnect.Posts.Application.Tests.Integration.Features.PostComments.Queries;

public class GetAllPostCommentsQueryHandlerIntegrationTests : BasePostCommentApplicationQueryIntegrationTest
{
    private readonly GetAllPostCommentsQueryRequestBuilderFactory _requestBuilderFactory;
    private readonly GetAllPostCommentsQueryRequestBuilder _requestBuilder;
    private readonly GetAllPostCommentsQueryRequest _request;

    public GetAllPostCommentsQueryHandlerIntegrationTests(PostsWebApplicationFactory webApplicationFactory)
        : base(webApplicationFactory)
    {
        _requestBuilderFactory = new();
        _requestBuilder = _requestBuilderFactory.Create(PostComment);
        _request = _requestBuilder.Build();
    }

    protected override async Task OnInitializeAsync()
    {
        await ServiceScope.AddUserAsync(User, CancellationToken);
        await ServiceScope.AddUserRangeAsync(Users, CancellationToken);
        await ServiceScope.AddPostAsync(Post, CancellationToken);
        await ServiceScope.AddPostLikeAsync(PostLike, CancellationToken);
        await ServiceScope.AddPostCommentRangeAsync(PostComments, CancellationToken);
        await ServiceScope.AddPostCommentLikeRangeAsync(PostCommentLikes, CancellationToken);
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
        await Sender.ShouldThrowInvalidValidationExceptionForIdAsync(messageTransformer, request, CancellationToken);
    }

    [Theory]
    [UserNameTooLongWithMessageData]
    public async Task SendAsync_ShouldThrowValidationException_WhenUserNameIsInvalid(
        IStringTransformer transformer, IStringMessageTransformer messageTransformer)
    {
        // Arrange
        var request = _requestBuilder.WithUserName(transformer).Build();

        // Assert
        await Sender.ShouldThrowInvalidValidationExceptionForUserNameAsync(
            messageTransformer, request, CancellationToken);
    }

    [Theory]
    [PostCommentsSortOrderEmptyWithMessageData]
    public async Task SendAsync_ShouldThrowValidationException_WhenSortOrderIsInvalid(
        IEnumTransformer<CommonSortOrder> transformer, IEnumMessageTransformer<CommonSortOrder> messageTransformer)
    {
        // Arrange
        var request = _requestBuilder.WithSortOrder(transformer).Build();

        // Assert
        await Sender.ShouldThrowInvalidValidationExceptionForSortOrderAsync(
            messageTransformer, request, CancellationToken);
    }

    [Theory]
    [PostCommentsSortTermEmptyWithMessageData]
    public async Task SendAsync_ShouldThrowValidationException_WhenSortPropertyIsInvalid(
        IEnumTransformer<PostCommentsSortTerm> transformer, IEnumMessageTransformer<PostCommentsSortTerm> messageTransformer)
    {
        // Arrange
        var request = _requestBuilder.WithSortProperty(transformer).Build();

        // Assert
        await Sender.ShouldThrowInvalidValidationExceptionForSortPropertyAsync(
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
        await Sender.ShouldThrowInvalidValidationExceptionForPageAsync(
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
        await Sender.ShouldThrowInvalidValidationExceptionForPageSizeAsync(
            messageTransformer, request, CancellationToken);
    }

    [Fact]
    public async Task SendAsync_ShouldThrowPostNotFoundException_WhenIdIsInvalid()
    {
        // Arrange
        await ServiceScope.DeletePostAsync(Post, CancellationToken);

        // Assert
        await Sender.ShouldThrowPostNotFoundExceptionAsync(_request, CancellationToken);
    }

    [Fact]
    public async Task SendAsync_ShouldReturnResponse_WhenRequestIsValid()
    {
        // Act
        var response = await Sender.SendAsync(_request, CancellationToken);

        // Assert
        response.ShouldSatisfy(PostComments, _request);
    }

    [Theory]
    [PostIdDifferentCaseData]
    public async Task SendAsync_ShouldReturnResponse_WhenRequestAndIdAreValid(
        IStringTransformer transformer)
    {
        // Arrange
        var request = _requestBuilder.WithId(transformer).Build();

        // Act
        var response = await Sender.SendAsync(request, CancellationToken);

        // Assert
        response.ShouldSatisfy(PostComments, _request);
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
        var response = await Sender.SendAsync(request, CancellationToken);

        // Assert
        response.ShouldSatisfy(PostComments, _request);
    }

    [Theory]
    [PostCommentsSortOrderWithAscendingTermData]
    [PostCommentsSortOrderWithDescendingTermData]
    public async Task SendAsync_ShouldReturnResponse_WhenRequestAndSortOrderAreValid(
        IEnumTransformer<CommonSortOrder> transformer, ISortEnumTermTransformer<PostComment> termTransformer)
    {
        // Arrange
        var request = _requestBuilder.WithSortOrder(transformer).Build();

        // Act
        var response = await Sender.SendAsync(request, CancellationToken);

        // Assert
        response.ShouldSatisfy(PostComments, _request, termTransformer);
    }

    [Theory]
    [PostCommentsSortTermWithCreatedAtTermData]
    [PostCommentsSortTermWithUserNameTermData]
    public async Task SendAsync_ShouldReturnResponse_WhenRequestAndSortPropertyAreValid(
        IEnumTransformer<PostCommentsSortTerm> transformer, ISortEnumTermTransformer<PostComment> termTransformer)
    {
        // Arrange
        var request = _requestBuilder.WithSortProperty(transformer).Build();

        // Act
        var response = await Sender.SendAsync(request, CancellationToken);

        // Assert
        response.ShouldSatisfy(PostComments, _request, termTransformer);
    }
}
