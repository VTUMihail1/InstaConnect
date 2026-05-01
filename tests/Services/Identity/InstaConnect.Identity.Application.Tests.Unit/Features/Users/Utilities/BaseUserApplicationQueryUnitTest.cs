using InstaConnect.Common.Domain.Features.Mappers.Abstractions;
using InstaConnect.Identity.Application.Features.Common.Extensions;

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
