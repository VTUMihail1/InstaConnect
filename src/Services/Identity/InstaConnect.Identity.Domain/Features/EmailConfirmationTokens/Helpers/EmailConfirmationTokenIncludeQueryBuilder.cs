using InstaConnect.Common.Domain.Models;

namespace InstaConnect.Identity.Domain.Features.EmailConfirmationTokens.Helpers;

public class EmailConfirmationTokenIncludeQueryBuilder
{
    private readonly ICollection<EmailConfirmationTokenIncludeProperty> _includeProperties;

    internal EmailConfirmationTokenIncludeQueryBuilder(ICollection<EmailConfirmationTokenIncludeProperty> includeProperties)
    {
        _includeProperties = includeProperties;
    }

    public CommonIncludeQuery<EmailConfirmationTokenIncludeProperty> Build()
    {
        return new(_includeProperties);
    }
}
