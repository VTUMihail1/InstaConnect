using InstaConnect.Follows.Presentation.Features.Users.Models.Payloads;

namespace InstaConnect.Follows.Presentation.Features.Users.Models.Responses;

public record UserApiResponse(UserIdApiPayload Id, NameApiPayload Name, ImageApiPayload? ProfileImage);
