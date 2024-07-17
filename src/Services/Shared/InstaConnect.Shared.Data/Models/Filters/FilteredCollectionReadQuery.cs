using System.Linq.Expressions;

namespace InstaConnect.Shared.Data.Models.Filters;

public class FilteredCollectionReadQuery<T> : CollectionReadQuery
{
    public Expression<Func<T, bool>> Expression { get; set; } = x => true;
}
