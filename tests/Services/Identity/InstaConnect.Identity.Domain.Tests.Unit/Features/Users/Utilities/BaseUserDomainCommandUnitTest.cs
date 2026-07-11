using InstaConnect.Common.Domain.Features.DateTimes.Abstractions;
using InstaConnect.Common.Domain.Features.Guids.Abstractions;
using InstaConnect.Common.Domain.Features.Images.Abstractions;
using InstaConnect.Common.Domain.Features.Mappers.Abstractions;
using InstaConnect.Common.Domain.Tests.Features.Utilities;
using InstaConnect.Common.Events.Features.Common.Abstractions;
using InstaConnect.Identity.Domain.Features.Common.Extensions;
using InstaConnect.Identity.Domain.Features.EmailConfirmationTokens.Abstractions;
using InstaConnect.Identity.Domain.Features.Users.Abstractions;
using InstaConnect.Identity.Domain.Tests.Features.EmailConfirmationTokens.Utilities;
using InstaConnect.Identity.Domain.Tests.Features.Users.Utilities;
using InstaConnect.Identity.Tests.Features.Users.Utilities;

namespace InstaConnect.Identity.Domain.Tests.Unit.Features.Users.Utilities;

public abstract class BaseUserDomainCommandUnitTest : BaseUserTest
{
	protected IUserFactory Factory { get; }

	protected IApplicationMapper Mapper { get; }

	protected IGuidProvider GuidProvider { get; }

	protected IImageHandler ImageHandler { get; }

	protected IEventPublisher EventPublisher { get; }

	protected IUserCommandRepository Repository { get; }

	protected IDateTimeProvider DateTimeProvider { get; }

	protected IUserIncludeBuilderFactory IncludeBuilderFactory { get; }

	protected IEmailConfirmationTokenFactory EmailConfirmationTokenFactory { get; }

	protected IEmailConfirmationTokenEmailSender EmailConfirmationTokenEmailSender { get; }

	protected IEmailConfirmationTokenCommandRepository EmailConfirmationTokenRepository { get; }

	protected BaseUserDomainCommandUnitTest() : base(UserDomainMockFactory.CreatePasswordHasher())
	{
		Factory = UserDomainMockFactory.CreateFactory();
		Mapper = MockFactory.CreateMapper(IdentityDomainReference.Assembly);
		GuidProvider = DomainMockFactory.CreateGuidProvider();
		ImageHandler = DomainMockFactory.CreateImageHandler();
		EventPublisher = DomainMockFactory.CreateEventPublisher();
		Repository = UserDomainMockFactory.CreateCommandRepository();
		DateTimeProvider = DomainMockFactory.CreateDateTimeProvider();
		IncludeBuilderFactory = UserDomainMockFactory.CreateIncludeBuilderFactory();
		EmailConfirmationTokenFactory = EmailConfirmationTokenDomainMockFactory.CreateFactory();
		EmailConfirmationTokenEmailSender = EmailConfirmationTokenDomainMockFactory.CreateEmailSender();
		EmailConfirmationTokenRepository = EmailConfirmationTokenDomainMockFactory.CreateCommandRepository();
	}
}
