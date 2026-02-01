namespace InstaConnect.Identity.Infrastructure.Features.EmailConfirmationTokens.Abstractions;

public interface IEmailConfirmationTokenIncludeProperty : IIncluder<EmailConfirmationToken>
{
    public EmailConfirmationTokenIncludeProperty IncludeProperty { get; }
}
