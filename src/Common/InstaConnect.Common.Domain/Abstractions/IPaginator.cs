namespace InstaConnect.Common.Domain.Abstractions;

public interface IPaginator
{
    int GetOffset(int page, int pageSize);

    bool HasNextPage(int page, int pageSize, long totalCount);

    bool HasPreviousPage(int page);
}
