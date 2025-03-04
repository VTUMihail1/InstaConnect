namespace InstaConnect.Posts.Application.Features.PostLikes.Queries.GetById;

public record GetPostLikeByIdQuery(string Id, string PostId) : IQuery<PostLikeQueryViewModel>;
