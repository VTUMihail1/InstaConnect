using InstaConnect.Identity.Application.Extensions;

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
