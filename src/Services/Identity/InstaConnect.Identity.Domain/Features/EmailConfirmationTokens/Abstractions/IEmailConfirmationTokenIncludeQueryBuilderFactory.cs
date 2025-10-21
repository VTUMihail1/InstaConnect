using InstaConnect.EmailConfirmationTokens.Domain.Features.EmailConfirmationTokens.Helpers;

namespace InstaConnect.EmailConfirmationTokens.Domain.Features.EmailConfirmationTokens.Abstractions;

public interface IEmailConfirmationTokenIncludeQueryBuilderFactory
{
    EmailConfirmationTokenIncludeQueryBuilder Create();
}