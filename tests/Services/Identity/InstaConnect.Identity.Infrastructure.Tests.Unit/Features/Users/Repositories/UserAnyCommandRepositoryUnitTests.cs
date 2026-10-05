using InstaConnect.Identity.Infrastructure.Features.Users.Helpers.Repositories;
using InstaConnect.Identity.Infrastructure.Tests.Features.Users.Assertions;
using InstaConnect.Identity.Infrastructure.Tests.Features.Users.Utilities;
using InstaConnect.Identity.Infrastructure.Tests.Unit.Features.Users.Utilities;

namespace InstaConnect.Identity.Infrastructure.Tests.Unit.Features.Users.Repositories;

public class UserAnyCommandRepositoryUnitTests : BaseUserInfrastructureCommandUnitTest
{
	private readonly UserCommandRepository _repository;

	public UserAnyCommandRepositoryUnitTests()
	{
		_repository = new(Collection, IncludeBuilderFactory);

		Collection.SetupAggregateFluent(Fluent);
		Fluent.SetupAnyAsync(CancellationToken);
	}

	[Fact]
	public async Task AnyAsync_ShouldReturnResponse_WhenRequestIsValid()
	{
		// Act
		var response = await _repository.AnyAsync(CancellationToken);

		// Assert
		response.ShouldSatisfy();
	}

	[Fact]
	public async Task AnyAsync_ShouldCallTheCollectionAggregateFluent_WhenRequestIsValid()
	{
		// Act
		await _repository.AnyAsync(CancellationToken);

		// Assert
		Collection.ShouldHaveReceivedOneAggregateFluent();
	}

	[Fact]
	public async Task AnyAsync_ShouldCallTheFluentAnyAsync_WhenRequestIsValid()
	{
		// Act
		await _repository.AnyAsync(CancellationToken);

		// Assert
		await Fluent.ShouldHaveReceivedOneAnyAsync(CancellationToken);
	}
}
