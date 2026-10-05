using InstaConnect.Identity.Domain.Features.ForgotPasswordTokens.Models.ValueObjects;
using InstaConnect.Identity.Infrastructure.Features.ForgotPasswordTokens.Helpers.Repositories;
using InstaConnect.Identity.Infrastructure.Tests.Features.ForgotPasswordTokens.Assertions;
using InstaConnect.Identity.Infrastructure.Tests.Features.ForgotPasswordTokens.Utilities;
using InstaConnect.Identity.Infrastructure.Tests.Unit.Features.ForgotPasswordTokens.Utilities;
using InstaConnect.Identity.Tests.Features.ForgotPasswordTokens.Builders;

namespace InstaConnect.Identity.Infrastructure.Tests.Unit.Features.ForgotPasswordTokens.Repositories;

public class ForgotPasswordTokenExistsByIdCommandRepositoryUnitTests : BaseForgotPasswordTokenInfrastructureCommandUnitTest
{
	private readonly ForgotPasswordTokenIdBuilderFactory _idBuilderFactory;
	private readonly ForgotPasswordTokenIdBuilder _idBuilder;
	private readonly ForgotPasswordTokenId _id;

	private readonly ForgotPasswordTokenCommandRepository _repository;

	public ForgotPasswordTokenExistsByIdCommandRepositoryUnitTests()
	{
		_idBuilderFactory = new();
		_idBuilder = _idBuilderFactory.Create(ForgotPasswordToken.Id);
		_id = _idBuilder.Build();

		_repository = new(Collection, IncludeBuilderFactory);

		Collection.SetupAggregateFluent(_id, Fluent);
		Fluent.SetupMatch(_id);
		Fluent.SetupAnyAsync(_id, ForgotPasswordToken, CancellationToken);
	}

	[Fact]
	public async Task ExistsByIdAsync_ShouldReturnResponse_WhenRequestIsValid()
	{
		// Act
		var response = await _repository.ExistsByIdAsync(_id, CancellationToken);

		// Assert
		response.ShouldSatisfy(_id, ForgotPasswordToken);
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
