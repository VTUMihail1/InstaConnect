using InstaConnect.Identity.Application.Features.Common.Extensions;
using InstaConnect.Identity.Tests.Features.Common.Utilities;

namespace InstaConnect.Identity.Application.Tests.Unit.Features.Users.Utilities;

public abstract class BaseUserApplicationQueryUnitTest : BaseUserTest
{
    protected IApplicationMapper Mapper { get; }

    protected IUserQueryService Service { get; }

    protected BaseUserApplicationQueryUnitTest() : base(IdentityMockFactory.CreatePasswordHasher())
    {
        Mapper = MockFactory.CreateMapper(IdentityApplicationReference.Assembly);
        Service = UserMockFactory.CreateQueryService();
    }
}
