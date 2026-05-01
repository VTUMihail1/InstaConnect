using InstaConnect.Common.Domain.Features.Mappers.Abstractions;
using InstaConnect.Follows.Application.Features.Common.Extensions;

namespace InstaConnect.Follows.Application.Tests.Unit.Features.Follows.Utilities;

public abstract class BaseFollowApplicationQueryUnitTest : BaseFollowTest
{
	protected IApplicationMapper Mapper { get; }

	protected IFollowQueryService Service { get; }

	protected BaseFollowApplicationQueryUnitTest()
	{
		Mapper = MockFactory.CreateMapper(FollowsApplicationReference.Assembly);
		Service = FollowMockFactory.CreateQueryService();
	}
}
