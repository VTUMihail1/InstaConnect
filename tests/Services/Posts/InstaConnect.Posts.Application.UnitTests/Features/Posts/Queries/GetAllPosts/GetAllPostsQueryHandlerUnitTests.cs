using FluentAssertions;
using InstaConnect.Posts.Application.Features.Posts.Models;
using InstaConnect.Posts.Application.Features.Posts.Queries.GetAllPosts;
using InstaConnect.Posts.Application.UnitTests.Features.Posts.Utilities;
using InstaConnect.Posts.Common.Features.Posts.Utilities;
using InstaConnect.Posts.Domain.Features.Posts.Models.Filters;
using NSubstitute;

namespace InstaConnect.Posts.Application.UnitTests.Features.Posts.Queries.GetAllPosts;

public class GetAllPostsQueryHandlerUnitTests : BasePostUnitTest
{
    private readonly GetAllPostsQueryHandler _queryHandler;

    public GetAllPostsQueryHandlerUnitTests()
    {
        _queryHandler = new(
            InstaConnectMapper,
            PostReadRepository);
    }

    [Fact]
    public async Task Handle_ShouldCallRepositoryWithGetAllMethod_WhenQueryIsValid()
    {
        // Arrange
        var query = new GetAllPostsQuery(
            PostTestUtilities.ValidPostCurrentUserId,
            PostTestUtilities.ValidUserName,
            PostTestUtilities.ValidTitle,
            PostTestUtilities.ValidSortOrderProperty,
            PostTestUtilities.ValidSortPropertyName,
            PostTestUtilities.ValidPageValue,
            PostTestUtilities.ValidPageSizeValue);

        // Act
        await _queryHandler.Handle(query, CancellationToken);

        // Assert
        await PostReadRepository
            .Received(1)
            .GetAllAsync(Arg.Is<PostCollectionReadQuery>(m =>
                                                                        m.UserId == PostTestUtilities.ValidPostCurrentUserId &&
                                                                        m.UserName == PostTestUtilities.ValidUserName &&
                                                                        m.Title == PostTestUtilities.ValidTitle &&
                                                                        m.Page == PostTestUtilities.ValidPageValue &&
                                                                        m.Page == PostTestUtilities.ValidPageValue &&
                                                                        m.PageSize == PostTestUtilities.ValidPageSizeValue &&
                                                                        m.SortOrder == PostTestUtilities.ValidSortOrderProperty &&
                                                                        m.SortPropertyName == PostTestUtilities.ValidSortPropertyName), CancellationToken);
    }

    [Fact]
    public async Task Handle_ShouldReturnFollowViewModelCollection_WhenQueryIsValid()
    {
        // Arrange
        var query = new GetAllPostsQuery(
            PostTestUtilities.ValidPostCurrentUserId,
            PostTestUtilities.ValidUserName,
            PostTestUtilities.ValidTitle,
            PostTestUtilities.ValidSortOrderProperty,
            PostTestUtilities.ValidSortPropertyName,
            PostTestUtilities.ValidPageValue,
            PostTestUtilities.ValidPageSizeValue);

        // Act
        var response = await _queryHandler.Handle(query, CancellationToken);

        // Assert
        response
            .Should()
            .Match<PostPaginationQueryViewModel>(mc => mc.Items.All(m => m.Id == PostTestUtilities.ValidId &&
                                                           m.UserId == PostTestUtilities.ValidPostCurrentUserId &&
                                                           m.UserName == PostTestUtilities.ValidUserName &&
                                                           m.UserProfileImage == PostTestUtilities.ValidUserProfileImage &&
                                                           m.Title == PostTestUtilities.ValidTitle &&
                                                           m.Content == PostTestUtilities.ValidContent) &&
                                                           mc.Page == PostTestUtilities.ValidPageValue &&
                                                           mc.PageSize == PostTestUtilities.ValidPageSizeValue &&
                                                           mc.TotalCount == PostTestUtilities.ValidTotalCountValue &&
                                                           !mc.HasPreviousPage &&
                                                           !mc.HasNextPage);
        ;
    }
}
