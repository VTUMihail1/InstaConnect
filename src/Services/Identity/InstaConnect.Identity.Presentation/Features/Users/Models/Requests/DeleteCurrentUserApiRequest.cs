namespace InstaConnect.Identity.Presentation.Features.Users.Models.Requests;

public record DeleteCurrentUserApiRequest([UserIdFromClaim] string CurrentId);
