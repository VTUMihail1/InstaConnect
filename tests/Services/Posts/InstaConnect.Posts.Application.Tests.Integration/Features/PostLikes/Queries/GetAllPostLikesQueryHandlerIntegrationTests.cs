using InstaConnect.Common.Domain.Models;
using InstaConnect.Common.Tests.DataAttributes.Enums.Sort;
using InstaConnect.Posts.Domain.Features.PostLikes.Models.Requests;

namespace InstaConnect.Posts.Application.Tests.Integration.Features.PostLikes.Queries;

public class GetAllPostLikesQueryHandlerIntegrationTests : BasePostLikeApplicationQueryIntegrationTest
{
    private readonly GetAllPostLikesQueryRequestBuilderFactory _requestBuilderFactory;
    private readonly GetAllPostLikesQueryRequestBuilder _requestBuilder;
    private readonly GetAllPostLikesQueryRequest _request;

    public GetAllPostLikesQueryHandlerIntegrationTests(PostsWebApplicationFactory webApplicationFactory)
        : base(webApplicationFactory)
    {
        _requestBuilderFactory = new();
        _requestBuilder = _requestBuilderFactory.Create(PostLike);
        _request = _requestBuilder.Build();
    }

    protected override async Task OnInitializeAsync()
    {
        await ServiceScope.AddUserAsync(User, CancellationToken);
        await ServiceScope.AddUserRangeAsync(Users, CancellationToken);
        await ServiceScope.AddPostAsync(Post, CancellationToken);
        await ServiceScope.AddPostLikeRangeAsync(PostLikes, CancellationToken);
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

        // Assert
        await ApplicationSender.ShouldThrowInvalidValidationExceptionForIdAsync(
            messageTransformer, request, CancellationToken);
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
    [PostLikeSortOrderEmptyWithMessageData]
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
    [PostLikeSortPropertyEmptyWithMessageData]
    public async Task SendAsync_ShouldThrowValidationException_WhenSortPropertyIsInvalid(
        IEnumTransformer<PostLikeSortProperty> transformer, IEnumMessageTransformer<PostLikeSortProperty> messageTransformer)
    {
        // Arrange
        var request = _requestBuilder.WithSortProperty(transformer).Build();

        // Assert
        await ApplicationSender.ShouldThrowInvalidValidationExceptionForSortPropertyAsync(
            messageTransformer, request, CancellationToken);
    }

    [Theory]
    [PostLikePageTooSmallWithMessageData]
    [PostLikePageTooLargeWithMessageData]
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
    [PostLikePageSizeTooSmallWithMessageData]
    [PostLikePageSizeTooLargeWithMessageData]
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
        response.ShouldSatisfy(PostLikes, _request);
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
        response.ShouldSatisfy(PostLikes, _request);
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
        response.ShouldSatisfy(PostLikes, _request);
    }

    [Theory]
    [PostLikeSortOrderWithAscendingTermData]
    [PostLikeSortOrderWithDescendingTermData]
    public async Task SendAsync_ShouldReturnResponse_WhenRequestAndSortOrderAreValid(
        IEnumTransformer<CommonSortOrder> transformer, ISortEnumTermTransformer<PostLike> termTransformer)
    {
        // Arrange
        var request = _requestBuilder.WithSortOrder(transformer).Build();

        // Act
        var response = await ApplicationSender.SendAsync(request, CancellationToken);

        // Assert
        response.ShouldSatisfy(PostLikes, _request, termTransformer);
    }

    [Theory]
    [PostLikeSortPropertyWithCreatedAtTermData]
    [PostLikeSortPropertyWithUserNameTermData]
    public async Task SendAsync_ShouldReturnResponse_WhenRequestAndSortPropertyAreValid(
        IEnumTransformer<PostLikeSortProperty> transformer, ISortEnumTermTransformer<PostLike> termTransformer)
    {
        // Arrange
        var request = _requestBuilder.WithSortProperty(transformer).Build();

        // Act
        var response = await ApplicationSender.SendAsync(request, CancellationToken);

        // Assert
        response.ShouldSatisfy(PostLikes, _request, termTransformer);
    }
}
