using InstaConnect.Common.Domain.Features.Messaging.Models;

namespace InstaConnect.Common.Domain.Features.Messaging.Abstractions;

public interface ISortingQuery<out TSortTerm>
    where TSortTerm : Enum
{
    CommonSortOrder Order { get; }

    TSortTerm Term { get; }
}
