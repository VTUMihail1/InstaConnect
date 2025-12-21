using InstaConnect.Common.Domain.Models;

namespace InstaConnect.Common.Domain.Abstractions;

public interface IPaginatableQuery
{
    public CommonPaginationQuery Pagination { get; }
}
