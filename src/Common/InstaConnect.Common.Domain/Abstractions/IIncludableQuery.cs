using InstaConnect.Common.Domain.Models;

namespace InstaConnect.Common.Domain.Abstractions;

public interface IIncludableQuery<TIncludeProperty>
    where TIncludeProperty : Enum
{
    public CommonIncludeQuery<TIncludeProperty>? Include { get; }
}
