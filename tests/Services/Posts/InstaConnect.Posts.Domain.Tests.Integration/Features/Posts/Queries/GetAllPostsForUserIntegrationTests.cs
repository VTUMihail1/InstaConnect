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
using InstaConnect.Posts.Tests.Features.Posts.DataAttributes.SortTerm.ForUser;
using InstaConnect.Posts.Tests.Features.Posts.DataAttributes.Title;
using InstaConnect.Posts.Tests.Features.Posts.Utilities;
using InstaConnect.Posts.Tests.Features.Users.DataAttributes.Id;
using InstaConnect.Posts.Tests.Features.Users.Utilities;

namespace InstaConnect.Posts.Domain.Tests.Integration.Features.Posts.Queries;

public class GetAllPostsForUserIntegrationTests : BasePostDomainQueryIntegrationTest
{
	private readonly GetAllPostsForUserQueryBuilderFactory _queryBuilderFactory;
	private readonly GetAllPostsForUserQueryBuilder _queryBuilder;
	private readonly GetAllPostsForUserQuery _query;

	public GetAllPostsForUserIntegrationTests(PostsWebApplicationFactory webApplicationFactory)
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
	public async Task GetAllForUserAsync_ShouldThrowUserNotFoundException_WhenUserIdIsInvalid()
	{
		// Arrange
		await ServiceScope.DeleteUserAsync(User, CancellationToken);

		// Assert
		await Service.ShouldThrowUserNotFoundExceptionAsync(_query, CancellationToken);
	}

	[Fact]
	public async Task GetAllForUserAsync_ShouldReturnResponse_WhenQueryIsValid()
	{
		// Act
		var response = await Service.GetAllForUserAsync(_query, CancellationToken);

		// Assert
		response.ShouldSatisfy(User, Posts, _query);
	}

	[Theory]
	[UserIdDifferentCaseData]
	public async Task GetAllForUserAsync_ShouldReturnResponse_WhenQueryAndUserIdAreValid(
		IStringTransformer transformer)
	{
		// Arrange
		var query = _queryBuilder.WithUserId(transformer).Build();

		// Act
		var response = await Service.GetAllForUserAsync(query, CancellationToken);

		// Assert
		response.ShouldSatisfy(User, Posts, query);
	}

	[Theory]
	[PostTitleNullData]
	[PostTitleEmptyData]
	[PostTitleDifferentCaseData]
	public async Task GetAllForUserAsync_ShouldReturnResponse_WhenQueryAndTitleAreValid(
		IStringTransformer transformer)
	{
		// Arrange
		var query = _queryBuilder.WithTitle(transformer).Build();

		// Act
		var response = await Service.GetAllForUserAsync(query, CancellationToken);

		// Assert
		response.ShouldSatisfy(User, Posts, query);
	}

	[Theory]
	[UserIdNullData]
	[UserIdEmptyData]
	[UserIdDifferentCaseData]
	public async Task GetAllForUserAsync_ShouldReturnResponse_WhenQueryAndCurrentUserIdAreValid(
		IStringTransformer transformer)
	{
		// Arrange
		var query = _queryBuilder.WithCurrentUserId(transformer).Build();

		// Act
		var response = await Service.GetAllForUserAsync(query, CancellationToken);

		// Assert
		response.ShouldSatisfy(User, Posts, query);
	}

	[Theory]
	[PostsSortOrderWithAscendingTermData]
	[PostsSortOrderWithDescendingTermData]
	public async Task GetAllForUserAsync_ShouldReturnResponse_WhenQueryAndSortOrderAreValid(
		IEnumTransformer<CommonSortOrder> transformer, ISortEnumTermTransformer<Post> termTransformer)
	{
		// Arrange
		var query = _queryBuilder.WithSortOrder(transformer).Build();

		// Act
		var response = await Service.GetAllForUserAsync(query, CancellationToken);

		// Assert
		response.ShouldSatisfy(User, Posts, query, termTransformer);
	}

	[Theory]
	[PostsForUserSortTermWithCreatedAtTermData]
	[PostsForUserSortTermWithTitleTermData]
	[PostsForUserSortTermWithUserNameTermData]
	public async Task GetAllForUserAsync_ShouldReturnResponse_WhenQueryAndSortTermAreValid(
		IEnumTransformer<PostsForUserSortTerm> transformer, ISortEnumTermTransformer<Post> termTransformer)
	{
		// Arrange
		var query = _queryBuilder.WithSortTerm(transformer).Build();

		// Act
		var response = await Service.GetAllForUserAsync(query, CancellationToken);

		// Assert
		response.ShouldSatisfy(User, Posts, query, termTransformer);
	}
}
