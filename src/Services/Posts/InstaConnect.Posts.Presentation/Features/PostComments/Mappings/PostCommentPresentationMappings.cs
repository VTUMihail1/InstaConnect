using InstaConnect.Posts.Application.Features.PostComments.Commands.Add;
using InstaConnect.Posts.Application.Features.PostComments.Commands.Delete;
using InstaConnect.Posts.Application.Features.PostComments.Commands.Update;
using InstaConnect.Posts.Application.Features.PostComments.Queries.GetAll;
using InstaConnect.Posts.Application.Features.PostComments.Queries.GetById;

using Mapster;

namespace InstaConnect.Posts.Presentation.Features.PostComments.Mappings;

internal class PostCommentPresentationMappings : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        config.NewConfig<GetAllPostCommentsApiRequest, GetAllPostCommentsQueryRequest>()
            .ConstructUsing(src => new(
                src.Id,
                src.UserName,
                src.SortOrder,
                src.SortProperty,
                src.Page,
                src.PageSize));

        config.NewConfig<GetAllPostCommentsQueryResponse, GetAllPostCommentsApiResponse>()
            .ConstructUsing(src => new(src.Response.Adapt<PostCommentCollectionApiResponse>(config)));

        config.NewConfig<GetPostCommentByIdApiRequest, GetPostCommentByIdQueryRequest>()
            .ConstructUsing(src => new(src.Id,
                                       src.CommentId));

        config.NewConfig<GetPostCommentByIdQueryResponse, GetPostCommentByIdApiResponse>()
            .ConstructUsing(src => new(src.Response.Adapt<PostCommentApiResponse>(config)));

        config.NewConfig<AddPostCommentApiRequest, AddPostCommentCommandRequest>()
            .ConstructUsing(src => new(
                src.Id,
                src.Body.Content,
                src.UserId));

        config.NewConfig<AddPostCommentCommandResponse, AddPostCommentApiResponse>()
            .ConstructUsing(src => new(src.Response.Adapt<PostCommentIdApiResponse>(config)));

        config.NewConfig<UpdatePostCommentApiRequest, UpdatePostCommentCommandRequest>()
            .ConstructUsing(src => new(
                                       src.Id,
                                       src.CommentId,
                                       src.UserId,
                                       src.Body.Content));

        config.NewConfig<UpdatePostCommentCommandResponse, UpdatePostCommentApiResponse>()
            .ConstructUsing(src => new(src.Response.Adapt<PostCommentIdApiResponse>(config)));

        config.NewConfig<DeletePostCommentApiRequest, DeletePostCommentCommandRequest>()
            .ConstructUsing(src => new(src.Id,
                                       src.CommentId,
                                       src.UserId));

        config.NewConfig<PostCommentQueryResponse, PostCommentApiResponse>()
            .ConstructUsing(src => new(
                src.Id,
                src.CommentId,
                src.Content,
                src.User.Adapt<UserApiResponse>(config),
                src.CreatedAtUtc,
                src.UpdatedAtUtc));

        config.NewConfig<PostCommentIdCommandResponse, PostCommentIdApiResponse>()
            .ConstructUsing(src => new(
                src.Id,
                src.CommentId));

        config.NewConfig<PostCommentCollectionQueryResponse, PostCommentCollectionApiResponse>()
            .ConstructUsing(pc => new(
                pc.Entities.Adapt<ICollection<PostCommentApiResponse>>(config),
                pc.Page,
                pc.PageSize,
                pc.TotalCount,
                pc.HasNextPage,
                pc.HasPreviousPage));
    }
}
