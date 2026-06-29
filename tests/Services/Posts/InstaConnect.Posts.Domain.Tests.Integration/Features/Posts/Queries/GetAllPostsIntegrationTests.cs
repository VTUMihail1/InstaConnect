using InstaConnect.Common.Domain.Features.Messaging.Models;
using InstaConnect.Common.Tests.Features.DataAttributes.Enums.Base;
using InstaConnect.Common.Tests.Features.DataAttributes.Enums.Sort;
using InstaConnect.Common.Tests.Features.DataAttributes.Strings.Base;
using InstaConnect.Posts.Domain.Features.Posts.Models.Entities;
using InstaConnect.Posts.Domain.Features.Posts.Models.Requests;
using InstaConnect.Posts.Domain.Tests.Features.Posts.Assertions;
using InstaConnect.Posts.Domain.Tests.Features.Posts.Builders;
using InstaConnect.Posts.Domain.Tests.Integration.Features.Posts.Utilities;
using InstaConnect.Posts.Tests.Features.PostLikes.Utilities;
using InstaConnect.Posts.Tests.Features.Posts.DataAttributes.SortOrder;
using InstaConnect.Posts.Tests.Features.Posts.DataAttributes.SortTerm;
using InstaConnect.Posts.Tests.Features.Posts.DataAttributes.Title;
using InstaConnect.Posts.Tests.Features.Posts.Utilities;
using InstaConnect.Posts.Tests.Features.Users.DataAttributes.Id;
using InstaConnect.Posts.Tests.Features.Users.DataAttributes.Name;
using InstaConnect.Posts.Tests.Features.Users.Utilities;

namespace InstaConnect.Posts.Domain.Tests.Integration.Features.Posts.Queries;

public class GetAllPostsIntegrationTests : BasePostDomainQueryIntegrationTest
{
	private readonly GetAllPostsQueryBuilderFactory _queryBuilderFactory;
	private readonly GetAllPostsQueryBuilder _queryBuilder;
	private readonly GetAllPostsQuery _query;

	public GetAllPostsIntegrationTests(PostsWebApplicationFactory webApplicationFactory)
		: base(webApplicationFactory)
	{
		_queryBuilderFactory = new();
		_queryBuilder = _queryBuilderFactory.Create(Post);
		_query = _queryBuilder.Build();
	}

	protected override async Task OnInitializeAsync()
	{
		await ServiceScope.AddUserRangeAsync(Users, CancellationToken);
		await ServiceScope.AddPostRangeAsync(Posts, CancellationToken);
		await ServiceScope.AddPostLikeRangeAsync(PostLikes, CancellationToken);
	}

	[Fact]
	public async Task GetAllAsync_ShouldReturnResponse_WhenQueryIsValid()
	{
		// Act
		var response = await Service.GetAllAsync(_query, CancellationToken);

		// Assert
		response.ShouldSatisfy(Posts, _query);
	}

	[Theory]
	[UserNameNullData]
	[UserNameEmptyData]
	[UserNameDifferentCaseData]
	public async Task GetAllAsync_ShouldReturnResponse_WhenQueryAndUserNameAreValid(
		IStringTransformer transformer)
	{
		// Arrange
		var query = _queryBuilder.WithUserName(transformer).Build();

		// Act
		var response = await Service.GetAllAsync(query, CancellationToken);

		// Assert
		response.ShouldSatisfy(Posts, query);
	}

	[Theory]
	[PostTitleNullData]
	[PostTitleEmptyData]
	[PostTitleDifferentCaseData]
	public async Task GetAllAsync_ShouldReturnResponse_WhenQueryAndTitleAreValid(
		IStringTransformer transformer)
	{
		// Arrange
		var query = _queryBuilder.WithTitle(transformer).Build();

		// Act
		var response = await Service.GetAllAsync(query, CancellationToken);

		// Assert
		response.ShouldSatisfy(Posts, query);
	}

	[Theory]
	[UserIdNullData]
	[UserIdEmptyData]
	[UserIdDifferentCaseData]
	public async Task GetAllAsync_ShouldReturnResponse_WhenQueryAndCurrentUserIdAreValid(
		IStringTransformer transformer)
	{
		// Arrange
		var query = _queryBuilder.WithCurrentUserId(transformer).Build();

		// Act
		var response = await Service.GetAllAsync(query, CancellationToken);

		// Assert
		response.ShouldSatisfy(Posts, query);
	}

	[Theory]
	[PostsSortOrderWithAscendingTermData]
	[PostsSortOrderWithDescendingTermData]
	public async Task GetAllAsync_ShouldReturnResponse_WhenQueryAndSortOrderAreValid(
		IEnumTransformer<CommonSortOrder> transformer, ISortEnumTermTransformer<Post> termTransformer)
	{
		// Arrange
		var query = _queryBuilder.WithSortOrder(transformer).Build();

		// Act
		var response = await Service.GetAllAsync(query, CancellationToken);

		// Assert
		response.ShouldSatisfy(Posts, query, termTransformer);
	}

	[Theory]
	[PostsSortTermWithCreatedAtTermData]
	[PostsSortTermWithTitleTermData]
	[PostsSortTermWithUserNameTermData]
	public async Task GetAllAsync_ShouldReturnResponse_WhenQueryAndSortTermAreValid(
		IEnumTransformer<PostsSortTerm> transformer, ISortEnumTermTransformer<Post> termTransformer)
	{
		// Arrange
		var query = _queryBuilder.WithSortTerm(transformer).Build();

		// Act
		var response = await Service.GetAllAsync(query, CancellationToken);

		// Assert
		response.ShouldSatisfy(Posts, query, termTransformer);
	}
}
