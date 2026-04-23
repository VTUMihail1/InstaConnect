using InstaConnect.Identity.Application.Features.Common.Extensions;
using InstaConnect.Identity.Tests.Features.Common.Utilities;

namespace InstaConnect.Identity.Application.Tests.Unit.Features.UserClaims.Utilities;

public abstract class BaseUserClaimApplicationQueryUnitTest : BaseUserClaimTest
{
    protected IApplicationMapper Mapper { get; }

    protected IUserClaimQueryService Service { get; }

    protected BaseUserClaimApplicationQueryUnitTest() : base(IdentityMockFactory.CreatePasswordHasher())
    {
        Mapper = MockFactory.CreateMapper(IdentityApplicationReference.Assembly);
        Service = UserClaimMockFactory.CreateQueryService();
    }
}
