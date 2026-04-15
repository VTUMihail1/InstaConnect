namespace InstaConnect.Common.Domain.Abstractions;

public interface IPaginationQuery
{
    int Page { get; }

    int PageSize { get; }
}
