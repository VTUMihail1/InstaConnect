using InstaConnect.Identity.Domain.Features.RefreshTokens.Models.Requests;
using InstaConnect.Identity.Domain.Features.RefreshTokens.Models.ValueObjects;
using InstaConnect.Identity.Infrastructure.Features.RefreshTokens.Helpers.Repositories;
using InstaConnect.Identity.Infrastructure.Tests.Features.RefreshTokens.Assertions;
using InstaConnect.Identity.Infrastructure.Tests.Features.RefreshTokens.Utilities;
using InstaConnect.Identity.Infrastructure.Tests.Unit.Features.RefreshTokens.Utilities;
using InstaConnect.Identity.Tests.Features.RefreshTokens.Builders;

namespace InstaConnect.Identity.Infrastructure.Tests.Unit.Features.RefreshTokens.Repositories;

public class GetRefreshTokenByIdCommandRepositoryUnitTests : BaseRefreshTokenInfrastructureCommandUnitTest
{
	private readonly RefreshTokenIdBuilderFactory _idBuilderFactory;
	private readonly RefreshTokenIdBuilder _idBuilder;
	private readonly RefreshTokenId _id;

	private readonly RefreshTokenInclude _include;

	private readonly RefreshTokenCommandRepository _repository;

	public GetRefreshTokenByIdCommandRepositoryUnitTests()
	{
		_idBuilderFactory = new();
		_idBuilder = _idBuilderFactory.Create(RefreshToken.Id);
		_id = _idBuilder.Build();

		_include = IncludeBuilderFactory.Create().WithUser().Build();

		_repository = new(Collection, IncludeBuilderFactory);

		Collection.SetupAggregateFluent(_id, Fluent);
		Fluent.SetupApplyIncludes(_id, _include);
		Fluent.SetupMatch(_id);
		Fluent.SetupFirstOrDefaultAsync(_id, RefreshToken, CancellationToken);
	}

	[Fact]
	public async Task GetByIdAsync_ShouldReturnResponse_WhenRequestIsValid()
	{
		// Act
		var response = await _repository.GetByIdAsync(_id, _include, CancellationToken);

		// Assert
		response.ShouldSatisfy(_id, RefreshToken);
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
