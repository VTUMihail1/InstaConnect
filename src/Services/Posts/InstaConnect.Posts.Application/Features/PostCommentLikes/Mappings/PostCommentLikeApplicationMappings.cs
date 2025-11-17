using InstaConnect.Common.Application.Models;
using InstaConnect.Common.Domain.Models.ValueObjects;
using InstaConnect.Posts.Application.Features.PostCommentLikes.Commands.Add;
using InstaConnect.Posts.Application.Features.PostCommentLikes.Commands.Delete;
using InstaConnect.Posts.Application.Features.PostCommentLikes.Queries.GetAll;
using InstaConnect.Posts.Application.Features.PostCommentLikes.Queries.GetById;
using InstaConnect.Posts.Application.Features.Users.Models;
using InstaConnect.Posts.Domain.Features.PostCommentLikes.Models.ValueObjects;
using InstaConnect.Posts.Domain.Features.PostComments.Models.ValueObjects;
using InstaConnect.Posts.Domain.Features.Users.Models.ValueObjects;

using Mapster;

namespace InstaConnect.Posts.Application.Features.PostCommentLikes.Mappings;

internal class PostCommentLikeApplicationMappings : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        config.NewConfig<GetAllPostCommentLikesQueryRequest, GetAllPostCommentLikesQuery>()
            .ConstructUsing(src => new(
                src.Filter.Adapt<PostCommentLikeFilterQuery>(),
                src.Sorting.Adapt<PostCommentLikeSortingQuery>(),
                src.Pagination.Adapt<PostCommentLikePaginationQuery>()));

        config.NewConfig<PostCommentLikeCollection, GetAllPostCommentLikesQueryResponse>()
            .ConstructUsing(pc => new(
                pc.Data.Adapt<ICollection<PostCommentLikeQueryResponse>>(),
                pc.Page,
                pc.PageSize,
                pc.TotalCount,
                pc.HasNextPage,
                pc.HasPreviousPage));

        config.NewConfig<GetPostCommentLikeByIdQueryRequest, GetPostCommentLikeByIdQuery>()
            .ConstructUsing(src => new(src.Id.Adapt<PostCommentLikeId>()));

        config.NewConfig<PostCommentLike, GetPostCommentLikeByIdQueryResponse>()
            .ConstructUsing(src => new(src.Adapt<PostCommentLikeQueryResponse>()));

        config.NewConfig<PostCommentLike, PostCommentLikeQueryResponse>()
            .ConstructUsing(src => new(
                src.Id.Adapt<PostCommentLikeIdPayload>(),
                src.User.Adapt<UserQueryResponse>(),
                src.CreatedAtUtc));

        config.NewConfig<AddPostCommentLikeCommandRequest, AddPostCommentLikeCommand>()
            .ConstructUsing(src => new(
                src.Id.Adapt<PostCommentId>(),
                src.UserId.Adapt<UserId>()));

        config.NewConfig<PostCommentLike, AddPostCommentLikeCommandResponse>()
            .ConstructUsing(src => new(src.Id.Adapt<PostCommentLikeIdPayload>()));

        config.NewConfig<DeletePostCommentLikeCommandRequest, DeletePostCommentLikeCommand>()
            .ConstructUsing(src => new(src.Id.Adapt<PostCommentLikeId>()));

        config.NewConfig<PostCommentLikeIdPayload, PostCommentLikeId>()
            .ConstructUsing(src => new(
                src.CommentId.Adapt<PostCommentId>(),
                src.UserId.Adapt<UserId>()));

        config.NewConfig<PostCommentLikeId, PostCommentLikeIdPayload>()
            .ConstructUsing(src => new(
                src.CommentId.Adapt<PostCommentIdPayload>(),
                src.UserId.Adapt<UserIdPayload>()));

        config.NewConfig<PostCommentLikeFilterQueryRequest, PostCommentLikeFilterQuery>()
            .ConstructUsing(src => new(
                src.Id.Adapt<PostCommentId>(),
                src.UserName.Adapt<Name>()));

        config.NewConfig<PostCommentLikeSortingQueryRequest, PostCommentLikeSortingQuery>()
            .ConstructUsing(src => new(
                src.Order,
                src.Property));

        config.NewConfig<PostCommentLikePaginationQueryRequest, PostCommentLikePaginationQuery>()
            .ConstructUsing(src => new(
                src.Page,
                src.PageSize));
    }
}
