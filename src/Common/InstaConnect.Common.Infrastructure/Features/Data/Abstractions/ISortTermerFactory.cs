namespace InstaConnect.Common.Infrastructure.Features.Data.Abstractions;

public interface ISortTermerFactory<in TSortTerm, TSortTermer, TEntity>
    where TSortTerm : Enum
    where TSortTermer : ISortTermer<TSortTerm, TEntity>
{
	public TSortTermer Create(TSortTerm sortTerm);
}
