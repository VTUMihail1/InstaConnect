using InstaConnect.Posts.Application.Features.Posts.Commands.Add;
using InstaConnect.Posts.Application.Features.Posts.Commands.Delete;
using InstaConnect.Posts.Application.Features.Posts.Commands.Update;
using InstaConnect.Posts.Application.Features.Posts.Queries.GetAll;
using InstaConnect.Posts.Application.Features.Posts.Queries.GetById;

using Mapster;

namespace InstaConnect.Posts.Application.Features.Posts.Mappings;

internal class PostApplicationMappings : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        config.NewConfig<GetAllPostsQueryRequest, GetAllPostsQuery>()
            .ConstructUsing(src => new(
                new(
                    new(src.UserId),
                    new(src.UserName),
                    src.Title),
                new(
                    src.SortOrder,
                    src.SortProperty),
                new(
                    src.Page,
                    src.PageSize)));

        config.NewConfig<PostCollection, GetAllPostsQueryResponse>()
            .ConstructUsing(src => new(src.Adapt<PostCollectionQueryResponse>(config)));

        config.NewConfig<GetPostByIdQueryRequest, GetPostByIdQuery>()
            .ConstructUsing(src => new(
                                       new(src.Id)));

        config.NewConfig<Post, GetPostByIdQueryResponse>()
            .ConstructUsing(src => new(src.Adapt<PostQueryResponse>(config)));

        config.NewConfig<Post, PostQueryResponse>()
            .ConstructUsing(src => new(
                    src.Id.Id,
                    src.Title,
                    src.Content,
                    src.User.Adapt<UserQueryResponse>(config),
                    src.CreatedAtUtc,
                    src.UpdatedAtUtc));

        config.NewConfig<AddPostCommandRequest, AddPostCommand>()
            .ConstructUsing(src => new(
                new(src.UserId),
                src.Title,
                src.Content));

        config.NewConfig<Post, AddPostCommandResponse>()
            .ConstructUsing(src => new(src.Id.Adapt<PostIdCommandResponse>(config)));

        config.NewConfig<UpdatePostCommandRequest, UpdatePostCommand>()
            .ConstructUsing(src => new(
                new(src.Id),
                new(src.UserId),
                src.Title,
                src.Content));

        config.NewConfig<Post, UpdatePostCommandResponse>()
            .ConstructUsing(src => new(src.Id.Adapt<PostIdCommandResponse>(config)));

        config.NewConfig<DeletePostCommandRequest, DeletePostCommand>()
            .ConstructUsing(src => new(
                new(src.Id),
                new(src.UserId)));

        config.NewConfig<PostId, PostIdCommandResponse>()
            .ConstructUsing(src => new(src.Id));

        config.NewConfig<PostCollection, PostCollectionQueryResponse>()
            .ConstructUsing(src => new(
                  src.Entities.Adapt<ICollection<PostQueryResponse>>(config),
                  src.Page,
                  src.PageSize,
                  src.TotalCount,
                  src.HasNextPage,
                  src.HasPreviousPage));
    }
}
