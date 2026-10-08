using InstaConnect.Identity.Domain.Features.EmailConfirmationTokens.Models.Requests;
using InstaConnect.Identity.Domain.Features.EmailConfirmationTokens.Models.ValueObjects;
using InstaConnect.Identity.Infrastructure.Features.EmailConfirmationTokens.Helpers.Repositories;
using InstaConnect.Identity.Infrastructure.Tests.Features.EmailConfirmationTokens.Assertions;
using InstaConnect.Identity.Infrastructure.Tests.Features.EmailConfirmationTokens.Utilities;
using InstaConnect.Identity.Infrastructure.Tests.Unit.Features.EmailConfirmationTokens.Utilities;
using InstaConnect.Identity.Tests.Features.EmailConfirmationTokens.Builders;

namespace InstaConnect.Identity.Infrastructure.Tests.Unit.Features.EmailConfirmationTokens.Repositories;

public class GetEmailConfirmationTokenByIdCommandRepositoryUnitTests : BaseEmailConfirmationTokenInfrastructureCommandUnitTest
{
	private readonly EmailConfirmationTokenIdBuilderFactory _idBuilderFactory;
	private readonly EmailConfirmationTokenIdBuilder _idBuilder;
	private readonly EmailConfirmationTokenId _id;

	private readonly EmailConfirmationTokenInclude _include;

	private readonly EmailConfirmationTokenCommandRepository _repository;

	public GetEmailConfirmationTokenByIdCommandRepositoryUnitTests()
	{
		_idBuilderFactory = new();
		_idBuilder = _idBuilderFactory.Create(EmailConfirmationToken.Id);
		_id = _idBuilder.Build();

		_include = IncludeBuilderFactory.Create().WithUser().Build();

		_repository = new(Collection, IncludeBuilderFactory);

		Collection.SetupAggregateFluent(_id, Fluent);
		Fluent.SetupApplyIncludes(_id, _include);
		Fluent.SetupMatch(_id);
		Fluent.SetupFirstOrDefaultAsync(_id, EmailConfirmationToken, CancellationToken);
	}

	[Fact]
	public async Task GetByIdAsync_ShouldReturnResponse_WhenRequestIsValid()
	{
		// Act
		var response = await _repository.GetByIdAsync(_id, _include, CancellationToken);

		// Assert
		response.ShouldSatisfy(_id, EmailConfirmationToken);
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
