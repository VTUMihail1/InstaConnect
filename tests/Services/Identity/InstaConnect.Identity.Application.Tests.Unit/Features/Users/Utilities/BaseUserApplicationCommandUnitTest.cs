using InstaConnect.Identity.Application.Features.Common.Extensions;
using InstaConnect.Identity.Tests.Features.Common.Utilities;

namespace InstaConnect.Identity.Application.Tests.Unit.Features.Users.Utilities;

public abstract class BaseUserApplicationCommandUnitTest : BaseUserTest
{
    protected IApplicationMapper Mapper { get; }

    protected IUserCommandService Service { get; }

    protected BaseUserApplicationCommandUnitTest() : base(IdentityMockFactory.CreatePasswordHasher())
    {
        Mapper = MockFactory.CreateMapper(IdentityApplicationReference.Assembly);
        Service = UserMockFactory.CreateCommandService();
    }
}
