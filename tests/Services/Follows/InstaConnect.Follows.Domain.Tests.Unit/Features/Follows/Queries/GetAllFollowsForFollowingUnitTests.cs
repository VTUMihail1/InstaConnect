using InstaConnect.Follows.Domain.Features.Follows.Helpers;
using InstaConnect.Follows.Domain.Features.Follows.Models.Requests;
using InstaConnect.Follows.Domain.Tests.Features.Follows.Assertions;
using InstaConnect.Follows.Domain.Tests.Features.Follows.Builders;
using InstaConnect.Follows.Domain.Tests.Features.Follows.Utilities;
using InstaConnect.Follows.Domain.Tests.Unit.Features.Follows.Utilities;

namespace InstaConnect.Follows.Domain.Tests.Unit.Features.Follows.Queries;

public class GetAllFollowsForFollowingUnitTests : BaseFollowDomainQueryUnitTest
{
	private readonly GetAllFollowsForFollowingQueryBuilderFactory _queryBuilderFactory;
	private readonly GetAllFollowsForFollowingQueryBuilder _queryBuilder;
	private readonly GetAllFollowsForFollowingQuery _query;

	private readonly FollowQueryService _service;

	public GetAllFollowsForFollowingUnitTests()
	{
		_queryBuilderFactory = new();
		_queryBuilder = _queryBuilderFactory.Create(Follow);
		_query = _queryBuilder.Build();

		_service = new(Repository, UserRepository, CollectionResponseFactory);

		UserRepository.SetupGetById(_query, Following, CancellationToken);
		Repository.SetupGetAllForFollowingQuery(_query, Follows, CancellationToken);
		Repository.SetupGetTotalCountForFollowing(_query, Follows, CancellationToken);
	}

	[Fact]
	public async Task GetAllForFollowingAsync_ShouldThrowUserNotFoundException_WhenFollowingIdIsInvalid()
	{
		// Arrange
		UserRepository.RemoveGetById(_query, Following, CancellationToken);

		// Assert
		await _service.ShouldThrowFollowingNotFoundExceptionAsync(_query, CancellationToken);
	}

	[Fact]
	public async Task GetAllForFollowingAsync_ShouldReturnResponse_WhenQueryIsValid()
	{
		// Act
		var response = await _service.GetAllForFollowingAsync(_query, CancellationToken);

		// Assert
		response.ShouldSatisfy(Following, Follows, _query);
	}

	[Fact]
	public async Task GetAllForFollowingAsync_ShouldCallTheUserRepositoryGetByIdAsync_WhenQueryIsValid()
	{
		// Act
		await _service.GetAllForFollowingAsync(_query, CancellationToken);

		// Assert
		await UserRepository.ShouldReceiveOneGetByIdAsync(_query, CancellationToken);
	}

	[Fact]
	public async Task GetAllForFollowingAsync_ShouldCallTheRepositoryGetAllForFollowingAsync_WhenQueryIsValid()
	{
		// Act
		await _service.GetAllForFollowingAsync(_query, CancellationToken);

		// Assert
		await Repository.ShouldReceiveOneGetAllForFollowingAsync(_query, CancellationToken);
	}

	[Fact]
	public async Task GetAllForFollowingAsync_ShouldCallTheRepositoryGetTotalCountForFollowingAsync_WhenQueryIsValid()
	{
		// Act
		await _service.GetAllForFollowingAsync(_query, CancellationToken);

		// Assert
		await Repository.ShouldReceiveOneGetTotalCountForFollowingAsync(_query, CancellationToken);
	}
}
