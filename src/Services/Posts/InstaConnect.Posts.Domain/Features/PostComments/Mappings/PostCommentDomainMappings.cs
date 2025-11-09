using Mapster;

namespace InstaConnect.Posts.Domain.Features.PostComments.Mappings;

internal class PostCommentDomainMappings : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        config.NewConfig<PostComment, PostCommentAddedEventRequest>()
            .ConstructUsing(p => new(
                p.Id,
                p.CommentId,
                p.Content,
                p.UserId,
                p.CreatedAt,
                p.UpdatedAt));

        config.NewConfig<PostComment, PostCommentUpdatedEventRequest>()
            .ConstructUsing(p => new(
                p.Id,
                p.CommentId,
                p.Content,
                p.UserId,
                p.CreatedAt,
                p.UpdatedAt));

        config.NewConfig<PostComment, PostCommentDeletedEventRequest>()
            .ConstructUsing(p => new(p.Id, p.CommentId));
    }
}
