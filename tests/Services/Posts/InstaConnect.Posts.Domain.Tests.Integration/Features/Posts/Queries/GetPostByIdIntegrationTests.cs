using InstaConnect.Common.Tests.Features.DataAttributes.Strings.Base;
using InstaConnect.Posts.Domain.Features.Posts.Models.Requests;
using InstaConnect.Posts.Domain.Tests.Features.Posts.Assertions;
using InstaConnect.Posts.Domain.Tests.Features.Posts.Builders;
using InstaConnect.Posts.Domain.Tests.Integration.Features.Posts.Utilities;
using InstaConnect.Posts.Tests.Features.PostLikes.Utilities;
using InstaConnect.Posts.Tests.Features.Posts.DataAttributes.Id;
using InstaConnect.Posts.Tests.Features.Posts.Utilities;
using InstaConnect.Posts.Tests.Features.Users.DataAttributes.Id;
using InstaConnect.Posts.Tests.Features.Users.Utilities;

namespace InstaConnect.Posts.Domain.Tests.Integration.Features.Posts.Queries;

public class GetPostByIdIntegrationTests : BasePostDomainQueryIntegrationTest
{
	private readonly GetPostByIdQueryBuilderFactory _queryBuilderFactory;
	private readonly GetPostByIdQueryBuilder _queryBuilder;
	private readonly GetPostByIdQuery _query;

	public GetPostByIdIntegrationTests(PostsWebApplicationFactory webApplicationFactory)
		: base(webApplicationFactory)
	{
		_queryBuilderFactory = new();
		_queryBuilder = _queryBuilderFactory.Create(Post);
		_query = _queryBuilder.Build();
	}

	protected override async Task OnInitializeAsync()
	{
		await ServiceScope.AddUserAsync(User, CancellationToken);
		await ServiceScope.AddPostAsync(Post, CancellationToken);
		await ServiceScope.AddPostLikeAsync(PostLike, CancellationToken);
	}


	[Fact]
	public async Task GetByIdAsync_ShouldThrowPostNotFoundException_WhenIdIsInvalid()
	{
		// Arrange
		await ServiceScope.DeletePostAsync(Post, CancellationToken);

		// Assert
		await Service.ShouldThrowPostNotFoundExceptionAsync(_query, CancellationToken);
	}

	[Fact]
	public async Task GetByIdAsync_ShouldReturnResponse_WhenQueryIsValid()
	{
		// Act
		var response = await Service.GetByIdAsync(_query, CancellationToken);

		// Assert
		response.ShouldSatisfy(Post, _query);
	}

	[Theory]
	[PostIdDifferentCaseData]
	public async Task GetByIdAsync_ShouldReturnResponse_WhenQueryAndIdAreValid(
		IStringTransformer transformer)
	{
		// Arrange
		var query = _queryBuilder.WithId(transformer).Build();

		// Act
		var response = await Service.GetByIdAsync(query, CancellationToken);

		// Assert
		response.ShouldSatisfy(Post, query);
	}

	[Theory]
	[UserIdNullData]
	[UserIdEmptyData]
	[UserIdDifferentCaseData]
	public async Task GetByIdAsync_ShouldReturnResponse_WhenQueryAndCurrentUserIdAreValid(
		IStringTransformer transformer)
	{
		// Arrange
		var query = _queryBuilder.WithCurrentUserId(transformer).Build();

		// Act
		var response = await Service.GetByIdAsync(query, CancellationToken);

		// Assert
		response.ShouldSatisfy(Post, query);
	}
}
