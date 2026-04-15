namespace InstaConnect.Common.Domain.Abstractions;

public interface ISortableQuery<TSortingQuery, TSortTerm>
    where TSortingQuery : ISortingQuery<TSortTerm>
    where TSortTerm : Enum
{
    public TSortingQuery Sorting { get; }
}
