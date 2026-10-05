using InstaConnect.Identity.Domain.Features.ForgotPasswordTokens.Models.ValueObjects;
using InstaConnect.Identity.Infrastructure.Tests.Features.ForgotPasswordTokens.Assertions;
using InstaConnect.Identity.Infrastructure.Tests.Integration.Features.ForgotPasswordTokens.Utilities;
using InstaConnect.Identity.Tests.Features.ForgotPasswordTokens.Builders;
using InstaConnect.Identity.Tests.Features.ForgotPasswordTokens.DataAttributes.Value;
using InstaConnect.Identity.Tests.Features.ForgotPasswordTokens.Utilities;
using InstaConnect.Identity.Tests.Features.Users.DataAttributes.Id;
using InstaConnect.Identity.Tests.Features.Users.Utilities;

namespace InstaConnect.Identity.Infrastructure.Tests.Integration.Features.ForgotPasswordTokens.Repositories;

public class ForgotPasswordTokenExistsByIdCommandRepositoryIntegrationTests : BaseForgotPasswordTokenInfrastructureCommandIntegrationTest
{
	private readonly ForgotPasswordTokenIdBuilderFactory _idBuilderFactory;
	private readonly ForgotPasswordTokenIdBuilder _idBuilder;
	private readonly ForgotPasswordTokenId _id;

	public ForgotPasswordTokenExistsByIdCommandRepositoryIntegrationTests(IdentityWebApplicationFactory webApplicationFactory)
		: base(webApplicationFactory)
	{
		_idBuilderFactory = new();
		_idBuilder = _idBuilderFactory.Create(ForgotPasswordToken.Id);
		_id = _idBuilder.Build();
	}

	public override async Task InitializeAsync()
	{
		await ServiceScope.AddAsync(User, CancellationToken);
		await ServiceScope.AddAsync(ForgotPasswordToken, CancellationToken);
	}

	[Fact]
	public async Task ExistsByIdAsync_ShouldReturnNull_WhenIdIsInvalid()
	{
		// Arrange
		await ServiceScope.DeleteAsync(ForgotPasswordToken, CancellationToken);

		// Act
		var response = await Repository.ExistsByIdAsync(_id, CancellationToken);
		var forgotPasswordToken = await ServiceScope.GetByIdAsync(_id, CancellationToken);

		// Assert
		response.ShouldSatisfy(_id, forgotPasswordToken);
	}

	[Fact]
	public async Task ExistsByIdAsync_ShouldReturnResponse_WhenCommandIsValid()
	{
		// Act
		var response = await Repository.ExistsByIdAsync(_id, CancellationToken);
		var forgotPasswordToken = await ServiceScope.GetByIdAsync(_id, CancellationToken);

		// Assert
		response.ShouldSatisfy(_id, forgotPasswordToken);
	}

	[Theory]
	[UserIdDifferentCaseData]
	public async Task ExistsByIdAsync_ShouldReturnResponse_WhenCommandAndIdAreValid(
		IStringTransformer transformer)
	{
		// Arrange
		var id = _idBuilder.WithId(transformer).Build();

		// Act
		var response = await Repository.ExistsByIdAsync(id, CancellationToken);
		var forgotPasswordToken = await ServiceScope.GetByIdAsync(_id, CancellationToken);

		// Assert
		response.ShouldSatisfy(id, forgotPasswordToken);
	}

	[Theory]
	[ForgotPasswordTokenValueDifferentCaseData]
	public async Task ExistsByIdAsync_ShouldReturnResponse_WhenCommandAndValueAreValid(
		IStringTransformer transformer)
	{
		// Arrange
		var id = _idBuilder.WithValue(transformer).Build();

		// Act
		var response = await Repository.ExistsByIdAsync(id, CancellationToken);
		var forgotPasswordToken = await ServiceScope.GetByIdAsync(_id, CancellationToken);

		// Assert
		response.ShouldSatisfy(id, forgotPasswordToken);
	}
}
