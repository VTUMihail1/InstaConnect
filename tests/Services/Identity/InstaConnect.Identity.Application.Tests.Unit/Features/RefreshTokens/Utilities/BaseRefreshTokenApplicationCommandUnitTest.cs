using InstaConnect.Identity.Application.Features.Common.Extensions;
using InstaConnect.Identity.Tests.Features.Common.Utilities;

namespace InstaConnect.Identity.Application.Tests.Unit.Features.RefreshTokens.Utilities;

public abstract class BaseRefreshTokenApplicationCommandUnitTest : BaseRefreshTokenTest
{
    protected IApplicationMapper Mapper { get; }

    protected IRefreshTokenCommandService Service { get; }

    protected BaseRefreshTokenApplicationCommandUnitTest() : base(IdentityMockFactory.CreatePasswordHasher())
    {
        Mapper = MockFactory.CreateMapper(IdentityApplicationReference.Assembly);
        Service = RefreshTokenMockFactory.CreateCommandService();
    }
}
