using InstaConnect.Identity.Infrastructure.Features.UserClaims.Abstractions;
using InstaConnect.Identity.Infrastructure.Tests.Features.UserClaims.Utilities;
using InstaConnect.Identity.Tests.Features.UserClaims.Utilities;

namespace InstaConnect.Identity.Infrastructure.Tests.Unit.Features.UserClaims.Utilities;

public abstract class BaseUserClaimInfrastructureQueryUnitTest : BaseUserClaimTest
{
	protected IUserClaimFluent Fluent { get; }

	protected IUserClaimCollection Collection { get; }

	protected IUserClaimResponseFluent ResponseFluent { get; }

	protected BaseUserClaimInfrastructureQueryUnitTest() : base(IdentityMockFactory.CreatePasswordHasher())
	{
		Collection = UserClaimInfrastructureMockFactory.CreateCollection();
		Fluent = UserClaimInfrastructureMockFactory.CreateFluent();
		ResponseFluent = UserClaimInfrastructureMockFactory.CreateResponseFluent();

		PasswordHasher.ClearCalls();
	}
}
