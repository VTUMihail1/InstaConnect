using InstaConnect.Posts.Application.Features.Posts.Queries.GetAll;

namespace InstaConnect.Posts.Application.Features.Posts.Queries.GetById;

public record GetPostByIdQuery(string Id) : IQuery<GetPostByIdQueryResponse>;
