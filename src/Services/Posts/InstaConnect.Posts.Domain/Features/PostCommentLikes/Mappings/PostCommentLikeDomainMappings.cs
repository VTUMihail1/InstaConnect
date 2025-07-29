using AutoMapper;

using InstaConnect.PostCommentLikes.Domain.Features.PostCommentLikes.Models.Entities;
using InstaConnect.PostCommentLikes.Domain.Features.PostCommentLikes.Models.Events;

using Mapster;

namespace InstaConnect.PostCommentLikes.Domain.Features.PostCommentLikes.Mappings;

internal class PostCommentLikeDomainMappings : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        config.NewConfig<PostCommentLike, PostCommentLikeAddedEvent>()
            .ConstructUsing(p => new(
                p.Id,
                p.CommentId,
                p.CommentLikeId,
                p.UserId,
                p.CreatedAt,
                p.UpdatedAt));

        config.NewConfig<PostCommentLike, PostCommentLikeDeletedEvent>()
            .ConstructUsing(p => new(p.Id, p.CommentId, p.CommentLikeId));
    }
}
