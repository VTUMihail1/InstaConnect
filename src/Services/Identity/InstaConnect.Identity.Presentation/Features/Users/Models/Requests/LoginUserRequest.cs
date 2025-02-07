using InstaConnect.Identity.Presentation.Features.Users.Models.Bindings;
using Microsoft.AspNetCore.Mvc;

namespace InstaConnect.Identity.Presentation.Features.Users.Models.Requests;

public record LoginUserRequest([FromBody] LoginUserBody Body);
