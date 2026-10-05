using InstaConnect.Identity.Domain.Features.EmailConfirmationTokens.Models.Requests;
using InstaConnect.Identity.Domain.Features.EmailConfirmationTokens.Models.ValueObjects;
using InstaConnect.Identity.Infrastructure.Tests.Features.EmailConfirmationTokens.Assertions;
using InstaConnect.Identity.Infrastructure.Tests.Integration.Features.EmailConfirmationTokens.Utilities;
using InstaConnect.Identity.Tests.Features.EmailConfirmationTokens.Builders;
using InstaConnect.Identity.Tests.Features.EmailConfirmationTokens.DataAttributes.Value;
using InstaConnect.Identity.Tests.Features.EmailConfirmationTokens.Utilities;
using InstaConnect.Identity.Tests.Features.Users.DataAttributes.Id;
using InstaConnect.Identity.Tests.Features.Users.Utilities;

namespace InstaConnect.Identity.Infrastructure.Tests.Integration.Features.EmailConfirmationTokens.Repositories;

public class GetEmailConfirmationTokenByIdCommandRepositoryIntegrationTests : BaseEmailConfirmationTokenInfrastructureCommandIntegrationTest
{
	private readonly EmailConfirmationTokenIdBuilderFactory _idBuilderFactory;
	private readonly EmailConfirmationTokenIdBuilder _idBuilder;
	private readonly EmailConfirmationTokenId _id;

	private readonly EmailConfirmationTokenInclude _include;

	public GetEmailConfirmationTokenByIdCommandRepositoryIntegrationTests(IdentityWebApplicationFactory webApplicationFactory)
		: base(webApplicationFactory)
	{
		_idBuilderFactory = new();
		_idBuilder = _idBuilderFactory.Create(EmailConfirmationToken.Id);
		_id = _idBuilder.Build();

		_include = IncludeBuilderFactory.Create().WithUser().Build();
	}

	public override async Task InitializeAsync()
	{
		await ServiceScope.AddAsync(User, CancellationToken);
		await ServiceScope.AddAsync(EmailConfirmationToken, CancellationToken);
	}

	[Fact]
	public async Task GetByIdAsync_ShouldReturnNull_WhenIdIsInvalid()
	{
		// Arrange
		await ServiceScope.DeleteAsync(EmailConfirmationToken, CancellationToken);

		// Act
		var response = await Repository.GetByIdAsync(_id, _include, CancellationToken);

		// Assert
		response.ShouldBeNull();
	}

	[Fact]
	public async Task GetByIdAsync_ShouldReturnResponse_WhenCommandIsValid()
	{
		// Act
		var response = await Repository.GetByIdAsync(_id, _include, CancellationToken);

		// Assert
		response.ShouldSatisfy(_id, EmailConfirmationToken);
	}

	[Theory]
	[UserIdDifferentCaseData]
	public async Task GetByIdAsync_ShouldReturnResponse_WhenCommandAndIdAreValid(
		IStringTransformer transformer)
	{
		// Arrange
		var id = _idBuilder.WithId(transformer).Build();

		// Act
		var response = await Repository.GetByIdAsync(id, _include, CancellationToken);

		// Assert
		response.ShouldSatisfy(id, EmailConfirmationToken);
	}

	[Theory]
	[EmailConfirmationTokenValueDifferentCaseData]
	public async Task GetByIdAsync_ShouldReturnResponse_WhenCommandAndValueAreValid(
		IStringTransformer transformer)
	{
		// Arrange
		var id = _idBuilder.WithValue(transformer).Build();

		// Act
		var response = await Repository.GetByIdAsync(id, _include, CancellationToken);

		// Assert
		response.ShouldSatisfy(id, EmailConfirmationToken);
	}
}
