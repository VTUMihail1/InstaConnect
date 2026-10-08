using InstaConnect.Follows.Domain.Features.Follows.Models.Requests;
using InstaConnect.Follows.Domain.Features.Follows.Models.ValueObjects;
using InstaConnect.Follows.Domain.Features.Users.Models.Requests;
using InstaConnect.Follows.Infrastructure.Features.Follows.Helpers.Repositories;
using InstaConnect.Follows.Infrastructure.Tests.Features.Common.Builders;
using InstaConnect.Follows.Infrastructure.Tests.Features.Follows.Assertions;
using InstaConnect.Follows.Infrastructure.Tests.Features.Follows.Utilities;
using InstaConnect.Follows.Infrastructure.Tests.Unit.Features.Follows.Utilities;
using InstaConnect.Follows.Tests.Features.Follows.Builders;

namespace InstaConnect.Follows.Infrastructure.Tests.Unit.Features.Follows.Repositories;

public class GetFollowByIdQueryRepositoryUnitTests : BaseFollowInfrastructureQueryUnitTest
{
	private readonly FollowIdBuilderFactory _idBuilderFactory;
	private readonly FollowIdBuilder _idBuilder;
	private readonly FollowId _id;

	private readonly CurrentUserQueryBuilderFactory _currentUserQueryBuilderFactory;
	private readonly CurrentUserQueryBuilder _currentUserQueryBuilder;
	private readonly CurrentUserQuery _currentUserQuery;

	private readonly FollowInclude _include;

	private readonly FollowQueryRepository _repository;

	public GetFollowByIdQueryRepositoryUnitTests()
	{
		_idBuilderFactory = new();
		_idBuilder = _idBuilderFactory.Create(Follow.Id);
		_id = _idBuilder.Build();

		_currentUserQueryBuilderFactory = new();
		_currentUserQueryBuilder = _currentUserQueryBuilderFactory.Create(Follower);
		_currentUserQuery = _currentUserQueryBuilder.Build();

		_include = IncludeBuilderFactory.Create().WithFollower().WithFollowing().Build();

		_repository = new(Collection, IncludeBuilderFactory);

		Collection.SetupAggregateFluent(_id, _currentUserQuery, Fluent);
		Fluent.SetupApplyIncludes(_id, _currentUserQuery, _include);
		Fluent.SetupMatch(_id, _currentUserQuery);
		Fluent.SetupProjectToFullResponse(_id, _currentUserQuery, ResponseFluent);
		ResponseFluent.SetupFirstOrDefaultAsync(_id, _currentUserQuery, Follow, CancellationToken);
	}

	[Fact]
	public async Task GetByIdAsync_ShouldReturnResponse_WhenRequestIsValid()
	{
		// Act
		var response = await _repository.GetByIdAsync(_id, _currentUserQuery, CancellationToken);

		// Assert
		response.ShouldSatisfy(_id, _currentUserQuery, Follow);
	}

	[Fact]
	public async Task GetByIdAsync_ShouldCallTheCollectionAggregateFluent_WhenRequestIsValid()
	{
		// Act
		await _repository.GetByIdAsync(_id, _currentUserQuery, CancellationToken);

		// Assert
		Collection.ShouldHaveReceivedOneAggregateFluent(_id, _currentUserQuery);
	}

	[Fact]
	public async Task GetByIdAsync_ShouldCallTheFluentApplyIncludes_WhenRequestIsValid()
	{
		// Act
		await _repository.GetByIdAsync(_id, _currentUserQuery, CancellationToken);

		// Assert
		Fluent.ShouldHaveReceivedOneApplyIncludes(_id, _currentUserQuery, _include);
	}

	[Fact]
	public async Task GetByIdAsync_ShouldCallTheFluentMatch_WhenRequestIsValid()
	{
		// Act
		await _repository.GetByIdAsync(_id, _currentUserQuery, CancellationToken);

		// Assert
		Fluent.ShouldHaveReceivedOneMatch(_id, _currentUserQuery);
	}

	[Fact]
	public async Task GetByIdAsync_ShouldCallTheFluentProjectToFullResponse_WhenRequestIsValid()
	{
		// Act
		await _repository.GetByIdAsync(_id, _currentUserQuery, CancellationToken);

		// Assert
		Fluent.ShouldHaveReceivedOneProjectToFullResponse(_id, _currentUserQuery);
	}

	[Fact]
	public async Task GetByIdAsync_ShouldCallTheFluentResponseFirstOrDefaultAsync_WhenRequestIsValid()
	{
		// Act
		await _repository.GetByIdAsync(_id, _currentUserQuery, CancellationToken);

		// Assert
		await ResponseFluent.ShouldHaveReceivedOneFirstOrDefaultAsync(_id, _currentUserQuery, CancellationToken);
	}
}
