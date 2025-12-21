using InstaConnect.Posts.Application.Features.PostComments.Commands.Add;
using InstaConnect.Posts.Application.Features.PostComments.Commands.Delete;
using InstaConnect.Posts.Application.Features.PostComments.Commands.Update;
using InstaConnect.Posts.Application.Features.PostComments.Queries.GetAll;
using InstaConnect.Posts.Application.Features.PostComments.Queries.GetById;

using Mapster;

namespace InstaConnect.Posts.Application.Features.PostComments.Mappings;

internal class PostCommentApplicationMappings : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        config.NewConfig<GetAllPostCommentsQueryRequest, GetAllPostCommentsQuery>()
            .ConstructUsing(src => new(
                new(
                    new(src.Id),
                    new(src.UserName)),
                new(
                    src.SortOrder,
                    src.SortProperty),
                new(
                    src.Page,
                    src.PageSize)));

        config.NewConfig<PostCommentCollection, GetAllPostCommentsQueryResponse>()
            .ConstructUsing(src => new(src.Adapt<PostCommentCollectionQueryResponse>(config)));

        config.NewConfig<GetPostCommentByIdQueryRequest, GetPostCommentByIdQuery>()
            .ConstructUsing(src => new(
                                       new(
                                           new(src.Id),
                                           src.CommentId)));

        config.NewConfig<PostComment, GetPostCommentByIdQueryResponse>()
            .ConstructUsing(src => new(src.Adapt<PostCommentQueryResponse>(config)));

        config.NewConfig<PostComment, PostCommentQueryResponse>()
            .ConstructUsing(src => new(
                src.Id.Id.Id,
                src.Id.CommentId,
                src.Content,
                src.User.Adapt<UserQueryResponse>(config),
                src.CreatedAtUtc,
                src.UpdatedAtUtc));

        config.NewConfig<AddPostCommentCommandRequest, AddPostCommentCommand>()
            .ConstructUsing(src => new(
                new(src.Id),
                src.Content,
                new(src.UserId)));

        config.NewConfig<PostComment, AddPostCommentCommandResponse>()
            .ConstructUsing(src => new(src.Id.Adapt<PostCommentIdCommandResponse>(config)));

        config.NewConfig<UpdatePostCommentCommandRequest, UpdatePostCommentCommand>()
            .ConstructUsing(src => new(
                new(
                    new(src.Id),
                    src.CommentId),
                new(src.UserId),
                src.Content));

        config.NewConfig<PostComment, UpdatePostCommentCommandResponse>()
            .ConstructUsing(src => new(src.Id.Adapt<PostCommentIdCommandResponse>(config)));

        config.NewConfig<DeletePostCommentCommandRequest, DeletePostCommentCommand>()
             .ConstructUsing(src => new(
                new(
                    new(src.Id),
                    src.CommentId),
                new(src.UserId)));

        config.NewConfig<PostCommentId, PostCommentIdCommandResponse>()
            .ConstructUsing(src => new(
                src.Id.Id,
                src.CommentId));

        config.NewConfig<PostCommentCollection, PostCommentCollectionQueryResponse>()
            .ConstructUsing(src => new(
                src.Entities.Adapt<ICollection<PostCommentQueryResponse>>(config),
                src.Page,
                src.PageSize,
                src.TotalCount,
                src.HasNextPage,
                src.HasPreviousPage));
    }
}
