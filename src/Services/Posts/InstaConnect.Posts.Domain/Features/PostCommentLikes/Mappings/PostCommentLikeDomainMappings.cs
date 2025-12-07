using Mapster;

namespace InstaConnect.Posts.Domain.Features.PostCommentLikes.Mappings;

internal class PostCommentLikeDomainMappings : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        config.NewConfig<PostCommentLike, PostCommentLikeAddedEventRequest>()
            .ConstructUsing(src => new(
                src.Id.CommentId.Id.Id,
                src.Id.CommentId.CommentId,
                src.Id.UserId.Id,
                src.CreatedAtUtc));

        config.NewConfig<PostCommentLike, PostCommentLikeDeletedEventRequest>()
            .ConstructUsing(src => new(
                src.Id.CommentId.Id.Id,
                src.Id.CommentId.CommentId,
                src.Id.UserId.Id));
    }
}
