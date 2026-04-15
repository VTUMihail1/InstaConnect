using InstaConnect.Common.Domain.Models;

namespace InstaConnect.Common.Domain.Abstractions;

public interface ISortingQuery<out TSortTerm>
    where TSortTerm : Enum
{
    CommonSortOrder Order { get; }

    TSortTerm Term { get; }
}
