using InstaConnect.Common.Domain.Models.ValueObjects;
using InstaConnect.Posts.Application.Features.PostComments.Commands.Add;
using InstaConnect.Posts.Application.Features.PostComments.Commands.Delete;
using InstaConnect.Posts.Application.Features.PostComments.Commands.Update;
using InstaConnect.Posts.Application.Features.PostComments.Queries.GetAll;
using InstaConnect.Posts.Application.Features.PostComments.Queries.GetById;
using InstaConnect.Posts.Domain.Features.PostComments.Models.ValueObjects;
using InstaConnect.Posts.Domain.Features.Posts.Models.ValueObjects;
using InstaConnect.Posts.Domain.Features.Users.Models.ValueObjects;

using Mapster;

namespace InstaConnect.Posts.Application.Features.PostComments.Mappings;

internal class PostCommentApplicationMappings : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        config.NewConfig<GetAllPostCommentsQueryRequest, GetAllPostCommentsQuery>()
            .ConstructUsing(src => new(
                src.Filter.Adapt<PostCommentFilterQuery>(),
                src.Sorting.Adapt<PostCommentSortingQuery>(),
                src.Pagination.Adapt<PostCommentPaginationQuery>()));

        config.NewConfig<PostCommentCollection, GetAllPostCommentsQueryResponse>()
            .ConstructUsing(pc => new(
                pc.Data.Adapt<ICollection<PostCommentQueryResponse>>(),
                pc.Page,
                pc.PageSize,
                pc.TotalCount,
                pc.HasNextPage,
                pc.HasPreviousPage));

        config.NewConfig<GetPostCommentByIdQueryRequest, GetPostCommentByIdQuery>()
            .ConstructUsing(src => new(src.Id.Adapt<PostCommentId>()));

        config.NewConfig<PostComment, GetPostCommentByIdQueryResponse>()
            .ConstructUsing(src => new(
                src.Adapt<PostCommentQueryResponse>()));

        config.NewConfig<PostComment, PostCommentQueryResponse>()
            .ConstructUsing(src => new(
                src.Id.Adapt<PostCommentIdPayload>(),
                src.Content,
                src.User.Adapt<UserQueryResponse>(),
                src.CreatedAtUtc,
                src.UpdatedAtUtc));

        config.NewConfig<AddPostCommentCommandRequest, AddPostCommentCommand>()
            .ConstructUsing(src => new(
                src.Id.Adapt<PostId>(),
                src.Content,
                src.UserId.Adapt<UserId>()));

        config.NewConfig<PostComment, AddPostCommentCommandResponse>()
            .ConstructUsing(src => new(src.Id.Adapt<PostCommentIdPayload>()));

        config.NewConfig<UpdatePostCommentCommandRequest, UpdatePostCommentCommand>()
            .ConstructUsing(src => new(
                src.Id.Adapt<PostCommentId>(),
                src.UserId.Adapt<UserId>(),
                src.Content));

        config.NewConfig<PostComment, UpdatePostCommentCommandResponse>()
            .ConstructUsing(src => new(src.Id.Adapt<PostCommentId>()));

        config.NewConfig<DeletePostCommentCommandRequest, DeletePostCommentCommand>()
            .ConstructUsing(src => new(
                src.Id.Adapt<PostCommentId>(),
                src.UserId.Adapt<UserId>()));

        config.NewConfig<PostCommentIdPayload, PostCommentId>()
            .ConstructUsing(src => new(
                src.Id.Adapt<PostId>(),
                src.CommentId));

        config.NewConfig<PostCommentId, PostCommentIdPayload>()
            .ConstructUsing(src => new(
                src.Id.Adapt<PostIdPayload>(),
                src.CommentId));

        config.NewConfig<PostCommentFilterQueryRequest, PostCommentFilterQuery>()
            .ConstructUsing(src => new(
                src.Id.Adapt<PostId>(),
                src.UserId.Adapt<UserId>(),
                src.UserName.Adapt<Name>()));

        config.NewConfig<PostCommentSortingQueryRequest, PostCommentSortingQuery>()
            .ConstructUsing(src => new(
                src.Order,
                src.Property));

        config.NewConfig<PostCommentPaginationQueryRequest, PostCommentPaginationQuery>()
            .ConstructUsing(src => new(
                src.Page,
                src.PageSize));
    }
}
