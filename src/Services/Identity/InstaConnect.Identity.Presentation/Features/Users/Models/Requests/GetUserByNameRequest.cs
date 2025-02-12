using Microsoft.AspNetCore.Mvc;

namespace InstaConnect.Identity.Presentation.Features.Users.Models.Requests;

public record GetUserByNameRequest([FromRoute] string UserName);
