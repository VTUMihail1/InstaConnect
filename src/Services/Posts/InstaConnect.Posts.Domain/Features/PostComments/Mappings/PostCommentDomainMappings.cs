using InstaConnect.Identity.Events.Features.Users;

using Mapster;

namespace InstaConnect.Posts.Domain.Features.PostComments.Mappings;

internal class PostCommentDomainMappings : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        config.NewConfig<PostComment, PostCommentAddedEventRequest>()
            .ConstructUsing(src => new(
                src.Id.Adapt<PostCommentIdEventPayload>(),
                src.Content,
                src.UserId.Adapt<UserIdEventPayload>()));

        config.NewConfig<PostComment, PostCommentUpdatedEventRequest>()
            .ConstructUsing(src => new(
                src.Id.Adapt<PostCommentIdEventPayload>(),
                src.Content,
                src.UserId.Adapt<UserIdEventPayload>()));

        config.NewConfig<PostComment, PostCommentDeletedEventRequest>()
            .ConstructUsing(src => new(src.Id.Adapt<PostCommentIdEventPayload>()));

        config.NewConfig<PostCommentId, PostCommentIdEventPayload>()
            .ConstructUsing(src => new(src.Id.Adapt<PostIdEventPayload>(),
                                     src.CommentId));
    }
}
