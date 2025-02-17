using InstaConnect.Identity.Presentation.Features.Users.Models.Bodies;

namespace InstaConnect.Identity.Presentation.Features.Users.Models.Requests;

public record LoginUserRequest([FromBody] LoginUserBody Body);
