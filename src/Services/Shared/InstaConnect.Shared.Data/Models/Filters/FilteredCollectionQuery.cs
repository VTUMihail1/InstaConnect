using System.Linq.Expressions;

namespace InstaConnect.Shared.Data.Models.Filters;

public class FilteredCollectionQuery<T> : CollectionQuery
{
    public Expression<Func<T, bool>> Expression { get; set; } = x => true;
}
