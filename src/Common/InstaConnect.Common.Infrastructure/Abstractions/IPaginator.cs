namespace InstaConnect.Common.Infrastructure.Abstractions;

public interface IPaginator
{
    int GetOffset(int page, int pageSize);

    bool HasNextPage(int page, int pageSize, int totalCount);

    bool HasPreviousPage(int page);
}
