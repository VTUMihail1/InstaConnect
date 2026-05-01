using InstaConnect.Common.Application.Features.Messaging.Abstractions;
using InstaConnect.Common.Domain.Features.Mappers.Abstractions;
using InstaConnect.Identity.Presentation.Features.Common.Extensions;

namespace InstaConnect.Identity.Presentation.Tests.Unit.Features.Users.Utilities;

public abstract class BaseUserPresentationCommandUnitTest : BaseUserTest
{
	protected IApplicationSender Sender { get; }

	protected IApplicationMapper Mapper { get; }

	protected BaseUserPresentationCommandUnitTest() : base(IdentityMockFactory.CreatePasswordHasher())
	{
		Sender = MockFactory.CreateApplicationSender();
		Mapper = MockFactory.CreateMapper(IdentityPresentationReference.Assembly);
	}
}
