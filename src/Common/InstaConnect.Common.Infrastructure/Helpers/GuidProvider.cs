using InstaConnect.Common.Domain.Abstractions;

namespace InstaConnect.Shared.Infrastructure.Helpers;

public class GuidProvider : IGuidProvider
{
    public Guid NewGuid()
    {
        var guid = Guid.NewGuid();

        return guid;
    }
}
