namespace InstaConnect.Identity.Application.Features.Users.Abstractions;

public interface ICurrentUserableQueryRequest
{
	public string CurrentId { get; }
}
