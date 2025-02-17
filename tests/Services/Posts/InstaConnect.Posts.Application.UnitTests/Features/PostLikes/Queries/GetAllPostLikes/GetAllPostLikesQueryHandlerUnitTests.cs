using InstaConnect.Posts.Application.Features.PostLikes.Queries.GetAll;
using InstaConnect.Posts.Domain.Features.PostLikes.Models.Filters;

namespace InstaConnect.Posts.Application.UnitTests.Features.PostLikes.Queries.GetAllPostLikes;

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
        var existingPostLike = CreatePostLike();
        var query = new GetAllPostLikesQuery(
            existingPostLike.UserId,
            existingPostLike.User.UserName,
            existingPostLike.PostId,
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
                                                                        m.UserId == existingPostLike.UserId &&
                                                                        m.UserName == existingPostLike.User.UserName &&
                                                                        m.PostId == existingPostLike.PostId &&
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
        var existingPostLike = CreatePostLike();
        var query = new GetAllPostLikesQuery(
            existingPostLike.UserId,
            existingPostLike.User.UserName,
            existingPostLike.PostId,
            PostLikeTestUtilities.ValidSortOrderProperty,
            PostLikeTestUtilities.ValidSortPropertyName,
            PostLikeTestUtilities.ValidPageValue,
            PostLikeTestUtilities.ValidPageSizeValue);

        // Act
        var response = await _queryHandler.Handle(query, CancellationToken);

        // Assert
        response
            .Should()
            .Match<PostLikePaginationQueryViewModel>(mc => mc.Items.All(m => m.Id == existingPostLike.Id &&
                                                           m.UserId == existingPostLike.UserId &&
                                                           m.UserName == existingPostLike.User.UserName &&
                                                           m.UserProfileImage == existingPostLike.User.ProfileImage &&
                                                           m.PostId == existingPostLike.PostId) &&
                                                           mc.Page == PostLikeTestUtilities.ValidPageValue &&
                                                           mc.PageSize == PostLikeTestUtilities.ValidPageSizeValue &&
                                                           mc.TotalCount == PostLikeTestUtilities.ValidTotalCountValue &&
                                                           !mc.HasPreviousPage &&
                                                           !mc.HasNextPage);
        ;
    }
}
