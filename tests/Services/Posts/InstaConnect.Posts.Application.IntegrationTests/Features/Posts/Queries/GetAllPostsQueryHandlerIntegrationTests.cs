using InstaConnect.Posts.Application.Features.Posts.Queries.GetAll;
using InstaConnect.Posts.Common.Tests.Features.Posts.Utilities.Assertions;
using InstaConnect.Posts.Common.Tests.Features.Posts.Utilities.Builders;
using InstaConnect.Posts.Common.Tests.Features.Posts.Utilities.DataAttributes;
using InstaConnect.Posts.Common.Tests.Features.Users.Utilities.DataAttributes;
using InstaConnect.Posts.Domain.Features.Users.Models.Entities;

namespace InstaConnect.Posts.Application.IntegrationTests.Features.Posts.Queries;

public class GetAllPostsQueryHandlerIntegrationTests : BasePostIntegrationTest
{
    private User _user;
    private Post _post;
    private GetAllPostsQueryBuilder _queryBuilder;

    public GetAllPostsQueryHandlerIntegrationTests(PostsWebApplicationFactory postsWebApplicationFactory) : base(postsWebApplicationFactory)
    {

    }

    protected override async Task OnInitializeAsync()
    {
        _user = await SetupUserAsync(CancellationToken);
        _post = await SetupPostAsync(_user, CancellationToken);
        _queryBuilder = new(_post, _user);
    }

    [Theory]
    [UserIdOutOfBoundsMaxData]
    public async Task SendAsync_ShouldThrowValidationException_WhenUserIdLengthIsInvalid(string userId)
    {
        // Arrange
        var query = _queryBuilder.WithUserId(userId).Create();

        // Act
        var action = async () => await ApplicationSender.SendAsync(query, CancellationToken);

        // Assert
        await action.ShouldThrowInvalidValidationExceptionAsync();
    }

    [Theory]
    [UserNameOutOfBoundsMaxData]
    public async Task SendAsync_ShouldThrowValidationException_WhenUserNameLengthIsInvalid(string userName)
    {
        // Arrange
        var query = _queryBuilder.WithUserName(userName).Create();

        // Act
        var action = async () => await ApplicationSender.SendAsync(query, CancellationToken);

        // Assert
        await action.ShouldThrowInvalidValidationExceptionAsync();
    }

    [Theory]
    [PostTitleOutOfBoundsMaxData]
    public async Task SendAsync_ShouldThrowValidationException_WhenTitleLengthIsInvalid(string title)
    {
        // Arrange
        var query = _queryBuilder.WithTitle(title).Create();

        // Act
        var action = async () => await ApplicationSender.SendAsync(query, CancellationToken);

        // Assert
        await action.ShouldThrowInvalidValidationExceptionAsync();
    }

    [Fact]
    public async Task SendAsync_ShouldThrowValidationException_WhenSortOrderIsEmpty()
    {
        // Arrange
        var query = _queryBuilder.WithEmptySortOrder().Create();

        // Act
        var action = async () => await ApplicationSender.SendAsync(query, CancellationToken);

        // Assert
        await action.ShouldThrowInvalidValidationExceptionAsync();
    }

    [Fact]
    public async Task SendAsync_ShouldThrowValidationException_WhenSortPropertyIsEmpty()
    {
        // Arrange
        var query = _queryBuilder.WithEmptySortProperty().Create();

        // Act
        var action = async () => await ApplicationSender.SendAsync(query, CancellationToken);

        // Assert
        await action.ShouldThrowInvalidValidationExceptionAsync();
    }

    [Theory]
    [PostPageOutOfBoundsMinData]
    [PostPageOutOfBoundsMaxData]
    public async Task SendAsync_ShouldThrowValidationException_WhenPageValueIsInvalid(int page)
    {
        // Arrange
        var query = _queryBuilder.WithPage(page).Create();

        // Act
        var action = async () => await ApplicationSender.SendAsync(query, CancellationToken);

        // Assert
        await action.ShouldThrowInvalidValidationExceptionAsync();
    }

    [Theory]
    [PostPageSizeOutOfBoundsMinData]
    [PostPageSizeOutOfBoundsMaxData]
    public async Task SendAsync_ShouldThrowValidationException_WhenPageSizeValueIsInvalid(int pageSize)
    {
        // Arrange
        var query = _queryBuilder.WithPageSize(pageSize).Create();

        // Act
        var action = async () => await ApplicationSender.SendAsync(query, CancellationToken);

        // Assert
        await action.ShouldThrowInvalidValidationExceptionAsync();
    }
    [Fact]
    public async Task SendAsync_ShouldReturnResponse_WhenQueryIdIsNull()
    {
        // Arrange
        var query = _queryBuilder.Create();

        // Act
        var response = await ApplicationSender.SendAsync(query, CancellationToken);

        // Assert
        response.ShouldSatisfy(_post, _user, query);
    }

    [Fact]
    public async Task SendAsync_ShouldReturnResponse_WhenUserIdIsNull()
    {
        // Arrange
        var query = _queryBuilder.WithoutUserId().Create();

        // Act
        var response = await ApplicationSender.SendAsync(query, CancellationToken);

        // Assert
        response.ShouldSatisfy(_post, _user, query);
    }

    [Fact]
    public async Task SendAsync_ShouldReturnResponse_WhenUserIdIsDifferentCase()
    {
        // Arrange
        var query = _queryBuilder.WithDifferentCaseUserId(_user.Id).Create();

        // Act
        var response = await ApplicationSender.SendAsync(query, CancellationToken);

        // Assert
        response.ShouldSatisfy(_post, _user, query);
    }

    [Fact]
    public async Task SendAsync_ShouldReturnResponse_WhenUserNameIsNull()
    {
        // Arrange
        var query = _queryBuilder.WithoutUserName().Create();

        // Act
        var response = await ApplicationSender.SendAsync(query, CancellationToken);

        // Assert
        response.ShouldSatisfy(_post, _user, query);
    }

    [Fact]
    public async Task SendAsync_ShouldReturnResponse_WhenUserNameIsDifferentCase()
    {
        // Arrange
        var query = _queryBuilder.WithDifferentCaseUserName(_user.UserName).Create();

        // Act
        var response = await ApplicationSender.SendAsync(query, CancellationToken);

        // Assert
        response.ShouldSatisfy(_post, _user, query);
    }

    [Fact]
    public async Task SendAsync_ShouldReturnResponse_WhenTitleIsNull()
    {
        // Arrange
        var query = _queryBuilder.WithoutTitle().Create();

        // Act
        var response = await ApplicationSender.SendAsync(query, CancellationToken);

        // Assert
        response.ShouldSatisfy(_post, _user, query);
    }

    [Fact]
    public async Task SendAsync_ShouldReturnResponse_WhenTitleIsDifferentCase()
    {
        // Arrange
        var query = _queryBuilder.WithDifferentCaseTitle(_post.Title).Create();

        // Act
        var response = await ApplicationSender.SendAsync(query, CancellationToken);

        // Assert
        response.ShouldSatisfy(_post, _user, query);
    }

    [Fact]
    public async Task SendAsync_ShouldReturnResponse_WhenTitleIsPartial()
    {
        // Arrange
        var query = _queryBuilder.WithPrefixTitle(_post.Title).Create();

        // Act
        var response = await ApplicationSender.SendAsync(query, CancellationToken);

        // Assert
        response.ShouldSatisfy(_post, _user, query);
    }
}
