using InstaConnect.Common.Application.Models;
using InstaConnect.Common.Domain.Models.ValueObjects;
using InstaConnect.Posts.Application.Features.PostComments.Commands.Add;
using InstaConnect.Posts.Application.Features.PostComments.Commands.Delete;
using InstaConnect.Posts.Application.Features.PostComments.Commands.Update;
using InstaConnect.Posts.Application.Features.PostComments.Queries.GetAll;
using InstaConnect.Posts.Application.Features.PostComments.Queries.GetById;
using InstaConnect.Posts.Application.Features.Users.Models;
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
                src.Adapt<PostCommentFilterQuery>(),
                src.Adapt<PostCommentSortingQuery>(),
                src.Adapt<PostCommentPaginationQuery>()));

        config.NewConfig<GetAllPostCommentsQueryRequest, PostCommentFilterQuery>()
            .ConstructUsing(src => new(
                src.Filter.Id.Adapt<PostId>(),
                src.Filter.UserId.Adapt<UserId>(),
                src.Filter.UserName.Adapt<Name>()));

        config.NewConfig<GetAllPostCommentsQueryRequest, PostCommentSortingQuery>()
            .ConstructUsing(src => new(
                src.Sorting.Order,
                src.Sorting.Property));

        config.NewConfig<GetAllPostCommentsQueryRequest, PostCommentPaginationQuery>()
            .ConstructUsing(src => new(
                src.Pagination.Page,
                src.Pagination.PageSize));

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
                src.User.Adapt<PostCommentUserQueryResponse>()));

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

        config.NewConfig<User, PostCommentUserQueryResponse>()
            .ConstructUsing(src => new(
                src.Id.Adapt<UserIdPayload>(),
                src.Name.Adapt<NamePayload>(),
                src.ProfileImage.Adapt<ImagePayload>()));
    }
}
