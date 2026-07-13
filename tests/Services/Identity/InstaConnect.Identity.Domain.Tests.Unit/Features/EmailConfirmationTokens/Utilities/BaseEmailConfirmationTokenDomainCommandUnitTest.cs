using InstaConnect.Common.Domain.Features.DateTimes.Abstractions;
using InstaConnect.Common.Domain.Features.Guids.Abstractions;
using InstaConnect.Common.Domain.Features.Mappers.Abstractions;
using InstaConnect.Common.Domain.Tests.Features.Utilities;
using InstaConnect.Common.Events.Features.Common.Abstractions;
using InstaConnect.Identity.Domain.Features.Common.Extensions;
using InstaConnect.Identity.Domain.Features.EmailConfirmationTokens.Abstractions;
using InstaConnect.Identity.Domain.Features.EmailConfirmationTokens.Models.Options;
using InstaConnect.Identity.Domain.Features.Users.Abstractions;
using InstaConnect.Identity.Domain.Tests.Features.EmailConfirmationTokens.Utilities;
using InstaConnect.Identity.Domain.Tests.Features.Users.Utilities;
using InstaConnect.Identity.Tests.Features.EmailConfirmationTokens.Utilities;

using Microsoft.Extensions.Options;

namespace InstaConnect.Identity.Domain.Tests.Unit.Features.EmailConfirmationTokens.Utilities;

public abstract class BaseEmailConfirmationTokenDomainCommandUnitTest : BaseEmailConfirmationTokenTest
{
	protected IApplicationMapper Mapper { get; }

	protected IGuidProvider GuidProvider { get; }

	protected IEventPublisher EventPublisher { get; }

	protected IUserCommandRepository Repository { get; }

	protected IDateTimeProvider DateTimeProvider { get; }

	protected IEmailConfirmationTokenFactory Factory { get; }

	protected IUserIncludeBuilderFactory IncludeBuilderFactory { get; }

	protected IEmailConfirmationTokenEmailSender EmailSender { get; }

	protected IOptions<EmailConfirmationTokenOptions> EmailConfirmationTokenOptions { get; }

	protected IEmailConfirmationTokenCommandRepository EmailConfirmationTokenRepository { get; }

	protected BaseEmailConfirmationTokenDomainCommandUnitTest() : base(UserDomainMockFactory.CreatePasswordHasher())
	{
		Mapper = MockFactory.CreateMapper(IdentityDomainReference.Assembly);
		GuidProvider = DomainMockFactory.CreateGuidProvider();
		EventPublisher = DomainMockFactory.CreateEventPublisher();
		Repository = UserDomainMockFactory.CreateCommandRepository();
		DateTimeProvider = DomainMockFactory.CreateDateTimeProvider();
		Factory = EmailConfirmationTokenDomainMockFactory.CreateFactory();
		IncludeBuilderFactory = UserDomainMockFactory.CreateIncludeBuilderFactory();
		EmailSender = EmailConfirmationTokenDomainMockFactory.CreateEmailSender();
		EmailConfirmationTokenOptions = EmailConfirmationTokenDomainMockFactory.CreateOptions();
		EmailConfirmationTokenRepository = EmailConfirmationTokenDomainMockFactory.CreateCommandRepository();
	}
}
