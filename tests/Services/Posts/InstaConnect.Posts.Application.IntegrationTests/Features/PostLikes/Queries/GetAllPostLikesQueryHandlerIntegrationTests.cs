using InstaConnect.Common.Models.Enums;
using InstaConnect.Common.Tests.Utilities.Assertions;
using InstaConnect.Common.Tests.Utilities.DataAttributes.Enums;
using InstaConnect.Common.Tests.Utilities.DataAttributes.Enums.Base;
using InstaConnect.Common.Tests.Utilities.DataAttributes.Ints.Base;
using InstaConnect.Common.Tests.Utilities.DataAttributes.Strings.Base;
using InstaConnect.PostLikes.Application.Features.PostLikes.Queries.GetAll;
using InstaConnect.PostLikes.Application.IntegrationTests.Features.PostLikes.Utilities;
using InstaConnect.PostLikes.Common.Tests.Features.PostLikes.Utilities;
using InstaConnect.PostLikes.Common.Tests.Features.PostLikes.Utilities.Assertions;
using InstaConnect.PostLikes.Common.Tests.Features.PostLikes.Utilities.Builders.AddApiRequest;
using InstaConnect.PostLikes.Common.Tests.Features.PostLikes.Utilities.Builders.GetAllQueryRequest;
using InstaConnect.PostLikes.Common.Tests.Features.PostLikes.Utilities.DataAttributes.Id;
using InstaConnect.PostLikes.Common.Tests.Features.PostLikes.Utilities.DataAttributes.Page;
using InstaConnect.PostLikes.Common.Tests.Features.PostLikes.Utilities.DataAttributes.PageSize;
using InstaConnect.PostLikes.Common.Tests.Features.PostLikes.Utilities.DataAttributes.SortProperty;
using InstaConnect.PostLikes.Domain.Features.PostLikes.Models.Requests;
using InstaConnect.Posts.Common.Tests.Features.Posts.Utilities.Assertions;
using InstaConnect.Posts.Common.Tests.Features.Posts.Utilities.DataAttributes.Id;
using InstaConnect.Posts.Common.Tests.Features.Users.Utilities.DataAttributes.Id;
using InstaConnect.Posts.Common.Tests.Features.Users.Utilities.DataAttributes.Name;
using InstaConnect.Posts.Common.Tests.Features.Utilities;

namespace InstaConnect.PostLikes.Application.IntegrationTests.Features.PostLikes.Queries;

public class GetAllPostLikesQueryHandlerIntegrationTests : BasePostLikeApplicationIntegrationTest
{
    private readonly GetAllPostLikesQueryRequestBuilderFactory _requestBuilderFactory;
    private readonly GetAllPostLikesQueryRequestBuilder _requestBuilder;
    private readonly GetAllPostLikesQueryRequest _request;

    public GetAllPostLikesQueryHandlerIntegrationTests(PostsWebApplicationFactory webApplicationFactory)
        : base(webApplicationFactory)
    {
        _requestBuilderFactory = new();
        _requestBuilder = _requestBuilderFactory.Create(PostLike, User);
        _request = _requestBuilder.Create();
    }

    protected override async Task OnInitializeAsync()
    {
        await ServiceScope.AddUserAsync(User, CancellationToken);
        await ServiceScope.AddPostAsync(Post, CancellationToken);
        await ServiceScope.AddPostLikeAsync(PostLike, CancellationToken);
    }

    [Theory]
    [PostIdNullWithMessageData]
    [PostIdEmptyWithMessageData]
    [PostIdTooShortWithMessageData]
    [PostIdTooLongWithMessageData]
    public async Task SendAsync_ShouldThrowValidationException_WhenIdIsInvalid(
        IStringTransformer transformer, string errorMessage)
    {
        // Arrange
        var request = _requestBuilder.WithId(_request.Filter.Id, transformer).Create();

        // Act
        var action = async () => await ApplicationSender.SendAsync(request, CancellationToken);

        // Assert
        await action.ShouldThrowInvalidValidationExceptionAsync(errorMessage);
    }

    [Theory]
    [UserIdTooLongWithMessageData]
    public async Task SendAsync_ShouldThrowValidationException_WhenUserIdIsInvalid(
        IStringTransformer transformer, string errorMessage)
    {
        // Arrange
        var request = _requestBuilder.WithUserId(_request.Filter.UserId, transformer).Create();

        // Act
        var action = async () => await ApplicationSender.SendAsync(request, CancellationToken);

        // Assert
        await action.ShouldThrowInvalidValidationExceptionAsync(errorMessage);
    }

    [Theory]
    [UserNameTooLongWithMessageData]
    public async Task SendAsync_ShouldThrowValidationException_WhenUserNameIsInvalid(
        IStringTransformer transformer, string errorMessage)
    {
        // Arrange
        var request = _requestBuilder.WithUserName(_request.Filter.UserName, transformer).Create();

        // Act
        var action = async () => await ApplicationSender.SendAsync(request, CancellationToken);

        // Assert
        await action.ShouldThrowInvalidValidationExceptionAsync(errorMessage);
    }

