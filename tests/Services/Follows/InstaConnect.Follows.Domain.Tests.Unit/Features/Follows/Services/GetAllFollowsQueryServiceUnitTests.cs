using InstaConnect.Follows.Domain.Features.Follows.Helpers;
using InstaConnect.Follows.Domain.Features.Follows.Models.Requests;
using InstaConnect.Follows.Domain.Tests.Features.Follows.Assertions;
using InstaConnect.Follows.Domain.Tests.Features.Follows.Builders;
using InstaConnect.Follows.Domain.Tests.Features.Follows.Utilities;
using InstaConnect.Follows.Domain.Tests.Unit.Features.Follows.Utilities;

namespace InstaConnect.Follows.Domain.Tests.Unit.Features.Follows.Services;

public class GetAllFollowsQueryServiceUnitTests : BaseFollowDomainQueryUnitTest
{
	private readonly GetAllFollowsQueryBuilderFactory _queryBuilderFactory;
	private readonly GetAllFollowsQueryBuilder _queryBuilder;
	private readonly GetAllFollowsQuery _query;

	private readonly FollowQueryService _service;

	public GetAllFollowsQueryServiceUnitTests()
	{
		_queryBuilderFactory = new();
		_queryBuilder = _queryBuilderFactory.Create(Follow);
		_query = _queryBuilder.Build();

		_service = new(Repository, UserRepository, CollectionResponseFactory);

		UserRepository.SetupGetById(_query, Follower, CancellationToken);
		Repository.SetupGetAllQuery(_query, Follows, CancellationToken);
		Repository.SetupGetTotalCount(_query, Follows, CancellationToken);
	}

	[Fact]
	public async Task GetAllAsync_ShouldThrowUserNotFoundException_WhenFollowerIdIsInvalid()
	{
		// Arrange
		UserRepository.RemoveGetById(_query, Follower, CancellationToken);

		// Assert
		await _service.ShouldThrowFollowerNotFoundExceptionAsync(_query, CancellationToken);
	}

	[Fact]
	public async Task GetAllAsync_ShouldReturnResponse_WhenQueryIsValid()
	{
		// Act
		var response = await _service.GetAllAsync(_query, CancellationToken);

		// Assert
		response.ShouldSatisfy(_query, Follower, Follows);
	}

	[Fact]
	public async Task GetAllAsync_ShouldCallTheUserRepositoryGetByIdAsync_WhenQueryIsValid()
	{
		// Act
		await _service.GetAllAsync(_query, CancellationToken);

		// Assert
		await UserRepository.ShouldReceiveOneGetByIdAsync(_query, CancellationToken);
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
