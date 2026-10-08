using InstaConnect.Posts.Domain.Features.PostCommentLikes.Models.Requests;
using InstaConnect.Posts.Infrastructure.Tests.Features.PostCommentLikes.Assertions;
using InstaConnect.Posts.Infrastructure.Tests.Features.PostCommentLikes.Builders;
using InstaConnect.Posts.Infrastructure.Tests.Integration.Features.PostCommentLikes.Utilities;
using InstaConnect.Posts.Tests.Features.PostCommentLikes.Utilities;
using InstaConnect.Posts.Tests.Features.PostComments.Utilities;
using InstaConnect.Posts.Tests.Features.Posts.Utilities;

namespace InstaConnect.Posts.Infrastructure.Tests.Integration.Features.PostCommentLikes.Repositories;

public class GetPostCommentLikesForUserTotalCountQueryRepositoryIntegrationTests : BasePostCommentLikeInfrastructureQueryIntegrationTest
{
	private readonly PostCommentLikesForUserFilterQueryBuilderFactory _filterQueryBuilderFactory;
	private readonly PostCommentLikesForUserFilterQueryBuilder _filterQueryBuilder;
	private readonly PostCommentLikesForUserFilterQuery _filterQuery;

	public GetPostCommentLikesForUserTotalCountQueryRepositoryIntegrationTests(PostsWebApplicationFactory webApplicationFactory)
		: base(webApplicationFactory)
	{
		_filterQueryBuilderFactory = new();
		_filterQueryBuilder = _filterQueryBuilderFactory.Create(PostCommentLike);
		_filterQuery = _filterQueryBuilder.Build();
	}

	public override async Task InitializeAsync()
	{
		await base.InitializeAsync();
		await ServiceScope.AddRangeAsync(PostCommentLikes, CancellationToken);
	}

	[Fact]
	public async Task GetTotalCountForUserAsync_ShouldReturnResponse_WhenQueryIsValid()
	{
		// Act
		var response = await Repository.GetTotalCountForUserAsync(_filterQuery, CancellationToken);

		// Assert
		response.ShouldSatisfy(_filterQuery, PostCommentLikes);
	}

	[Theory]
	[UserIdDifferentCaseData]
	public async Task GetTotalCountForUserAsync_ShouldReturnResponse_WhenQueryAndUserIdAreValid(
		IStringTransformer transformer)
	{
		// Arrange
		var filterQuery = _filterQueryBuilder.WithUserId(transformer).Build();

		// Act
		var response = await Repository.GetTotalCountForUserAsync(filterQuery, CancellationToken);

		// Assert
		response.ShouldSatisfy(filterQuery, PostCommentLikes);
	}
}
