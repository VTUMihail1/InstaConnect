using System.Data.Common;

using InstaConnect.Common.Models.Enums;
using InstaConnect.Common.Tests.Utilities.DataAttributes.Enums;
using InstaConnect.Common.Tests.Utilities.DataAttributes.String;
using InstaConnect.Common.Tests.Utilities.Variants.String;
using InstaConnect.Posts.Application.Features.Posts.Queries.GetAll;
using InstaConnect.Posts.Common.Tests.Features.Posts.Utilities.Assertions;
using InstaConnect.Posts.Common.Tests.Features.Posts.Utilities.Builders;
using InstaConnect.Posts.Common.Tests.Features.Posts.Utilities.DataAttributes;
using InstaConnect.Posts.Common.Tests.Features.Posts.Utilities.DataAttributes.Page;
using InstaConnect.Posts.Common.Tests.Features.Posts.Utilities.DataAttributes.PageSize;
using InstaConnect.Posts.Common.Tests.Features.Posts.Utilities.DataAttributes.SortProperty;
using InstaConnect.Posts.Common.Tests.Features.Posts.Utilities.DataAttributes.Title;
using InstaConnect.Posts.Common.Tests.Features.Users.Utilities.DataAttributes;
using InstaConnect.Posts.Common.Tests.Features.Users.Utilities.DataAttributes.Id;
using InstaConnect.Posts.Common.Tests.Features.Users.Utilities.DataAttributes.Name;
using InstaConnect.Posts.Domain.Features.Posts.Models.Requests;
using InstaConnect.Posts.Domain.Features.Users.Models.Entities;

namespace InstaConnect.Posts.Application.IntegrationTests.Features.Posts.Queries;

public class GetAllPostsQueryHandlerIntegrationTests : BasePostIntegrationTest
{
    private User _user;
    private Post _post;
    private GetAllPostsQueryBuilder _queryBuilder;

    public GetAllPostsQueryHandlerIntegrationTests(PostWebApplicationFactory postsWebApplicationFactory) : base(postsWebApplicationFactory)
    {

    }

    protected override async Task OnInitializeAsync()
    {
        _user = await ServiceScope.AddUserAsync(CancellationToken);
        _post = await ServiceScope.AddPostAsync(_user, CancellationToken);
        _queryBuilder = new(_post, _user);
    }

    [Theory]
    [UserIdTooLongData]
    public async Task SendAsync_ShouldThrowValidationException_WhenUserIdIsInvalid(string userId, string errorMessage)
    {
        // Arrange
        var request = _queryBuilder.WithUserId(userId).Create();

        // Act
        var action = async () => await ApplicationSender.SendAsync(request, CancellationToken);

        // Assert
        await action.ShouldThrowInvalidValidationExceptionAsync(errorMessage);
    }

    [Theory]
    [UserNameTooLongData]
    public async Task SendAsync_ShouldThrowValidationException_WhenUserNameIsInvalid(string userName, string errorMessage)
    {
        // Arrange
        var request = _queryBuilder.WithUserName(userName).Create();

        // Act
        var action = async () => await ApplicationSender.SendAsync(request, CancellationToken);

        // Assert
        await action.ShouldThrowInvalidValidationExceptionAsync(errorMessage);
    }

    [Theory]
    [PostTitleTooLongData]
    public async Task SendAsync_ShouldThrowValidationException_WhenTitleIsInvalid(string title, string errorMessage)
    {
        // Arrange
        var request = _queryBuilder.WithTitle(title).Create();

        // Act
        var action = async () => await ApplicationSender.SendAsync(request, CancellationToken);

        // Assert
        await action.ShouldThrowInvalidValidationExceptionAsync(errorMessage);
    }

    [Theory]
    [SortOrderEmptyWithMessageData]
    public async Task SendAsync_ShouldThrowValidationException_WhenSortOrderIsInvalid(SortOrder sortOrder, string errorMessage)
    {
        // Arrange
        var request = _queryBuilder.WithSortOrder(sortOrder).Create();

        // Act
        var action = async () => await ApplicationSender.SendAsync(request, CancellationToken);

        // Assert
        await action.ShouldThrowInvalidValidationExceptionAsync(errorMessage);
    }

