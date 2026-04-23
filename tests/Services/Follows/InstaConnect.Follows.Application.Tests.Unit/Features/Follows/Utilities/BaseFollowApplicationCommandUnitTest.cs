using InstaConnect.Follows.Application.Features.Common.Extensions;

namespace InstaConnect.Follows.Application.Tests.Unit.Features.Follows.Utilities;

public abstract class BaseFollowApplicationCommandUnitTest : BaseFollowTest
{
    protected IApplicationMapper Mapper { get; }

    protected IFollowCommandService Service { get; }

    protected BaseFollowApplicationCommandUnitTest()
    {
        Mapper = MockFactory.CreateMapper(FollowsApplicationReference.Assembly);
        Service = FollowMockFactory.CreateCommandService();
    }
}
