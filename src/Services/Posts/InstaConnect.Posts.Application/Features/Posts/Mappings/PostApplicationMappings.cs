using InstaConnect.Common.Application.Models;
using InstaConnect.Common.Domain.Models.ValueObjects;
using InstaConnect.Posts.Application.Features.Posts.Commands.Add;
using InstaConnect.Posts.Application.Features.Posts.Commands.Delete;
using InstaConnect.Posts.Application.Features.Posts.Commands.Update;
using InstaConnect.Posts.Application.Features.Posts.Queries.GetAll;
using InstaConnect.Posts.Application.Features.Posts.Queries.GetById;
using InstaConnect.Posts.Application.Features.Users.Models;
using InstaConnect.Posts.Domain.Features.Posts.Models.ValueObjects;
using InstaConnect.Posts.Domain.Features.Users.Models.ValueObjects;

using Mapster;

namespace InstaConnect.Posts.Application.Features.Posts.Mappings;

internal class PostApplicationMappings : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        config.NewConfig<GetAllPostsQueryRequest, GetAllPostsQuery>()
            .ConstructUsing(src => new(
                src.Filter.Adapt<PostFilterQuery>(),
                src.Sorting.Adapt<PostSortingQuery>(),
                src.Pagination.Adapt<PostPaginationQuery>()));

        config.NewConfig<PostCollection, GetAllPostsQueryResponse>()
            .ConstructUsing(pc => new(
                  pc.Data.Adapt<ICollection<PostQueryResponse>>(),
                  pc.Page,
                  pc.PageSize,
                  pc.TotalCount,
                  pc.HasNextPage,
                  pc.HasPreviousPage));

        config.NewConfig<GetPostByIdQueryRequest, GetPostByIdQuery>()
            .ConstructUsing(src => new(src.Id.Adapt<PostId>()));

        config.NewConfig<Post, GetPostByIdQueryResponse>()
            .ConstructUsing(src => new(src.Adapt<PostQueryResponse>()));

        config.NewConfig<Post, PostQueryResponse>()
            .ConstructUsing(src => new(
                    src.Id.Adapt<PostIdPayload>(),
                    src.Title,
                    src.Content,
                    src.User.Adapt<UserQueryResponse>(),
                    src.CreatedAtUtc,
                    src.UpdatedAtUtc));

        config.NewConfig<AddPostCommandRequest, AddPostCommand>()
            .ConstructUsing(src => new(
                src.UserId.Adapt<UserId>(),
                src.Title,
                src.Content));

        config.NewConfig<Post, AddPostCommandResponse>()
            .ConstructUsing(src => new(src.Id.Adapt<PostIdPayload>()));

        config.NewConfig<UpdatePostCommandRequest, UpdatePostCommand>()
            .ConstructUsing(src => new(
                src.Id.Adapt<PostId>(),
                src.UserId.Adapt<UserId>(),
                src.Title,
                src.Content));

        config.NewConfig<Post, UpdatePostCommandResponse>()
            .ConstructUsing(src => new(src.Id.Adapt<PostIdPayload>()));

        config.NewConfig<DeletePostCommandRequest, DeletePostCommand>()
            .ConstructUsing(src => new(
                src.Id.Adapt<PostId>(),
                src.UserId.Adapt<UserId>()));

        config.NewConfig<PostIdPayload, PostId>()
            .ConstructUsing(src => new(src.Id));

        config.NewConfig<PostId, PostIdPayload>()
            .ConstructUsing(src => new(src.Id));

        config.NewConfig<PostFilterQueryRequest, PostFilterQuery>()
            .ConstructUsing(src => new(
                src.UserId.Adapt<UserId>(),
                src.UserName.Adapt<Name>(),
                src.Title));

        config.NewConfig<PostSortingQueryRequest, PostSortingQuery>()
            .ConstructUsing(src => new(
                src.Order,
                src.Property));

        config.NewConfig<PostPaginationQueryRequest, PostPaginationQuery>()
            .ConstructUsing(src => new(
                src.Page,
                src.PageSize));
    }
}
