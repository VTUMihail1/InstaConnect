using Mapster;

namespace InstaConnect.Posts.Domain.Features.PostCommentLikes.Mappings;

internal class PostCommentLikeDomainMappings : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        config.NewConfig<PostCommentLike, PostCommentLikeAddedEventRequest>()
            .ConstructUsing(p => new(
                p.Id,
                p.CommentId,
                p.UserId,
                p.CreatedAt,
                p.UpdatedAt));

        config.NewConfig<PostCommentLike, PostCommentLikeDeletedEventRequest>()
            .ConstructUsing(p => new(p.Id, p.CommentId, p.UserId));
    }
}
