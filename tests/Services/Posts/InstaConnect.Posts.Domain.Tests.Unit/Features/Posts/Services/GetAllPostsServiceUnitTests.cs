using InstaConnect.Posts.Domain.Features.Posts.Helpers;
using InstaConnect.Posts.Domain.Features.Posts.Models.Requests;
using InstaConnect.Posts.Domain.Tests.Features.Posts.Assertions;
using InstaConnect.Posts.Domain.Tests.Features.Posts.Builders;
using InstaConnect.Posts.Domain.Tests.Features.Posts.Utilities;
using InstaConnect.Posts.Domain.Tests.Unit.Features.Posts.Utilities;

namespace InstaConnect.Posts.Domain.Tests.Unit.Features.Posts.Services;

public class GetAllPostsServiceUnitTests : BasePostDomainQueryUnitTest
{
	private readonly GetAllPostsQueryBuilderFactory _queryBuilderFactory;
	private readonly GetAllPostsQueryBuilder _queryBuilder;
	private readonly GetAllPostsQuery _query;

	private readonly PostQueryService _service;

	public GetAllPostsServiceUnitTests()
	{
		_queryBuilderFactory = new();
		_queryBuilder = _queryBuilderFactory.Create(Post);
		_query = _queryBuilder.Build();

		_service = new(Repository, UserRepository, CollectionResponseFactory);

		Repository.SetupGetAllQuery(_query, Posts, CancellationToken);
		Repository.SetupGetTotalCount(_query, Posts, CancellationToken);
	}

	[Fact]
	public async Task GetAllAsync_ShouldReturnResponse_WhenQueryIsValid()
	{
		// Act
		var response = await _service.GetAllAsync(_query, CancellationToken);

		// Assert
		response.ShouldSatisfy(Posts, _query);
	}

	[Fact]
	public async Task GetAllAsync_ShouldCallTheRepositoryGetAllAsync_WhenQueryIsValid()
	{
		// Act
		await _service.GetAllAsync(_query, CancellationToken);

		// Assert
		await Repository.ShouldReceiveOneGetAllAsync(_query, CancellationToken);
	}

	[Fact]
	public async Task GetAllAsync_ShouldCallTheRepositoryGetTotalCountAsync_WhenQueryIsValid()
	{
		// Act
		await _service.GetAllAsync(_query, CancellationToken);

		// Assert
		await Repository.ShouldReceiveOneGetTotalCountAsync(_query, CancellationToken);
	}
}
