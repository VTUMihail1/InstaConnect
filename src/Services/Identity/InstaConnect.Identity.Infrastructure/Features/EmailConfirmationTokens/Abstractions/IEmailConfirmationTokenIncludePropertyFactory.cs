namespace InstaConnect.Identity.Infrastructure.Features.EmailConfirmationTokens.Abstractions;

public interface IEmailConfirmationTokenIncludePropertyFactory
{
    IEnumerable<IEmailConfirmationTokenIncludeProperty> Create(ICollection<EmailConfirmationTokenIncludeProperty>? includeProperties);
}
