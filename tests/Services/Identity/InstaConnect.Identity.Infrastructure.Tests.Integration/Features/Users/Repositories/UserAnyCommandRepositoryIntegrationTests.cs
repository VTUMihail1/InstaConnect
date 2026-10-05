using InstaConnect.Identity.Infrastructure.Tests.Features.Users.Assertions;
using InstaConnect.Identity.Infrastructure.Tests.Integration.Features.Users.Utilities;
using InstaConnect.Identity.Tests.Features.Users.Utilities;

namespace InstaConnect.Identity.Infrastructure.Tests.Integration.Features.Users.Repositories;

public class UserAnyCommandRepositoryIntegrationTests : BaseUserInfrastructureCommandIntegrationTest
{
	public UserAnyCommandRepositoryIntegrationTests(IdentityWebApplicationFactory webApplicationFactory)
		: base(webApplicationFactory)
	{
	}

	public override async Task InitializeAsync()
	{
		await ServiceScope.AddAsync(User, CancellationToken);
	}

	[Fact]
	public async Task AnyAsync_ShouldReturnResponse_WhenCommandIsValid()
	{
		// Act
		var response = await Repository.AnyAsync(CancellationToken);

		// Assert
		response.ShouldSatisfy();
	}
}
