using InstaConnect.Identity.Application.Features.Common.Extensions;
using InstaConnect.Identity.Tests.Features.Common.Utilities;

namespace InstaConnect.Identity.Application.Tests.Unit.Features.UserClaims.Utilities;

public abstract class BaseUserClaimApplicationCommandUnitTest : BaseUserClaimTest
{
    protected IApplicationMapper Mapper { get; }

    protected IUserClaimCommandService Service { get; }

    protected BaseUserClaimApplicationCommandUnitTest() : base(IdentityMockFactory.CreatePasswordHasher())
    {
        Mapper = MockFactory.CreateMapper(IdentityApplicationReference.Assembly);
        Service = UserClaimMockFactory.CreateCommandService();
    }
}
