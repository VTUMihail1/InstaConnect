using FluentAssertions;
using InstaConnect.Posts.Business.Features.PostLikes.Models;
using InstaConnect.Posts.Business.Features.PostLikes.Queries.GetAllPostLikes;
using InstaConnect.Posts.Business.UnitTests.Features.PostLikes.Utilities;
using InstaConnect.Posts.Common.Features.PostLikes.Utilities;
using InstaConnect.Posts.Data.Features.PostLikes.Models.Filters;
using NSubstitute;

namespace InstaConnect.Posts.Business.UnitTests.Features.PostLikes.Queries.GetAllPostLikes;

public class GetAllPostLikesQueryHandlerUnitTests : BasePostLikeUnitTest
{
    private readonly GetAllPostLikesQueryHandler _queryHandler;

    public GetAllPostLikesQueryHandlerUnitTests()
    {
        _queryHandler = new(
            InstaConnectMapper,
            PostLikeReadRepository);
    }

    [Fact]
    public async Task Handle_ShouldCallRepositoryWithGetAllMethod_WhenQueryIsValid()
    {
        // Arrange
        var query = new GetAllPostLikesQuery(
            PostLikeTestUtilities.ValidPostLikeCurrentUserId,
            PostLikeTestUtilities.ValidUserName,
            PostLikeTestUtilities.ValidPostLikePostId,
            PostLikeTestUtilities.ValidSortOrderProperty,
            PostLikeTestUtilities.ValidSortPropertyName,
            PostLikeTestUtilities.ValidPageValue,
            PostLikeTestUtilities.ValidPageSizeValue);

        // Act
        await _queryHandler.Handle(query, CancellationToken);

        // Assert
        await PostLikeReadRepository
            .Received(1)
            .GetAllAsync(Arg.Is<PostLikeCollectionReadQuery>(m =>
                                                                        m.UserId == PostLikeTestUtilities.ValidPostLikeCurrentUserId &&
                                                                        m.UserName == PostLikeTestUtilities.ValidUserName &&
                                                                        m.PostId == PostLikeTestUtilities.ValidPostLikePostId &&
                                                                        m.Page == PostLikeTestUtilities.ValidPageValue &&
                                                                        m.Page == PostLikeTestUtilities.ValidPageValue &&
                                                                        m.PageSize == PostLikeTestUtilities.ValidPageSizeValue &&
                                                                        m.SortOrder == PostLikeTestUtilities.ValidSortOrderProperty &&
                                                                        m.SortPropertyName == PostLikeTestUtilities.ValidSortPropertyName), CancellationToken);
    }

    [Fact]
    public async Task Handle_ShouldReturnFollowViewModelCollection_WhenQueryIsValid()
    {
        // Arrange
        var query = new GetAllPostLikesQuery(
            PostLikeTestUtilities.ValidPostLikeCurrentUserId,
            PostLikeTestUtilities.ValidUserName,
            PostLikeTestUtilities.ValidPostLikePostId,
            PostLikeTestUtilities.ValidSortOrderProperty,
            PostLikeTestUtilities.ValidSortPropertyName,
            PostLikeTestUtilities.ValidPageValue,
            PostLikeTestUtilities.ValidPageSizeValue);

        // Act
        var response = await _queryHandler.Handle(query, CancellationToken);

        // Assert
        response
            .Should()
            .Match<PostLikePaginationQueryViewModel>(mc => mc.Items.All(m => m.Id == PostLikeTestUtilities.ValidId &&
                                                           m.UserId == PostLikeTestUtilities.ValidPostLikeCurrentUserId &&
                                                           m.UserName == PostLikeTestUtilities.ValidUserName &&
                                                           m.UserProfileImage == PostLikeTestUtilities.ValidUserProfileImage &&
                                                           m.PostId == PostLikeTestUtilities.ValidPostLikePostId) &&
                                                           mc.Page == PostLikeTestUtilities.ValidPageValue &&
                                                           mc.PageSize == PostLikeTestUtilities.ValidPageSizeValue &&
                                                           mc.TotalCount == PostLikeTestUtilities.ValidTotalCountValue &&
                                                           !mc.HasPreviousPage &&
                                                           !mc.HasNextPage);
        ;
    }
}
