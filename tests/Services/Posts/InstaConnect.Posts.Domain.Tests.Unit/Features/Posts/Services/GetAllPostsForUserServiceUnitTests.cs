using InstaConnect.Posts.Domain.Features.Posts.Helpers;
using InstaConnect.Posts.Domain.Features.Posts.Models.Requests;
using InstaConnect.Posts.Domain.Tests.Features.Posts.Assertions;
using InstaConnect.Posts.Domain.Tests.Features.Posts.Builders;
using InstaConnect.Posts.Domain.Tests.Features.Posts.Utilities;
using InstaConnect.Posts.Domain.Tests.Unit.Features.Posts.Utilities;

namespace InstaConnect.Posts.Domain.Tests.Unit.Features.Posts.Services;

public class GetAllPostsForUserServiceUnitTests : BasePostDomainQueryUnitTest
{
	private readonly GetAllPostsForUserQueryBuilderFactory _queryBuilderFactory;
	private readonly GetAllPostsForUserQueryBuilder _queryBuilder;
	private readonly GetAllPostsForUserQuery _query;

	private readonly PostQueryService _service;

	public GetAllPostsForUserServiceUnitTests()
	{
		_queryBuilderFactory = new();
		_queryBuilder = _queryBuilderFactory.Create(Post);
		_query = _queryBuilder.Build();

		_service = new(Repository, UserRepository, CollectionResponseFactory);

		Repository.SetupGetAllForUserQuery(_query, User, Posts, CancellationToken);
		Repository.SetupGetTotalCountForUser(_query, Posts, CancellationToken);
		UserRepository.SetupGetById(_query, User, CancellationToken);
	}

	[Fact]
	public async Task GetAllForUserAsync_ShouldThrowUserNotFoundException_WhenUserIdIsInvalid()
	{
		// Arrange
		UserRepository.RemoveGetById(_query, User, CancellationToken);

		// Assert
		await _service.ShouldThrowUserNotFoundExceptionAsync(_query, CancellationToken);
	}

	[Fact]
	public async Task GetAllForUserAsync_ShouldReturnResponse_WhenQueryIsValid()
	{
		// Act
		var response = await _service.GetAllForUserAsync(_query, CancellationToken);

		// Assert
		response.ShouldSatisfy(User, Posts, _query);
	}

	[Fact]
	public async Task GetAllForUserAsync_ShouldCallTheUserRepositoryGetByIdAsync_WhenQueryIsValid()
	{
		// Act
		await _service.GetAllForUserAsync(_query, CancellationToken);

		// Assert
		await UserRepository.ShouldReceiveOneGetByIdAsync(_query, CancellationToken);
	}

	[Fact]
	public async Task GetAllForUserAsync_ShouldCallTheRepositoryGetAllForUserAsync_WhenQueryIsValid()
	{
		// Act
		await _service.GetAllForUserAsync(_query, CancellationToken);

		// Assert
		await Repository.ShouldReceiveOneGetAllForUserAsync(_query, CancellationToken);
	}

	[Fact]
	public async Task GetAllForUserAsync_ShouldCallTheRepositoryGetTotalCountForUserAsync_WhenQueryIsValid()
	{
		// Act
		await _service.GetAllForUserAsync(_query, CancellationToken);

		// Assert
		await Repository.ShouldReceiveOneGetTotalCountForUserAsync(_query, CancellationToken);
	}
}
