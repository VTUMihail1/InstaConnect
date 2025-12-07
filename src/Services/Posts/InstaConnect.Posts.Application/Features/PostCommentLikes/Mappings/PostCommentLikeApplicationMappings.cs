using InstaConnect.Posts.Application.Features.PostCommentLikes.Commands.Add;
using InstaConnect.Posts.Application.Features.PostCommentLikes.Commands.Delete;
using InstaConnect.Posts.Application.Features.PostCommentLikes.Queries.GetAll;
using InstaConnect.Posts.Application.Features.PostCommentLikes.Queries.GetById;

using Mapster;

namespace InstaConnect.Posts.Application.Features.PostCommentLikes.Mappings;

internal class PostCommentLikeApplicationMappings : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        config.NewConfig<PostCommentLikeId, PostCommentLikeIdCommandResponse>()
            .ConstructUsing(src => new(
                src.CommentId.Id.Id,
                src.CommentId.CommentId,
                src.UserId.Id));

        config.NewConfig<PostCommentLike, PostCommentLikeQueryResponse>()
            .ConstructUsing(src => new(
                src.Id.CommentId.Id.Id,
                src.Id.CommentId.CommentId,
                src.User.Adapt<UserQueryResponse>(config),
                src.CreatedAtUtc));

        config.NewConfig<GetAllPostCommentLikesQueryRequest, GetAllPostCommentLikesQuery>()
            .ConstructUsing(src => new(
                new(
                    new(
                        new(src.Id),
                        src.CommentId),
                    new(src.UserName)),
                new(
                    src.SortOrder,
                    src.SortProperty),
                new(
                    src.Page,
                    src.PageSize)));

        config.NewConfig<PostCommentLikeCollection, GetAllPostCommentLikesQueryResponse>()
            .ConstructUsing(src => new(src.Adapt<PostCommentLikeCollectionQueryResponse>(config)));

        config.NewConfig<GetPostCommentLikeByIdQueryRequest, GetPostCommentLikeByIdQuery>()
            .ConstructUsing(src => new(
                                       new(
                                           new(
                                               new(src.Id),
                                               src.CommentId),
                                           new(src.UserId))));

        config.NewConfig<PostCommentLike, GetPostCommentLikeByIdQueryResponse>()
            .ConstructUsing(src => new(src.Adapt<PostCommentLikeQueryResponse>(config)));

        config.NewConfig<AddPostCommentLikeCommandRequest, AddPostCommentLikeCommand>()
            .ConstructUsing(src => new(
                                       new(
                                           new(src.Id),
                                           src.CommentId),
                                       new(src.UserId)));

        config.NewConfig<PostCommentLike, AddPostCommentLikeCommandResponse>()
            .ConstructUsing(src => new(src.Id.Adapt<PostCommentLikeIdCommandResponse>(config)));

        config.NewConfig<DeletePostCommentLikeCommandRequest, DeletePostCommentLikeCommand>()
            .ConstructUsing(src => new(
                                       new(
                                           new(
                                               new(src.Id),
                                               src.CommentId),
                                           new(src.UserId))));

        config.NewConfig<PostCommentLikeCollection, PostCommentLikeCollectionQueryResponse>()
            .ConstructUsing(pc => new(
                pc.Entities.Adapt<ICollection<PostCommentLikeQueryResponse>>(config),
                pc.Page,
                pc.PageSize,
                pc.TotalCount,
                pc.HasNextPage,
                pc.HasPreviousPage));
    }
}
