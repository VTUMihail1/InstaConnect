using InstaConnect.Common.Infrastructure.Abstractions;

namespace InstaConnect.Common.Infrastructure.Helpers;

internal class Paginator : IPaginator
{
    public int GetOffset(int page, int pageSize)
    {
        return (page - 1) * pageSize;
    }

    public bool HasNextPage(int page, int pageSize, int totalCount)
    {
        return (page * pageSize) < totalCount;
    }

    public bool HasPreviousPage(int page)
    {
        return page > 1;
    }
}
