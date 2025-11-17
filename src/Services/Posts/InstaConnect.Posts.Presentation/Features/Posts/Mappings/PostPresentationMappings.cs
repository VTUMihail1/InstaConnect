using InstaConnect.Posts.Application.Features.Posts.Commands.Add;
using InstaConnect.Posts.Application.Features.Posts.Commands.Delete;
using InstaConnect.Posts.Application.Features.Posts.Commands.Update;
using InstaConnect.Posts.Application.Features.Posts.Models;
using InstaConnect.Posts.Application.Features.Posts.Queries.GetAll;
using InstaConnect.Posts.Application.Features.Posts.Queries.GetById;
using InstaConnect.Posts.Application.Features.Users.Models;
using InstaConnect.Posts.Presentation.Features.Users.Models;

using Mapster;

namespace InstaConnect.Posts.Presentation.Features.Posts.Mappings;

internal class PostPresentationMappings : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        config.NewConfig<GetAllPostsApiRequest, GetAllPostsQueryRequest>()
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

        config.NewConfig<GetAllPostsQueryResponse, GetAllPostsApiResponse>()
            .ConstructUsing(pc => new(
                  pc.Data.Adapt<ICollection<PostApiResponse>>(),
                  pc.Page,
                  pc.PageSize,
                  pc.TotalCount,
                  pc.HasNextPage,
                  pc.HasPreviousPage));

        config.NewConfig<GetPostByIdApiRequest, GetPostByIdQueryRequest>()
            .ConstructUsing(src => new(src.Id.Adapt<PostIdPayload>()));

        config.NewConfig<GetPostByIdQueryResponse, GetPostByIdApiResponse>()
            .ConstructUsing(src => new(src.Adapt<PostApiResponse>()));

        config.NewConfig<PostQueryResponse, PostApiResponse>()
            .ConstructUsing(src => new(
                    src.Id.Adapt<PostIdApiPayload>(),
                    src.Title,
                    src.Content,
                    src.User.Adapt<UserApiResponse>(),
                    src.CreatedAtUtc,
                    src.UpdatedAtUtc));

        config.NewConfig<AddPostApiRequest, AddPostCommandRequest>()
            .ConstructUsing(src => new(
                new(src.UserId),
                src.Body.Title,
                src.Body.Content));

        config.NewConfig<AddPostCommandResponse, AddPostApiResponse>()
            .ConstructUsing(src => new(src.Id.Adapt<PostIdApiPayload>()));

        config.NewConfig<UpdatePostApiRequest, UpdatePostCommandRequest>()
            .ConstructUsing(src => new(
                new(src.Id),
                new(src.UserId),
                src.Body.Title,
                src.Body.Content));

        config.NewConfig<UpdatePostCommandResponse, UpdatePostApiResponse>()
            .ConstructUsing(src => new(src.Id.Adapt<PostIdApiPayload>()));

        config.NewConfig<DeletePostApiRequest, DeletePostCommandRequest>()
            .ConstructUsing(src => new(
                new(src.Id),
                new(src.UserId)));

        config.NewConfig<PostIdApiPayload, PostIdPayload>()
            .ConstructUsing(src => new(src.Id));

        config.NewConfig<PostIdPayload, PostIdApiPayload>()
            .ConstructUsing(src => new(src.Id));
    }
}
