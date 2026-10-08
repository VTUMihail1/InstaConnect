using InstaConnect.Identity.Domain.Features.UserClaims.Models.Requests;
using InstaConnect.Identity.Domain.Features.UserClaims.Models.ValueObjects;
using InstaConnect.Identity.Infrastructure.Features.UserClaims.Helpers.Repositories;
using InstaConnect.Identity.Infrastructure.Tests.Features.UserClaims.Assertions;
using InstaConnect.Identity.Infrastructure.Tests.Features.UserClaims.Utilities;
using InstaConnect.Identity.Infrastructure.Tests.Unit.Features.UserClaims.Utilities;
using InstaConnect.Identity.Tests.Features.UserClaims.Builders;

namespace InstaConnect.Identity.Infrastructure.Tests.Unit.Features.UserClaims.Repositories;

public class GetUserClaimByIdCommandRepositoryUnitTests : BaseUserClaimInfrastructureCommandUnitTest
{
	private readonly UserClaimIdBuilderFactory _idBuilderFactory;
	private readonly UserClaimIdBuilder _idBuilder;
	private readonly UserClaimId _id;

	private readonly UserClaimInclude _include;

	private readonly UserClaimCommandRepository _repository;

	public GetUserClaimByIdCommandRepositoryUnitTests()
	{
		_idBuilderFactory = new();
		_idBuilder = _idBuilderFactory.Create(UserClaim.Id);
		_id = _idBuilder.Build();

		_include = IncludeBuilderFactory.Create().WithUser().Build();

		_repository = new(Collection, IncludeBuilderFactory);

		Collection.SetupAggregateFluent(_id, Fluent);
		Fluent.SetupApplyIncludes(_id, _include);
		Fluent.SetupMatch(_id);
		Fluent.SetupFirstOrDefaultAsync(_id, UserClaim, CancellationToken);
	}

	[Fact]
	public async Task GetByIdAsync_ShouldReturnResponse_WhenRequestIsValid()
	{
		// Act
		var response = await _repository.GetByIdAsync(_id, _include, CancellationToken);

		// Assert
		response.ShouldSatisfy(_id, UserClaim);
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
