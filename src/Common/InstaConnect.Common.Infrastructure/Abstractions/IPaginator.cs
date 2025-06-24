namespace InstaConnect.Common.Infrastructure.Abstractions;

public interface IPaginator
{
    int GetOffset(int page, int pageSize);
}