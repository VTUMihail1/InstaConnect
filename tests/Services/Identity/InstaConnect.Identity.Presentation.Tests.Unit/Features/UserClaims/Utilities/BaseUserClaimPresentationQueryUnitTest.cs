using InstaConnect.Common.Application.Features.Messaging.Abstractions;
using InstaConnect.Common.Domain.Features.Mappers.Abstractions;
using InstaConnect.Identity.Presentation.Features.Common.Extensions;

namespace InstaConnect.Identity.Presentation.Tests.Unit.Features.UserClaims.Utilities;

public abstract class BaseUserClaimPresentationQueryUnitTest : BaseUserClaimTest
{
	protected IApplicationSender Sender { get; }

	protected IApplicationMapper Mapper { get; }

	protected BaseUserClaimPresentationQueryUnitTest() : base(IdentityMockFactory.CreatePasswordHasher())
	{
		Sender = MockFactory.CreateApplicationSender();
		Mapper = MockFactory.CreateMapper(IdentityPresentationReference.Assembly);
	}
}
