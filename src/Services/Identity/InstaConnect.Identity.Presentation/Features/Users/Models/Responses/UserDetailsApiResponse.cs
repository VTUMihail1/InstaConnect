namespace InstaConnect.Identity.Presentation.Features.Users.Models.Responses;

public record UserDetailsApiResponse(
    UserIdApiPayload Id,
    string FirstName,
    string LastName,
    NameApiPayload Name,
    EmailApiPayload Email,
    ImageApiPayload? ProfileImage,
    DateTimeOffset CreatedAtUtc,
    DateTimeOffset UpdatedAtUtc);
