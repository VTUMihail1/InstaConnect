using InstaConnect.Common.Infrastructure.Abstractions;

namespace InstaConnect.Common.Infrastructure.Helpers;

internal class Paginator : IPaginator
{
    public int GetOffset(int page, int pageSize)
    {
        var offset = (page - 1) * pageSize;

        return offset;
    }

    public bool HasNextPage(int page, int pageSize, long totalCount)
    {
        var hasNextPage = page * pageSize < totalCount;

        return hasNextPage;
    }

    public bool HasPreviousPage(int page)
    {
        var hasPreviousPage = page > 1;

        return hasPreviousPage;
    }
}
