using FluentAssertions;
using InstaConnect.Follows.Business.UnitTests.Features.Follows.Utilities;
using InstaConnect.Posts.Business.Features.PostLikes.Models;
using InstaConnect.Posts.Business.Features.PostLikes.Queries.GetAllPostLikes;
using InstaConnect.Posts.Business.Features.Posts.Models;
using InstaConnect.Posts.Business.Features.Posts.Queries.GetAllPosts;
using InstaConnect.Posts.Data.Features.PostLikes.Models.Filters;
using InstaConnect.Shared.Data.Models.Filters;
using NSubstitute;

namespace InstaConnect.Follows.Business.UnitTests.Features.Follows.Queries.GetAllFollows;

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
            ValidSortOrderProperty,
            ValidSortPropertyName,
            ValidPageValue,
            ValidPageSizeValue);

        // Act
        await _queryHandler.Handle(query, CancellationToken);

        // Assert
        await PostLikeReadRepository
            .Received(1)
            .GetAllAsync(Arg.Is<PostLikeCollectionReadQuery>(m => m.Page == ValidPageValue &&
                                                                 m.PageSize == ValidPageSizeValue &&
                                                                 m.SortOrder == ValidSortOrderProperty &&
                                                                 m.SortPropertyName == ValidSortPropertyName), CancellationToken);
    }

    [Fact]
    public async Task Handle_ShouldReturnPostViewModelCollection_WhenQueryIsValid()
    {
        // Arrange
        var query = new GetAllPostLikesQuery(
            ValidSortOrderProperty,
            ValidSortPropertyName,
            ValidPageValue,
            ValidPageSizeValue);

        // Act
        var response = await _queryHandler.Handle(query, CancellationToken);

        // Assert
        response
            .Should()
            .Match<PostLikePaginationQueryViewModel>(mc => mc.Items.All(m => m.Id == ValidId &&
                                                           m.UserId == ValidPostLikeCurrentUserId &&
                                                           m.UserName == ValidUserName &&
                                                           m.UserProfileImage == ValidUserProfileImage &&
                                                           m.PostId == ValidPostLikePostId) &&
                                                           mc.Page == ValidPageValue &&
                                                           mc.PageSize == ValidPageSizeValue &&
                                                           mc.TotalCount == ValidTotalCountValue &&
                                                           !mc.HasPreviousPage &&
                                                           !mc.HasNextPage);
        ;
    }
}
