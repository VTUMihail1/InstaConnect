namespace InstaConnect.Identity.Domain.Features.EmailConfirmationTokens.Abstractions;

public interface IEmailConfirmationTokenFactory
{
    public EmailConfirmationToken Create(UserId id);
}
