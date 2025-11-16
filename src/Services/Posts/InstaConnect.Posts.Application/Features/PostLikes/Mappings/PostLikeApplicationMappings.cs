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
                src.Adapt<PostLikeFilterQuery>(),
                src.Adapt<PostLikeSortingQuery>(),
                src.Adapt<PostLikePaginationQuery>()));

        config.NewConfig<GetAllPostLikesQueryRequest, PostLikeFilterQuery>()
            .ConstructUsing(src => new(
                src.Filter.Id.Adapt<PostId>(),
                src.Filter.Id.Adapt<Name>()));

        config.NewConfig<GetAllPostLikesQueryRequest, PostLikeSortingQuery>()
            .ConstructUsing(src => new(
                src.Sorting.Order,
                src.Sorting.Property));

        config.NewConfig<GetAllPostLikesQueryRequest, PostLikePaginationQuery>()
            .ConstructUsing(src => new(
                src.Pagination.Page,
                src.Pagination.PageSize));

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
                src.User.Adapt<PostLikeUserQueryResponse>()));

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

        config.NewConfig<User, PostLikeUserQueryResponse>()
            .ConstructUsing(src => new(
                src.Id.Adapt<UserIdPayload>(),
                src.Name.Adapt<NamePayload>(),
                src.ProfileImage.Adapt<ImagePayload>()));
    }
}
