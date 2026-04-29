namespace InstaConnect.Identity.Domain.Features.Common.Helpers;

public interface IPasswordHasher
{
	public string Hash(string password);

	public bool IsMatch(string password, string passwordHash);

	public bool IsMismatch(string password, string passwordHash);
}
