using InstaConnect.Follows.Application.Extensions;

namespace InstaConnect.Follows.Application.Tests.Unit.Features.Follows.Utilities;

public abstract class BaseFollowApplicationQueryUnitTest : BaseFollowTest
{
    protected IApplicationMapper Mapper { get; }

    protected IFollowQueryService Service { get; }

    protected BaseFollowApplicationQueryUnitTest()
    {
        Mapper = MockFactory.CreateMapper(FollowApplicationReference.Assembly);
        Service = FollowMockFactory.CreateQueryService();
    }
}
