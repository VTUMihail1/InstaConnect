using InstaConnect.Identity.Domain.Features.Users.Models.ValueObjects;
using InstaConnect.Identity.Infrastructure.Features.Users.Helpers.Repositories;
using InstaConnect.Identity.Infrastructure.Tests.Features.Users.Assertions;
using InstaConnect.Identity.Infrastructure.Tests.Features.Users.Utilities;
using InstaConnect.Identity.Infrastructure.Tests.Unit.Features.Users.Utilities;
using InstaConnect.Identity.Tests.Features.Users.Builders;

namespace InstaConnect.Identity.Infrastructure.Tests.Unit.Features.Users.Repositories;

public class UserExistsByIdQueryRepositoryUnitTests : BaseUserInfrastructureQueryUnitTest
{
	private readonly UserIdBuilderFactory _idBuilderFactory;
	private readonly UserIdBuilder _idBuilder;
	private readonly UserId _id;

	private readonly UserQueryRepository _repository;

	public UserExistsByIdQueryRepositoryUnitTests()
	{
		_idBuilderFactory = new();
		_idBuilder = _idBuilderFactory.Create(User.Id);
		_id = _idBuilder.Build();

		_repository = new(Collection);

		Collection.SetupAggregateFluent(_id, Fluent);
		Fluent.SetupMatch(_id);
		Fluent.SetupAnyAsync(_id, User, CancellationToken);
	}

	[Fact]
	public async Task ExistsByIdAsync_ShouldReturnResponse_WhenRequestIsValid()
	{
		// Act
		var response = await _repository.ExistsByIdAsync(_id, CancellationToken);

		// Assert
		response.ShouldSatisfy(_id, User);
	}

	[Fact]
	public async Task ExistsByIdAsync_ShouldCallTheCollectionAggregateFluent_WhenRequestIsValid()
	{
		// Act
		await _repository.ExistsByIdAsync(_id, CancellationToken);

		// Assert
		Collection.ShouldHaveReceivedOneAggregateFluent(_id);
	}

	[Fact]
	public async Task ExistsByIdAsync_ShouldCallTheFluentMatch_WhenRequestIsValid()
	{
		// Act
		await _repository.ExistsByIdAsync(_id, CancellationToken);

		// Assert
		Fluent.ShouldHaveReceivedOneMatch(_id);
	}

	[Fact]
	public async Task ExistsByIdAsync_ShouldCallTheFluentAnyAsync_WhenRequestIsValid()
	{
		// Act
		await _repository.ExistsByIdAsync(_id, CancellationToken);

		// Assert
		await Fluent.ShouldHaveReceivedOneAnyAsync(_id, CancellationToken);
	}
}
