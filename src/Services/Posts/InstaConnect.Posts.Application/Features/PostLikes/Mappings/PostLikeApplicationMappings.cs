using InstaConnect.Common.Application.Models;
using InstaConnect.Common.Domain.Models.ValueObjects;
using InstaConnect.Posts.Application.Features.PostLikes.Commands.Add;
using InstaConnect.Posts.Application.Features.PostLikes.Commands.Delete;
using InstaConnect.Posts.Application.Features.PostLikes.Queries.GetAll;
using InstaConnect.Posts.Application.Features.PostLikes.Queries.GetById;
using InstaConnect.Posts.Application.Features.Users.Models;
using InstaConnect.Posts.Domain.Features.PostLikes.Models.ValueObjects;
using InstaConnect.Posts.Domain.Features.Posts.Models.ValueObjects;
using InstaConnect.Posts.Domain.Features.Users.Models.ValueObjects;

using Mapster;

namespace InstaConnect.Posts.Application.Features.PostLikes.Mappings;

internal class PostLikeApplicationMappings : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        config.NewConfig<GetAllPostLikesQueryRequest, GetAllPostLikesQuery>()
            .ConstructUsing(src => new(
                src.Filter.Adapt<PostLikeFilterQuery>(),
                src.Sorting.Adapt<PostLikeSortingQuery>(),
                src.Pagination.Adapt<PostLikePaginationQuery>()));

        config.NewConfig<PostLikeCollection, GetAllPostLikesQueryResponse>()
            .ConstructUsing(pc => new(
                pc.Data.Adapt<ICollection<PostLikeQueryResponse>>(),
                pc.Page,
                pc.PageSize,
                pc.TotalCount,
                pc.HasNextPage,
                pc.HasPreviousPage));

        config.NewConfig<GetPostLikeByIdQueryRequest, GetPostLikeByIdQuery>()
            .ConstructUsing(src => new(src.Id.Adapt<PostLikeId>()));

        config.NewConfig<PostLike, GetPostLikeByIdQueryResponse>()
            .ConstructUsing(src => new(
                src.Adapt<PostLikeQueryResponse>()));

        config.NewConfig<PostLike, PostLikeQueryResponse>()
            .ConstructUsing(src => new(
                src.Id.Adapt<PostLikeIdPayload>(),
                src.User.Adapt<UserQueryResponse>(),
                src.CreatedAtUtc));

        config.NewConfig<AddPostLikeCommandRequest, AddPostLikeCommand>()
            .ConstructUsing(src => new(
                src.Id.Adapt<PostId>(),
                src.UserId.Adapt<UserId>()));

        config.NewConfig<PostLike, AddPostLikeCommandResponse>()
            .ConstructUsing(src => new(src.Id.Adapt<PostLikeIdPayload>()));

        config.NewConfig<DeletePostLikeCommandRequest, DeletePostLikeCommand>()
            .ConstructUsing(src => new(src.Id.Adapt<PostLikeId>()));

        config.NewConfig<PostLikeIdPayload, PostLikeId>()
            .ConstructUsing(src => new(
                src.Id.Adapt<PostId>(),
                src.UserId.Adapt<UserId>()));

        config.NewConfig<PostLikeId, PostLikeIdPayload>()
            .ConstructUsing(src => new(
                src.Id.Adapt<PostIdPayload>(),
                src.UserId.Adapt<UserIdPayload>()));

        config.NewConfig<PostLikeFilterQueryRequest, PostLikeFilterQuery>()
            .ConstructUsing(src => new(
                src.Id.Adapt<PostId>(),
                src.UserName.Adapt<Name>()));

        config.NewConfig<PostLikeSortingQueryRequest, PostLikeSortingQuery>()
            .ConstructUsing(src => new(
                src.Order,
                src.Property));

        config.NewConfig<PostLikePaginationQueryRequest, PostLikePaginationQuery>()
            .ConstructUsing(src => new(
                src.Page,
                src.PageSize));
    }
}
