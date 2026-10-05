using InstaConnect.Follows.Domain.Features.Follows.Models.ValueObjects;
using InstaConnect.Follows.Domain.Features.Users.Models.Requests;
using InstaConnect.Follows.Infrastructure.Tests.Features.Common.Builders;
using InstaConnect.Follows.Infrastructure.Tests.Features.Follows.Assertions;
using InstaConnect.Follows.Infrastructure.Tests.Integration.Features.Follows.Utilities;
using InstaConnect.Follows.Tests.Features.Follows.Builders;
using InstaConnect.Follows.Tests.Features.Follows.Utilities;

namespace InstaConnect.Follows.Infrastructure.Tests.Integration.Features.Follows.Repositories;

public class GetFollowByIdQueryRepositoryIntegrationTests : BaseFollowInfrastructureQueryIntegrationTest
{
	private readonly FollowIdBuilderFactory _idBuilderFactory;
	private readonly FollowIdBuilder _idBuilder;
	private readonly FollowId _id;

	private readonly CurrentUserQueryBuilderFactory _currentUserQueryBuilderFactory;
	private readonly CurrentUserQueryBuilder _currentUserQueryBuilder;
	private readonly CurrentUserQuery _currentUserQuery;

	public GetFollowByIdQueryRepositoryIntegrationTests(FollowsWebApplicationFactory webApplicationFactory)
		: base(webApplicationFactory)
	{
		_idBuilderFactory = new();
		_idBuilder = _idBuilderFactory.Create(Follow.Id);
		_id = _idBuilder.Build();

		_currentUserQueryBuilderFactory = new();
		_currentUserQueryBuilder = _currentUserQueryBuilderFactory.Create(Follower);
		_currentUserQuery = _currentUserQueryBuilder.Build();
	}

	public override async Task InitializeAsync()
	{
		await ServiceScope.AddAsync(Follower, CancellationToken);
		await ServiceScope.AddAsync(Following, CancellationToken);
		await ServiceScope.AddAsync(Follow, CancellationToken);
	}

	[Fact]
	public async Task GetByIdAsync_ShouldReturnNull_WhenIdIsInvalid()
	{
		// Arrange
		await ServiceScope.DeleteAsync(Follow, CancellationToken);

		// Act
		var response = await Repository.GetByIdAsync(_id, _currentUserQuery, CancellationToken);

		// Assert
		response.ShouldBeNull();
	}

	[Fact]
	public async Task GetByIdAsync_ShouldReturnResponse_WhenQueryIsValid()
	{
		// Act
		var response = await Repository.GetByIdAsync(_id, _currentUserQuery, CancellationToken);

		// Assert
		response.ShouldSatisfy(_id, _currentUserQuery, Follow);
	}

	[Theory]
	[UserIdDifferentCaseData]
	public async Task GetByIdAsync_ShouldReturnResponse_WhenQueryAndFollowerIdAreValid(
		IStringTransformer transformer)
	{
		// Arrange
		var id = _idBuilder.WithFollowerId(transformer).Build();

		// Act
		var response = await Repository.GetByIdAsync(id, _currentUserQuery, CancellationToken);

		// Assert
		response.ShouldSatisfy(id, _currentUserQuery, Follow);
	}

	[Theory]
	[UserIdDifferentCaseData]
	public async Task GetByIdAsync_ShouldReturnResponse_WhenQueryAndFollowingIdAreValid(
		IStringTransformer transformer)
	{
		// Arrange
		var id = _idBuilder.WithFollowingId(transformer).Build();

		// Act
		var response = await Repository.GetByIdAsync(id, _currentUserQuery, CancellationToken);

		// Assert
		response.ShouldSatisfy(id, _currentUserQuery, Follow);
	}

	[Theory]
	[UserIdNullData]
	[UserIdEmptyData]
	[UserIdDifferentCaseData]
	public async Task GetByIdAsync_ShouldReturnResponse_WhenQueryAndCurrentUserIdAreValid(
		IStringTransformer transformer)
	{
		// Arrange
		var currentUserQuery = _currentUserQueryBuilder.WithCurrentUserId(transformer).Build();

		// Act
		var response = await Repository.GetByIdAsync(_id, currentUserQuery, CancellationToken);

		// Assert
		response.ShouldSatisfy(_id, currentUserQuery, Follow);
	}
}
