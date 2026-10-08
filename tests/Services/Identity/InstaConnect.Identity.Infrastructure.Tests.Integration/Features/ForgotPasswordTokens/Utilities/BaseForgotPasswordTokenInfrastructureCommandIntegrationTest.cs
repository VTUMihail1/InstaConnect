using InstaConnect.Identity.Domain.Features.ForgotPasswordTokens.Abstractions;
using InstaConnect.Identity.Tests.Features.ForgotPasswordTokens.Utilities;
using InstaConnect.Identity.Tests.Features.UserClaims.Utilities;
using InstaConnect.Identity.Tests.Features.Users.Utilities;

namespace InstaConnect.Identity.Infrastructure.Tests.Integration.Features.ForgotPasswordTokens.Utilities;

public abstract class BaseForgotPasswordTokenInfrastructureCommandIntegrationTest : BaseForgotPasswordTokenWebTest
{
	protected IForgotPasswordTokenCommandRepository Repository { get; }

	protected IForgotPasswordTokenIncludeBuilderFactory IncludeBuilderFactory { get; }

	protected BaseForgotPasswordTokenInfrastructureCommandIntegrationTest(IdentityWebApplicationFactory webApplicationFactory)
		: base(webApplicationFactory)
	{
		Repository = ServiceScope.GetForgotPasswordTokenCommandRepository();
		IncludeBuilderFactory = ServiceScope.GetForgotPasswordTokenIncludeBuilderFactory();
	}

	public override async Task InitializeAsync()
	{
		await ServiceScope.AddAsync(User, CancellationToken);
		await ServiceScope.AddAsync(UserClaim, CancellationToken);
		await OnInitializeAsync();
	}
}
