using System.Linq.Expressions;

namespace InstaConnect.Common.Infrastructure.Features.Data.Abstractions;

public interface ISortTermer<TSortTerm, TEntity>
    where TSortTerm : Enum
{
    public TSortTerm SortTerm { get; }

    public Expression<Func<TEntity, object>> Term { get; }
}
