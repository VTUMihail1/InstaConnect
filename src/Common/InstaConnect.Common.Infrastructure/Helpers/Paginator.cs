using InstaConnect.Common.Infrastructure.Abstractions;

namespace InstaConnect.Common.Infrastructure.Helpers;

internal class Paginator : IPaginator
{
    public int GetOffset(int page, int pageSize)
    {
        var offset = (page - 1) * pageSize;

        return offset;
    }
}
