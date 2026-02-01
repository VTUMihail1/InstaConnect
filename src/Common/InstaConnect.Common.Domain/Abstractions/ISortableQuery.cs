namespace InstaConnect.Common.Domain.Abstractions;

public interface ISortableQuery<TSortingQuery, TSortProperty>
    where TSortingQuery : ISortingQuery<TSortProperty>
    where TSortProperty : Enum
{
    public TSortingQuery Sorting { get; }
}
