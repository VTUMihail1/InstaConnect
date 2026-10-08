using InstaConnect.Follows.Domain.Features.Users.Models.Requests;
using InstaConnect.Follows.Domain.Features.Users.Models.ValueObjects;
using InstaConnect.Follows.Infrastructure.Features.Users.Helpers.Repositories;

namespace InstaConnect.Follows.Infrastructure.Tests.Unit.Features.Users.Repositories;

public class GetUserByIdCommandRepositoryUnitTests : BaseUserInfrastructureCommandUnitTest
{
	private readonly UserIdBuilderFactory _idBuilderFactory;
	private readonly UserIdBuilder _idBuilder;
	private readonly UserId _id;

	private readonly UserInclude _include;

	private readonly UserCommandRepository _repository;

	public GetUserByIdCommandRepositoryUnitTests()
	{
		_idBuilderFactory = new();
		_idBuilder = _idBuilderFactory.Create(User.Id);
		_id = _idBuilder.Build();

		_include = IncludeBuilderFactory.Create().WithFollowers().WithFollowings().Build();

		_repository = new(Collection, IncludeBuilderFactory);

		Collection.SetupAggregateFluent(_id, Fluent);
		Fluent.SetupApplyIncludes(_id, _include);
		Fluent.SetupMatch(_id);
		Fluent.SetupFirstOrDefaultAsync(_id, User, CancellationToken);
	}

	[Fact]
	public async Task GetByIdAsync_ShouldReturnResponse_WhenRequestIsValid()
	{
		// Act
		var response = await _repository.GetByIdAsync(_id, _include, CancellationToken);

		// Assert
		response.ShouldSatisfy(_id, User);
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
