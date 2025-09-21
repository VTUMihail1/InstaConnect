using InstaConnect.PostLikes.Application.Features.PostLikes.Queries.GetAll;

namespace InstaConnect.PostLikes.Application.Features.PostLikes.Queries.GetById;

public record GetPostLikeByIdQueryRequest(string Id, string UserId) : IQueryRequest<GetPostLikeByIdQueryResponse>;
