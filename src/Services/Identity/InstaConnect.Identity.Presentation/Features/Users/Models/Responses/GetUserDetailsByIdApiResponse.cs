using InstaConnect.Users.Application.Features.Users.Models;
using InstaConnect.Users.Application.Features.Users.Queries.GetById;

namespace InstaConnect.Users.Application.Features.Users.Queries.GetAll;

public record GetUserDetailsByIdApiResponse(UserDetailsApiResponse Data);
