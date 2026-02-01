namespace InstaConnect.Common.Domain.Abstractions;

public interface IPaginatableQuery<out TPaginationQuery>
    where TPaginationQuery : IPaginationQuery
{
    public TPaginationQuery Pagination { get; }
}
