using InstaConnect.Common.Infrastructure.Abstractions;

namespace InstaConnect.Common.Infrastructure.Helpers;

public static class PaginatorFactory
{
    public static IPaginator Create()
    {
        return new Paginator();
    }
}
