namespace InstaConnect.Common.Presentation.Features.Messaging.Abstractions;

public interface IPaginatableApiRequest
{
	public int Page { get; }

	public int PageSize { get; }
}
