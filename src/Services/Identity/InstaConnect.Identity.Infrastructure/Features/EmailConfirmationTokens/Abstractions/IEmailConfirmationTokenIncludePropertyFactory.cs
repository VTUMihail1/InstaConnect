using InstaConnect.EmailConfirmationTokens.Domain.Features.EmailConfirmationTokens.Models.Requests;
using InstaConnect.EmailConfirmationTokens.Infrastructure.Features.EmailConfirmationTokens.Abstractions;

namespace InstaConnect.Common.Infrastructure.Abstractions;

public interface IEmailConfirmationTokenIncludePropertyFactory
{
    ICollection<IEmailConfirmationTokenIncludeProperty> Create(ICollection<EmailConfirmationTokenIncludeProperty>? includeProperties);
}
