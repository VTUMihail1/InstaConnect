namespace InstaConnect.Posts.Application.Features.Posts.Queries.GetById;

public record GetPostByIdQueryRequest(string Id) : IQueryRequest<GetPostByIdQueryResponse>;
