namespace InstaConnect.Common.Domain.Features.Requests.Abstractions;

public interface IPaginatableQuery<out TPaginationQuery>
	where TPaginationQuery : IPaginationQuery
{
	public TPaginationQuery Pagination { get; }
}
