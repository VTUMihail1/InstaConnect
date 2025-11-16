namespace InstaConnect.Posts.Application.Features.PostLikes.Queries.GetById;

public record GetPostLikeByIdQueryRequest(PostLikeIdPayload Id) : IQueryRequest<GetPostLikeByIdQueryResponse>;
