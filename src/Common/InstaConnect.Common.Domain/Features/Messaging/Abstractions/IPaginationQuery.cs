namespace InstaConnect.Common.Domain.Features.Messaging.Abstractions;

public interface IPaginationQuery
{
	public int Page { get; }

	public int PageSize { get; }
}
