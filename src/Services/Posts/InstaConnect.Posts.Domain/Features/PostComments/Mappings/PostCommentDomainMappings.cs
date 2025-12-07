using Mapster;

namespace InstaConnect.Posts.Domain.Features.PostComments.Mappings;

internal class PostCommentDomainMappings : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        config.NewConfig<PostComment, PostCommentAddedEventRequest>()
            .ConstructUsing(src => new(
                src.Id.Id.Id,
                src.Id.CommentId,
                src.Content,
                src.UserId.Id,
                src.CreatedAtUtc,
                src.UpdatedAtUtc));

        config.NewConfig<PostComment, PostCommentUpdatedEventRequest>()
            .ConstructUsing(src => new(
                src.Id.Id.Id,
                src.Id.CommentId,
                src.Content,
                src.UserId.Id,
                src.UpdatedAtUtc));

        config.NewConfig<PostComment, PostCommentDeletedEventRequest>()
            .ConstructUsing(src => new(
                src.Id.Id.Id,
                src.Id.CommentId));
    }
}
