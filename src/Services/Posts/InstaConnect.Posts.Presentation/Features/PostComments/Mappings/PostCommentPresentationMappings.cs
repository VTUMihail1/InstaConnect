using InstaConnect.Posts.Application.Features.PostComments.Commands.Add;
using InstaConnect.Posts.Application.Features.PostComments.Commands.Delete;
using InstaConnect.Posts.Application.Features.PostComments.Commands.Update;
using InstaConnect.Posts.Application.Features.PostComments.Models;
using InstaConnect.Posts.Application.Features.PostComments.Queries.GetAll;
using InstaConnect.Posts.Application.Features.PostComments.Queries.GetById;
using InstaConnect.Posts.Application.Features.Posts.Models;
using InstaConnect.Posts.Presentation.Features.Users.Models.Responses;

using Mapster;

namespace InstaConnect.Posts.Presentation.Features.PostComments.Mappings;

internal class PostCommentPresentationMappings : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        config.NewConfig<GetAllPostCommentsApiRequest, GetAllPostCommentsQueryRequest>()
            .ConstructUsing(src => new(
                new(
                    new(src.Id),
                    new(src.UserId),
                    new(src.UserName)),
                new(
                    src.SortOrder,
                    src.SortProperty),
                new(
                    src.Page,
                    src.PageSize)));

        config.NewConfig<GetAllPostCommentsQueryResponse, GetAllPostCommentsApiResponse>()
            .ConstructUsing(pc => new(
                pc.Data.Adapt<ICollection<PostCommentApiResponse>>(),
                pc.Page,
                pc.PageSize,
                pc.TotalCount,
                pc.HasNextPage,
                pc.HasPreviousPage));

        config.NewConfig<GetPostCommentByIdApiRequest, GetPostCommentByIdQueryRequest>()
            .ConstructUsing(src => new(
                                       new(
                                           new(src.Id),
                                           src.CommentId)));

        config.NewConfig<GetPostCommentByIdQueryResponse, GetPostCommentByIdApiResponse>()
            .ConstructUsing(src => new(src.Data.Adapt<PostCommentApiResponse>()));

        config.NewConfig<AddPostCommentApiRequest, AddPostCommentCommandRequest>()
            .ConstructUsing(src => new(
                new(src.Id),
                src.Body.Content,
                new(src.UserId)));

        config.NewConfig<AddPostCommentCommandResponse, AddPostCommentApiResponse>()
            .ConstructUsing(src => new(src.Id.Adapt<PostCommentIdApiPayload>()));

        config.NewConfig<UpdatePostCommentApiRequest, UpdatePostCommentCommandRequest>()
            .ConstructUsing(src => new(
                                       new(
                                           new(src.Id),
                                           src.CommentId),
                                       new(src.Id),
                                       src.Body.Content));

        config.NewConfig<UpdatePostCommentCommandResponse, UpdatePostCommentApiResponse>()
            .ConstructUsing(src => new(src.Id.Adapt<PostCommentIdApiPayload>()));

        config.NewConfig<DeletePostCommentApiRequest, DeletePostCommentCommandRequest>()
            .ConstructUsing(src => new(
                                       new(
                                           new(src.Id),
                                           src.CommentId),
                                       new(src.Id)));

        config.NewConfig<PostCommentQueryResponse, PostCommentApiResponse>()
            .ConstructUsing(src => new(
                src.Id.Adapt<PostCommentIdApiPayload>(),
                src.Content,
                src.User.Adapt<UserApiResponse>(),
                src.CreatedAtUtc,
                src.UpdatedAtUtc));

        config.NewConfig<PostCommentIdApiPayload, PostCommentIdPayload>()
            .ConstructUsing(src => new(
                src.Id.Adapt<PostIdPayload>(),
                src.CommentId));

        config.NewConfig<PostCommentIdPayload, PostCommentIdApiPayload>()
            .ConstructUsing(src => new(
                src.Id.Adapt<PostIdApiPayload>(),
                src.CommentId));
    }
}
