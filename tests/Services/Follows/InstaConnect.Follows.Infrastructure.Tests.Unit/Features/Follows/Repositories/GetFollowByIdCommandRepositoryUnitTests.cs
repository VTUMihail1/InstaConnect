using InstaConnect.Follows.Domain.Features.Follows.Models.Requests;
using InstaConnect.Follows.Domain.Features.Follows.Models.ValueObjects;
using InstaConnect.Follows.Infrastructure.Features.Follows.Helpers.Repositories;
using InstaConnect.Follows.Infrastructure.Tests.Features.Follows.Assertions;
using InstaConnect.Follows.Infrastructure.Tests.Features.Follows.Utilities;
using InstaConnect.Follows.Infrastructure.Tests.Unit.Features.Follows.Utilities;
using InstaConnect.Follows.Tests.Features.Follows.Builders;

namespace InstaConnect.Follows.Infrastructure.Tests.Unit.Features.Follows.Repositories;

public class GetFollowByIdCommandRepositoryUnitTests : BaseFollowInfrastructureCommandUnitTest
{
	private readonly FollowIdBuilderFactory _idBuilderFactory;
	private readonly FollowIdBuilder _idBuilder;
	private readonly FollowId _id;

	private readonly FollowInclude _include;

	private readonly FollowCommandRepository _repository;

	public GetFollowByIdCommandRepositoryUnitTests()
	{
		_idBuilderFactory = new();
		_idBuilder = _idBuilderFactory.Create(Follow.Id);
		_id = _idBuilder.Build();

		_include = IncludeBuilderFactory.Create().WithFollower().WithFollowing().Build();

		_repository = new(Collection, IncludeBuilderFactory);

		Collection.SetupAggregateFluent(_id, Fluent);
		Fluent.SetupApplyIncludes(_id, _include);
		Fluent.SetupMatch(_id);
		Fluent.SetupFirstOrDefaultAsync(_id, Follow, CancellationToken);
	}

	[Fact]
	public async Task GetByIdAsync_ShouldReturnResponse_WhenRequestIsValid()
	{
		// Act
		var response = await _repository.GetByIdAsync(_id, _include, CancellationToken);

		// Assert
		response.ShouldSatisfy(_id, Follow);
	}

	[Fact]
	public async Task GetByIdAsync_ShouldCallTheCollectionAggregateFluent_WhenRequestIsValid()
	{
		// Act
		await _repository.GetByIdAsync(_id, _include, CancellationToken);

		// Assert
		Collection.ShouldHaveReceivedOneAggregateFluent(_id);
	}

	[Fact]
	public async Task GetByIdAsync_ShouldCallTheFluentApplyIncludes_WhenRequestIsValid()
	{
		// Act
		await _repository.GetByIdAsync(_id, _include, CancellationToken);

		// Assert
		Fluent.ShouldHaveReceivedOneApplyIncludes(_id, _include);
	}

	[Fact]
	public async Task GetByIdAsync_ShouldCallTheFluentMatch_WhenRequestIsValid()
	{
		// Act
		await _repository.GetByIdAsync(_id, _include, CancellationToken);

		// Assert
		Fluent.ShouldHaveReceivedOneMatch(_id);
	}

	[Fact]
	public async Task GetByIdAsync_ShouldCallTheFluentFirstOrDefaultAsync_WhenRequestIsValid()
	{
		// Act
		await _repository.GetByIdAsync(_id, _include, CancellationToken);

		// Assert
		await Fluent.ShouldHaveReceivedOneFirstOrDefaultAsync(_id, CancellationToken);
	}
}
