using FluentAssertions;
using InstaConnect.Posts.Business.Features.PostCommentLikes.Models;
using InstaConnect.Posts.Business.Features.PostCommentLikes.Queries.GetAllPostCommentLikes;
using InstaConnect.Posts.Business.UnitTests.Features.PostCommentLikes.Utilities;
using InstaConnect.Posts.Common.Features.PostCommentLikes.Utilities;
using InstaConnect.Posts.Data.Features.PostCommentLikes.Models.Filters;
using NSubstitute;
using NSubstitute.ReceivedExtensions;

namespace InstaConnect.Posts.Business.UnitTests.Features.PostCommentLikes.Queries.GetAllPostCommentLikes;

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
            ValidSortOrderProperty,
            ValidSortPropertyName,
            ValidPageValue,
            ValidPageSizeValue);

        // Act
        await _queryHandler.Handle(query, CancellationToken);

        // Assert
        await PostCommentLikeReadRepository
            .Received(1)
            .GetAllAsync(Arg.Is<PostCommentLikeCollectionReadQuery>(m =>
                                                                        m.UserId == PostCommentLikeTestUtilities.ValidPostCommentLikeCurrentUserId &&
                                                                        m.UserName == PostCommentLikeTestUtilities.ValidUserName &&
                                                                        m.PostCommentId == PostCommentLikeTestUtilities.ValidPostCommentLikePostCommentId &&
                                                                        m.Page == ValidPageValue &&
                                                                        m.PageSize == ValidPageSizeValue &&
                                                                        m.SortOrder == ValidSortOrderProperty &&
                                                                        m.SortPropertyName == ValidSortPropertyName), CancellationToken);
    }

    [Fact]
    public async Task Handle_ShouldReturnFollowViewModelCollection_WhenQueryIsValid()
    {
        // Arrange
        var query = new GetAllPostCommentLikesQuery(
            PostCommentLikeTestUtilities.ValidPostCommentLikeCurrentUserId,
            PostCommentLikeTestUtilities.ValidUserName,
            PostCommentLikeTestUtilities.ValidPostCommentLikePostCommentId,
            ValidSortOrderProperty,
            ValidSortPropertyName,
            ValidPageValue,
            ValidPageSizeValue);

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
                                                           mc.Page == ValidPageValue &&
                                                           mc.PageSize == ValidPageSizeValue &&
                                                           mc.TotalCount == ValidTotalCountValue &&
                                                           !mc.HasPreviousPage &&
                                                           !mc.HasNextPage);
    }
}
