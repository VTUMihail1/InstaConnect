using InstaConnect.PostLikes.Application.Features.PostLikes.Models;
using InstaConnect.PostLikes.Application.Features.PostLikes.Queries.GetById;

namespace InstaConnect.PostLikes.Application.Features.PostLikes.Queries.GetAll;

public record GetPostLikeByIdQueryResponse(PostLikeQueryResponse Data);
