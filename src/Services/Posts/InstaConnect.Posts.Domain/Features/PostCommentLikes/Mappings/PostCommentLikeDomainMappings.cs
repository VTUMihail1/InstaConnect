using InstaConnect.Identity.Events.Features.Users;

using Mapster;

namespace InstaConnect.Posts.Domain.Features.PostCommentLikes.Mappings;

internal class PostCommentLikeDomainMappings : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        config.NewConfig<PostCommentLike, PostCommentLikeAddedEventRequest>()
            .ConstructUsing(src => new(
                src.Id.Adapt<PostCommentLikeIdEventPayload>(),
                src.CreatedAtUtc));

        config.NewConfig<PostCommentLike, PostCommentLikeDeletedEventRequest>()
            .ConstructUsing(src => new(src.Id.Adapt<PostCommentLikeIdEventPayload>()));

        config.NewConfig<PostCommentLikeId, PostCommentLikeIdEventPayload>()
            .ConstructUsing(src => new(src.CommentId.Adapt<PostCommentIdEventPayload>(),
                                       src.UserId.Adapt<UserIdEventPayload>()));
    }
}
