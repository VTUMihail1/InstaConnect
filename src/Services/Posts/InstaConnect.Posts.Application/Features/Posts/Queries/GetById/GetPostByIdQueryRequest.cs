namespace InstaConnect.Posts.Application.Features.Posts.Queries.GetById;

public record GetPostByIdQueryRequest(PostIdPayload Id) : IQueryRequest<GetPostByIdQueryResponse>;
