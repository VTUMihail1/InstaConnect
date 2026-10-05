using InstaConnect.Identity.Infrastructure.Tests.Integration.Features.ForgotPasswordTokens.Utilities;
using InstaConnect.Identity.Tests.Features.ForgotPasswordTokens.Assertions;
using InstaConnect.Identity.Tests.Features.ForgotPasswordTokens.Utilities;
using InstaConnect.Identity.Tests.Features.Users.Utilities;

namespace InstaConnect.Identity.Infrastructure.Tests.Integration.Features.ForgotPasswordTokens.Repositories;

public class UpdateForgotPasswordTokenCommandRepositoryIntegrationTests : BaseForgotPasswordTokenInfrastructureCommandIntegrationTest
{
	public UpdateForgotPasswordTokenCommandRepositoryIntegrationTests(IdentityWebApplicationFactory webApplicationFactory)
		: base(webApplicationFactory)
	{
	}

	public override async Task InitializeAsync()
	{
		await ServiceScope.AddAsync(User, CancellationToken);
		await ServiceScope.AddAsync(ForgotPasswordToken, CancellationToken);
	}

	[Fact]
	public async Task UpdateAsync_ShouldUpdateForgotPasswordToken_WhenCommandIsValid()
	{
		// Arrange
		var updatedForgotPasswordToken = ForgotPasswordTokenBuilder.WithAlreadyExpiresAtUtc().Build();

		// Act
		await Repository.UpdateAsync(updatedForgotPasswordToken, CancellationToken);
		var forgotPasswordToken = await ServiceScope.GetByIdAsync(ForgotPasswordToken.Id, CancellationToken);

		// Assert
		forgotPasswordToken.ShouldSatisfy(updatedForgotPasswordToken);
	}
}
