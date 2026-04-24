using InstaConnect.Common.Domain.Features.Guids.Abstractions;

namespace InstaConnect.Common.Infrastructure.Features.Guids.Helpers;

public class GuidProvider : IGuidProvider
{
    public Guid NewGuid()
    {
        var guid = Guid.NewGuid();

        return guid;
    }
}
