namespace InstaConnect.Identity.Domain.Features.Common.Models.Requests;

public enum IdentityDestinationType
{
	None,
	User,
	UserClaim,
	RefreshToken,
	ForgotPasswordToken,
	EmailConfirmationToken
}
