using InstaConnect.Identity.Application.Features.Common.Extensions;
using InstaConnect.Identity.Tests.Features.Common.Utilities;

namespace InstaConnect.Identity.Application.Tests.Unit.Features.EmailConfirmationTokens.Utilities;

public abstract class BaseEmailConfirmationTokenApplicationCommandUnitTest : BaseEmailConfirmationTokenTest
{
    protected IApplicationMapper Mapper { get; }

    protected IEmailConfirmationTokenCommandService Service { get; }

    protected BaseEmailConfirmationTokenApplicationCommandUnitTest() : base(IdentityMockFactory.CreatePasswordHasher())
    {
        Mapper = MockFactory.CreateMapper(IdentityApplicationReference.Assembly);
        Service = EmailConfirmationTokenMockFactory.CreateCommandService();
    }
}