    [Theory]
    [SortOrderEmptyWithMessageData]
    public async Task SendAsync_ShouldThrowValidationException_WhenSortOrderIsInvalid(
        IEnumTransformer<SortOrder> transformer, string errorMessage)
    {
        // Arrange
        var request = _requestBuilder.WithSortOrder(_request.Sorting.Order, transformer).Create();

        // Act
        var action = async () => await ApplicationSender.SendAsync(request, CancellationToken);

        // Assert
        await action.ShouldThrowInvalidValidationExceptionAsync(errorMessage);
    }

    [Theory]
    [PostLikeSortPropertyEmptyWithMessageData]
    public async Task SendAsync_ShouldThrowValidationException_WhenSortPropertyIsInvalid(
        IEnumTransformer<PostLikeSortProperty> transformer, string errorMessage)
    {
        // Arrange
        var request = _requestBuilder.WithSortProperty(_request.Sorting.Property, transformer).Create();

        // Act
        var action = async () => await ApplicationSender.SendAsync(request, CancellationToken);

        // Assert
        await action.ShouldThrowInvalidValidationExceptionAsync(errorMessage);
    }

    [Theory]
    [PostLikePageEmptyWithMessageData]
    [PostLikePageTooSmallWithMessageData]
    [PostLikePageTooLargeWithMessageData]
    public async Task SendAsync_ShouldThrowValidationException_WhenPageIsInvalid(
        IIntTransformer transformer, string errorMessage)
    {
        // Arrange
        var request = _requestBuilder.WithPage(_request.Pagination.Page, transformer).Create();

        // Act
        var action = async () => await ApplicationSender.SendAsync(request, CancellationToken);

        // Assert
        await action.ShouldThrowInvalidValidationExceptionAsync(errorMessage);
    }

    [Theory]
    [PostLikePageSizeEmptyWithMessageData]
    [PostLikePageSizeTooSmallWithMessageData]
    [PostLikePageSizeTooLargeWithMessageData]
    public async Task SendAsync_ShouldThrowValidationException_WhenPageSizeIsInvalid(
        IIntTransformer transformer, string errorMessage)
    {
        // Arrange
        var request = _requestBuilder.WithPageSize(_request.Pagination.PageSize, transformer).Create();

        // Act
        var action = async () => await ApplicationSender.SendAsync(request, CancellationToken);

        // Assert
        await action.ShouldThrowInvalidValidationExceptionAsync(errorMessage);
    }

    [Theory]
    [PostIdNotFoundData]
    public async Task SendAsync_ShouldThrowPostNotFoundException_WhenIdIsInvalid(
        IStringTransformer transformer)
    {
        // Arrange
        var request = _requestBuilder.WithId(_request.Filter.Id, transformer).Create();

        // Act
        var action = async () => await ApplicationSender.SendAsync(request, CancellationToken);

        // Assert
        await action.ShouldThrowPostNotFoundExceptionAsync(request.Filter.Id);
    }

    [Fact]
    public async Task SendAsync_ShouldReturnResponse_WhenRequestIsValid()
    {
        // Act
        var response = await ApplicationSender.SendAsync(_request, CancellationToken);

        // Assert
        response.ShouldSatisfy(PostLike, User, _request);
    }

    [Theory]
    [PostIdDifferentCaseData]
    public async Task SendAsync_ShouldReturnResponse_WhenRequestAndIdAreValid(
        IStringTransformer transformer)
    {
        // Arrange
        var request = _requestBuilder.WithId(_request.Filter.Id, transformer).Create();

        // Act
        var response = await ApplicationSender.SendAsync(request, CancellationToken);

        // Assert
        response.ShouldSatisfy(PostLike, User, _request);
    }

    [Theory]
    [UserIdNullData]
    [UserIdEmptyData]
    [UserIdDifferentCaseData]
    public async Task SendAsync_ShouldReturnResponse_WhenRequestAndUserIdAreValid(
        IStringTransformer transformer)
    {
        // Arrange
        var request = _requestBuilder.WithUserId(_request.Filter.UserId, transformer).Create();

        // Act
        var response = await ApplicationSender.SendAsync(request, CancellationToken);

        // Assert
        response.ShouldSatisfy(PostLike, User, _request);
    }

    [Theory]
    [UserNameNullData]
    [UserNameEmptyData]
    [UserNameDifferentCaseData]
    public async Task SendAsync_ShouldReturnResponse_WhenRequestAndUserNameAreValid(
        IStringTransformer transformer)
    {
        // Arrange
        var request = _requestBuilder.WithUserName(_request.Filter.UserName, transformer).Create();

        // Act
        var response = await ApplicationSender.SendAsync(request, CancellationToken);

        // Assert
        response.ShouldSatisfy(PostLike, User, _request);
    }
}
