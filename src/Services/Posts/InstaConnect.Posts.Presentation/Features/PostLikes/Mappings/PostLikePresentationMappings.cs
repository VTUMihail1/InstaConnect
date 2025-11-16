using InstaConnect.Posts.Application.Features.PostLikes.Commands.Add;
using InstaConnect.Posts.Application.Features.PostLikes.Commands.Delete;
using InstaConnect.Posts.Application.Features.PostLikes.Models;
using InstaConnect.Posts.Application.Features.PostLikes.Queries.GetAll;
using InstaConnect.Posts.Application.Features.PostLikes.Queries.GetById;
using InstaConnect.Posts.Application.Features.Posts.Models;
using InstaConnect.Posts.Application.Features.Users.Models;

using Mapster;

namespace InstaConnect.Posts.Presentation.Features.PostLikes.Mappings;

internal class PostLikePresentationMappings : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        config.NewConfig<GetAllPostLikesApiRequest, GetAllPostLikesQueryRequest>()
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

        config.NewConfig<GetAllPostLikesQueryResponse, GetAllPostLikesApiResponse>()
            .ConstructUsing(pc => new(
                pc.Data.Adapt<ICollection<PostLikeApiResponse>>(),
                pc.Page,
                pc.PageSize,
                pc.TotalCount,
                pc.HasNextPage,
                pc.HasPreviousPage));

        config.NewConfig<GetPostLikeByIdApiRequest, GetPostLikeByIdQueryRequest>()
            .ConstructUsing(src => new(
                                       new(
                                           new(src.Id),
                                           new(src.UserId))));

        config.NewConfig<GetPostLikeByIdQueryResponse, GetPostLikeByIdApiResponse>()
            .ConstructUsing(src => new(src.Data.Adapt<PostLikeApiResponse>()));

        config.NewConfig<AddPostLikeApiRequest, AddPostLikeCommandRequest>()
            .ConstructUsing(src => new(
                                       new(src.Id),
                                       new(src.UserId)));

        config.NewConfig<AddPostLikeCommandResponse, AddPostLikeApiResponse>()
            .ConstructUsing(src => new(src.Id.Adapt<PostLikeIdApiPayload>()));

        config.NewConfig<DeletePostLikeApiRequest, DeletePostLikeCommandRequest>()
            .ConstructUsing(src => new(
                                       new(
                                           new(src.Id),
                                           new(src.UserId))));

        config.NewConfig<PostLikeQueryResponse, PostLikeApiResponse>()
            .ConstructUsing(src => new(
                src.Id.Adapt<PostLikeIdApiPayload>(),
                src.User.Adapt<PostLikeUserApiResponse>()));

        config.NewConfig<PostLikeIdApiPayload, PostLikeIdPayload>()
            .ConstructUsing(src => new(
                src.Id.Adapt<PostIdPayload>(),
                src.UserId.Adapt<UserIdPayload>()));

        config.NewConfig<PostLikeIdPayload, PostLikeIdApiPayload>()
            .ConstructUsing(src => new(
                src.Id.Adapt<PostIdApiPayload>(),
                src.UserId.Adapt<UserIdApiPayload>()));

        config.NewConfig<PostLikeUserQueryResponse, PostLikeUserApiResponse>()
            .ConstructUsing(src => new(
                src.Id.Adapt<UserIdApiPayload>(),
                src.Name.Adapt<NameApiPayload>(),
                src.ProfileImage.Adapt<ImageApiPayload>()));
    }
}
