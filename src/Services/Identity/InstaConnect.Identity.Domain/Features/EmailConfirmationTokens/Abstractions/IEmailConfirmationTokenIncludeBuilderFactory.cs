using InstaConnect.Identity.Domain.Features.EmailConfirmationTokens.Helpers;

namespace InstaConnect.Identity.Domain.Features.EmailConfirmationTokens.Abstractions;

public interface IEmailConfirmationTokenIncludeBuilderFactory
{
	public EmailConfirmationTokenIncludeBuilder Create();
}
