namespace InstaConnect.Common.Domain.Features.Messaging.Abstractions;

public interface IPaginatableQuery<out TPaginationQuery>
	where TPaginationQuery : IPaginationQuery
{
	public TPaginationQuery Pagination { get; }
}
