using InstaConnect.Posts.Application.Features.PostLikes.Commands.Add;
using InstaConnect.Posts.Application.Features.PostLikes.Commands.Delete;
using InstaConnect.Posts.Application.Features.PostLikes.Queries.GetAll;
using InstaConnect.Posts.Application.Features.PostLikes.Queries.GetById;

using Mapster;

namespace InstaConnect.Posts.Application.Features.PostLikes.Mappings;

internal class PostLikeApplicationMappings : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        config.NewConfig<GetAllPostLikesQueryRequest, GetAllPostLikesQuery>()
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

        config.NewConfig<PostLikeCollection, GetAllPostLikesQueryResponse>()
            .ConstructUsing(src => new(src.Adapt<PostLikeCollectionQueryResponse>(config)));

        config.NewConfig<GetPostLikeByIdQueryRequest, GetPostLikeByIdQuery>()
            .ConstructUsing(src => new(
                                       new(
                                           new(src.Id),
                                           new(src.UserId))));

        config.NewConfig<PostLike, GetPostLikeByIdQueryResponse>()
            .ConstructUsing(src => new(src.Adapt<PostLikeQueryResponse>(config)));

        config.NewConfig<PostLike, PostLikeQueryResponse>()
            .ConstructUsing(src => new(
                src.Id.Id.Id,
                src.User.Adapt<UserQueryResponse>(config),
                src.CreatedAtUtc));

        config.NewConfig<AddPostLikeCommandRequest, AddPostLikeCommand>()
            .ConstructUsing(src => new(
                                       new(src.Id),
                                       new(src.UserId)));

        config.NewConfig<PostLike, AddPostLikeCommandResponse>()
            .ConstructUsing(src => new(src.Id.Adapt<PostLikeIdCommandResponse>(config)));

        config.NewConfig<DeletePostLikeCommandRequest, DeletePostLikeCommand>()
            .ConstructUsing(src => new(
                                       new(
                                           new(src.Id),
                                           new(src.UserId))));

        config.NewConfig<PostLikeId, PostLikeIdCommandResponse>()
            .ConstructUsing(src => new(
                src.Id.Id,
                src.UserId.Id));

        config.NewConfig<PostLikeCollection, PostLikeCollectionQueryResponse>()
            .ConstructUsing(src => new(
                src.Entities.Adapt<ICollection<PostLikeQueryResponse>>(config),
                src.Page,
                src.PageSize,
                src.TotalCount,
                src.HasNextPage,
                src.HasPreviousPage));
    }
}
