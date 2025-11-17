using InstaConnect.Common.Application.Models;

namespace InstaConnect.Identity.Application.Features.Users.Models;

public record UserDetailsQueryResponse(
    UserIdPayload Id,
    string FirstName,
    string LastName,
    NamePayload Name,
    EmailPayload Email,
    ImagePayload? ProfileImage,
    DateTimeOffset CreatedAtUtc,
    DateTimeOffset UpdatedAtUtc);
