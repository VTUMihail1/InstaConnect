using Microsoft.AspNetCore.Mvc;

namespace InstaConnect.Follows.Presentation.Features.Follows.Models.Requests;

public record GetFollowByIdRequest([FromRoute] string Id);
