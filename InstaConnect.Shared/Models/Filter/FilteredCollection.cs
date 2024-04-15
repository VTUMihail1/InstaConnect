using System.Linq.Expressions;

namespace InstaConnect.Shared.Models.Filter
{
    public class FilteredCollectionQuery<T> : Collection
    {
        public Expression<Func<T, bool>> Expression { get; set; }
    }
}
