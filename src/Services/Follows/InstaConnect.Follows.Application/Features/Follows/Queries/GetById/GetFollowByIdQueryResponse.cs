using InstaConnect.Follows.Application.Features.Follows.Models;
using InstaConnect.Follows.Application.Features.Follows.Queries.GetById;

namespace InstaConnect.Follows.Application.Features.Follows.Queries.GetAll;

public record GetFollowByIdQueryResponse(FollowQueryResponse Data);
