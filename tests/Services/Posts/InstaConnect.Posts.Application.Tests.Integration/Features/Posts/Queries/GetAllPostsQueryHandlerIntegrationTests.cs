using InstaConnect.Common.Domain.Models;
using InstaConnect.Common.Tests.DataAttributes.Enums.Sort;
using InstaConnect.Posts.Domain.Features.Posts.Models.Requests;

namespace InstaConnect.Posts.Application.Tests.Integration.Features.Posts.Queries;

public class GetAllPostsQueryHandlerIntegrationTests : BasePostApplicationQueryIntegrationTest
{
    private readonly GetAllPostsQueryRequestBuilderFactory _requestBuilderFactory;
    private readonly GetAllPostsQueryRequestBuilder _requestBuilder;
    private readonly GetAllPostsQueryRequest _request;

    public GetAllPostsQueryHandlerIntegrationTests(PostsWebApplicationFactory webApplicationFactory)
        : base(webApplicationFactory)
    {
        _requestBuilderFactory = new();
        _requestBuilder = _requestBuilderFactory.Create(Post);
        _request = _requestBuilder.Build();
    }

    protected override async Task OnInitializeAsync()
    {
        await ServiceScope.AddUserAsync(User, CancellationToken);
        await ServiceScope.AddUserRangeAsync(Users, CancellationToken);
        await ServiceScope.AddPostRangeAsync(Posts, CancellationToken);
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
    [PostTitleTooLongWithMessageData]
    public async Task SendAsync_ShouldThrowValidationException_WhenTitleIsInvalid(
        IStringTransformer transformer, IStringMessageTransformer messageTransformer)
    {
        // Arrange
        var request = _requestBuilder.WithTitle(transformer).Build();

        // Assert
        await ApplicationSender.ShouldThrowInvalidValidationExceptionForTitleAsync(
            messageTransformer, request, CancellationToken);
    }

    [Theory]
    [PostSortOrderEmptyWithMessageData]
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
    [PostSortPropertyEmptyWithMessageData]
    public async Task SendAsync_ShouldThrowValidationException_WhenSortPropertyIsInvalid(
        IEnumTransformer<PostSortProperty> transformer, IEnumMessageTransformer<PostSortProperty> messageTransformer)
    {
        // Arrange
        var request = _requestBuilder.WithSortProperty(transformer).Build();

        // Assert
        await ApplicationSender.ShouldThrowInvalidValidationExceptionForSortPropertyAsync(
            messageTransformer, request, CancellationToken);
    }

    [Theory]
    [PostPageTooSmallWithMessageData]
    [PostPageTooLargeWithMessageData]
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
    [PostPageSizeTooSmallWithMessageData]
    [PostPageSizeTooLargeWithMessageData]
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
    public async Task SendAsync_ShouldReturnResponse_WhenRequestIsValid()
    {
        // Act
        var response = await ApplicationSender.SendAsync(_request, CancellationToken);

        // Assert
        response.ShouldSatisfy(Posts, _request);
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
        response.ShouldSatisfy(Posts, _request);
    }

    [Theory]
    [PostTitleNullData]
    [PostTitleEmptyData]
    [PostTitleDifferentCaseData]
    public async Task SendAsync_ShouldReturnResponse_WhenRequestAndTitleAreValid(
        IStringTransformer transformer)
    {
        // Arrange
        var request = _requestBuilder.WithTitle(transformer).Build();

        // Act
        var response = await ApplicationSender.SendAsync(request, CancellationToken);

        // Assert
        response.ShouldSatisfy(Posts, _request);
    }

    [Theory]
    [PostSortOrderWithAscendingTermData]
    [PostSortOrderWithDescendingTermData]
    public async Task SendAsync_ShouldReturnResponse_WhenRequestAndSortOrderAreValid(
        IEnumTransformer<CommonSortOrder> transformer, ISortEnumTermTransformer<Post> termTransformer)
    {
        // Arrange
        var request = _requestBuilder.WithSortOrder(transformer).Build();

        // Act
        var response = await ApplicationSender.SendAsync(request, CancellationToken);

        // Assert
        response.ShouldSatisfy(Posts, _request, termTransformer);
    }

    [Theory]
    [PostSortPropertyWithCreatedAtTermData]
    [PostSortPropertyWithTitleTermData]
    [PostSortPropertyWithUserNameTermData]
    public async Task SendAsync_ShouldReturnResponse_WhenRequestAndSortPropertyAreValid(
        IEnumTransformer<PostSortProperty> transformer, ISortEnumTermTransformer<Post> termTransformer)
    {
        // Arrange
        var request = _requestBuilder.WithSortProperty(transformer).Build();

        // Act
        var response = await ApplicationSender.SendAsync(request, CancellationToken);

        // Assert
        response.ShouldSatisfy(Posts, _request, termTransformer);
    }
}