    [Theory]
    [PostSortPropertyEmptyData]
    public async Task SendAsync_ShouldThrowValidationException_WhenSortPropertyIsInvalid(PostSortProperty sortProperty, string errorMessage)
    {
        // Arrange
        var request = _queryBuilder.WithSortProperty(sortProperty).Create();

        // Act
        var action = async () => await ApplicationSender.SendAsync(request, CancellationToken);

        // Assert
        await action.ShouldThrowInvalidValidationExceptionAsync(errorMessage);
    }

    [Theory]
    [PostPageNullData]
    [PostPageEmptyData]
    [PostPageTooSmallData]
    [PostPageTooLargeData]
    public async Task SendAsync_ShouldThrowValidationException_WhenPageIsInvalid(int page, string errorMessage)
    {
        // Arrange
        var request = _queryBuilder.WithPage(page).Create();

        // Act
        var action = async () => await ApplicationSender.SendAsync(request, CancellationToken);

        // Assert
        await action.ShouldThrowInvalidValidationExceptionAsync(errorMessage);
    }

    [Theory]
    [PostPageSizeNullData]
    [PostPageSizeEmptyData]
    [PostPageSizeTooSmallData]
    [PostPageSizeTooLargeData]
    public async Task SendAsync_ShouldThrowValidationException_WhenPageSizeIsInvalid(int pageSize, string errorMessage)
    {
        // Arrange
        var request = _queryBuilder.WithPageSize(pageSize).Create();

        // Act
        var action = async () => await ApplicationSender.SendAsync(request, CancellationToken);

        // Assert
        await action.ShouldThrowInvalidValidationExceptionAsync(errorMessage);
    }

    [Fact]
    public async Task SendAsync_ShouldReturnResponse_WhenRequestIsValid()
    {
        // Arrange
        var request = _queryBuilder.Create();

        // Act
        var response = await ApplicationSender.SendAsync(request, CancellationToken);

        // Assert
        response.ShouldSatisfy(_post, _user, request);
    }

    [Theory]
    [NullStringVariantTypeData]
    [EmptyStringVariantTypeData]
    [DifferentCaseStringVariantTypeData]
    public async Task SendAsync_ShouldReturnResponse_WhenRequestIsValidAndUserIdHasDifferentVariants(StringVariantType type)
    {
        // Arrange
        var request = _queryBuilder.WithUserId(_user.Id, type).Create();

        // Act
        var response = await ApplicationSender.SendAsync(request, CancellationToken);

        // Assert
        response.ShouldSatisfy(_post, _user, request);
    }

    [Theory]
    [NullStringVariantTypeData]
    [EmptyStringVariantTypeData]
    [DifferentCaseStringVariantTypeData]
    public async Task SendAsync_ShouldReturnResponse_WhenRequestIsValidAndUserNameHasDifferentVariants(StringVariantType type)
    {
        // Arrange
        var request = _queryBuilder.WithUserName(_user.UserName, type).Create();

        // Act
        var response = await ApplicationSender.SendAsync(request, CancellationToken);

        // Assert
        response.ShouldSatisfy(_post, _user, request);
    }

    [Theory]
    [NullStringVariantTypeData]
    [EmptyStringVariantTypeData]
    [PrefixStringVariantTypeData]
    [DifferentCaseStringVariantTypeData]
    public async Task SendAsync_ShouldReturnResponse_WhenRequestIsValidAndTitleHasDifferentVariants(StringVariantType type)
    {
        // Arrange
        var request = _queryBuilder.WithTitle(_post.Title, type).Create();

        // Act
        var response = await ApplicationSender.SendAsync(request, CancellationToken);

        // Assert
        response.ShouldSatisfy(_post, _user, request);
    }
}
