namespace InstaConnect.Identity.Infrastructure.Features.EmailConfirmationTokens.Abstractions;

public interface IEmailConfirmationTokenIncludeProperty : IIncludeProperty<EmailConfirmationToken>
{
    public EmailConfirmationTokenIncludeProperty IncludeProperty { get; }
}
