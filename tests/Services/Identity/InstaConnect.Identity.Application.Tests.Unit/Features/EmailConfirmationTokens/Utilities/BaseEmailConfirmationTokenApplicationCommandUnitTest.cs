using InstaConnect.Common.Domain.Features.Mappers.Abstractions;
using InstaConnect.Identity.Application.Features.Common.Extensions;

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
