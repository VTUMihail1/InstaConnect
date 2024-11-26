using FluentAssertions;
using InstaConnect.Posts.Application.Features.PostCommentLikes.Models;
using InstaConnect.Posts.Application.Features.PostCommentLikes.Queries.GetAllPostCommentLikes;
using InstaConnect.Posts.Application.UnitTests.Features.PostCommentLikes.Utilities;
using InstaConnect.Posts.Common.Features.PostCommentLikes.Utilities;
using InstaConnect.Posts.Domain.Features.PostCommentLikes.Models.Filters;
using NSubstitute;
using NSubstitute.ReceivedExtensions;

namespace InstaConnect.Posts.Application.UnitTests.Features.PostCommentLikes.Queries.GetAllPostCommentLikes;

public class GetAllPostCommentLikesQueryHandlerUnitTests : BasePostCommentLikeUnitTest
{
    private readonly GetAllPostCommentLikesQueryHandler _queryHandler;

    public GetAllPostCommentLikesQueryHandlerUnitTests()
    {
        _queryHandler = new(
            InstaConnectMapper,
            PostCommentLikeReadRepository);
    }

    [Fact]
    public async Task Handle_ShouldCallRepositoryWithGetAllMethod_WhenQueryIsValid()
    {
        // Arrange
        var query = new GetAllPostCommentLikesQuery(
            PostCommentLikeTestUtilities.ValidPostCommentLikeCurrentUserId,
            PostCommentLikeTestUtilities.ValidUserName,
            PostCommentLikeTestUtilities.ValidPostCommentLikePostCommentId,
            PostCommentLikeTestUtilities.ValidSortOrderProperty,
            PostCommentLikeTestUtilities.ValidSortPropertyName,
            PostCommentLikeTestUtilities.ValidPageValue,
            PostCommentLikeTestUtilities.ValidPageSizeValue);

        // Act
        await _queryHandler.Handle(query, CancellationToken);

        // Assert
        await PostCommentLikeReadRepository
            .Received(1)
            .GetAllAsync(Arg.Is<PostCommentLikeCollectionReadQuery>(m =>
                                                                        m.UserId == PostCommentLikeTestUtilities.ValidPostCommentLikeCurrentUserId &&
                                                                        m.UserName == PostCommentLikeTestUtilities.ValidUserName &&
                                                                        m.PostCommentId == PostCommentLikeTestUtilities.ValidPostCommentLikePostCommentId &&
                                                                        m.Page == PostCommentLikeTestUtilities.ValidPageValue &&
                                                                        m.PageSize == PostCommentLikeTestUtilities.ValidPageSizeValue &&
                                                                        m.SortOrder == PostCommentLikeTestUtilities.ValidSortOrderProperty &&
                                                                        m.SortPropertyName == PostCommentLikeTestUtilities.ValidSortPropertyName), CancellationToken);
    }

    [Fact]
    public async Task Handle_ShouldReturnFollowViewModelCollection_WhenQueryIsValid()
    {
        // Arrange
        var query = new GetAllPostCommentLikesQuery(
            PostCommentLikeTestUtilities.ValidPostCommentLikeCurrentUserId,
            PostCommentLikeTestUtilities.ValidUserName,
            PostCommentLikeTestUtilities.ValidPostCommentLikePostCommentId,
            PostCommentLikeTestUtilities.ValidSortOrderProperty,
            PostCommentLikeTestUtilities.ValidSortPropertyName,
            PostCommentLikeTestUtilities.ValidPageValue,
            PostCommentLikeTestUtilities.ValidPageSizeValue);

        // Act
        var response = await _queryHandler.Handle(query, CancellationToken);

        // Assert
        response
            .Should()
            .Match<PostCommentLikePaginationQueryViewModel>(mc => mc.Items.All(m => m.Id == PostCommentLikeTestUtilities.ValidId &&
                                                           m.UserId == PostCommentLikeTestUtilities.ValidPostCommentLikeCurrentUserId &&
                                                           m.UserName == PostCommentLikeTestUtilities.ValidUserName &&
                                                           m.UserProfileImage == PostCommentLikeTestUtilities.ValidUserProfileImage &&
                                                           m.PostCommentId == PostCommentLikeTestUtilities.ValidPostCommentLikePostCommentId) &&
                                                           mc.Page == PostCommentLikeTestUtilities.ValidPageValue &&
                                                           mc.PageSize == PostCommentLikeTestUtilities.ValidPageSizeValue &&
                                                           mc.TotalCount == PostCommentLikeTestUtilities.ValidTotalCountValue &&
                                                           !mc.HasPreviousPage &&
                                                           !mc.HasNextPage);
    }
}
