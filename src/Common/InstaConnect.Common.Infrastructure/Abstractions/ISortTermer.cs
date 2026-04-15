using System.Linq.Expressions;

namespace InstaConnect.Common.Infrastructure.Abstractions;

public interface ISortTermer<TSortTerm, TEntity>
    where TSortTerm : Enum
{
    public TSortTerm SortTerm { get; }

    public Expression<Func<TEntity, object>> Term { get; }
}
