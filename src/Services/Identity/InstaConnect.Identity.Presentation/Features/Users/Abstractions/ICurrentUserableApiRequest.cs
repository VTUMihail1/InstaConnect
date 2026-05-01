namespace InstaConnect.Identity.Presentation.Features.Users.Abstractions;

public interface ICurrentUserableApiRequest
{
	public string CurrentId { get; }
}
