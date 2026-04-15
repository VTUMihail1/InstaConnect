namespace InstaConnect.Common.Infrastructure.Abstractions;

public interface ISortTermerFactory<in TSortTerm, TSortTermer, TEntity>
    where TSortTerm : Enum
    where TSortTermer : ISortTermer<TSortTerm, TEntity>
{
    TSortTermer Create(TSortTerm sortTerm);
}
