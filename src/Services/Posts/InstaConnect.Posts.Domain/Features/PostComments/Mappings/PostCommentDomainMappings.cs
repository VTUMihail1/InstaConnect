using AutoMapper;

using InstaConnect.PostComments.Domain.Features.PostComments.Models.Entities;
using InstaConnect.PostComments.Domain.Features.PostComments.Models.Events;

using Mapster;

namespace InstaConnect.PostComments.Domain.Features.PostComments.Mappings;

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
