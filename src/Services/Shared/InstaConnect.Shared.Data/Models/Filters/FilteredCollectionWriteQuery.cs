using System.Linq.Expressions;

namespace InstaConnect.Shared.Data.Models.Filters;

public abstract class FilteredCollectionWriteQuery<T>
{
    public Expression<Func<T, bool>> Expression { get; set; } = x => true;
}
