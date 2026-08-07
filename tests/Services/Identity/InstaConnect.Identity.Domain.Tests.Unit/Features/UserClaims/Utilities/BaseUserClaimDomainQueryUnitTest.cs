using InstaConnect.Identity.Domain.Features.UserClaims.Abstractions;
using InstaConnect.Identity.Domain.Features.Users.Abstractions;
using InstaConnect.Identity.Domain.Tests.Features.UserClaims.Utilities;
using InstaConnect.Identity.Domain.Tests.Features.Users.Utilities;
using InstaConnect.Identity.Tests.Features.UserClaims.Utilities;

namespace InstaConnect.Identity.Domain.Tests.Unit.Features.UserClaims.Utilities;

public abstract class BaseUserClaimDomainQueryUnitTest : BaseUserClaimTest
{
	protected IUserQueryRepository Repository { get; }

	protected IUserClaimQueryRepository ClaimRepository { get; }

	protected IUserClaimCollectionResponseFactory CollectionResponseFactory { get; }

	protected BaseUserClaimDomainQueryUnitTest() : base(UserDomainMockFactory.CreatePasswordHasher())
	{
		Repository = UserDomainMockFactory.CreateQueryRepository();
		ClaimRepository = UserClaimDomainMockFactory.CreateQueryRepository();
		CollectionResponseFactory = UserClaimDomainMockFactory.CreateCollectionResponseFactory();
	}
}
