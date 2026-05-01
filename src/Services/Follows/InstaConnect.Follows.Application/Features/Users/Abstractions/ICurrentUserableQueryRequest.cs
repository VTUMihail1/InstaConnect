namespace InstaConnect.Follows.Application.Features.Users.Abstractions;

public interface ICurrentUserableQueryRequest
{
	public string CurrentUserId { get; }
}
