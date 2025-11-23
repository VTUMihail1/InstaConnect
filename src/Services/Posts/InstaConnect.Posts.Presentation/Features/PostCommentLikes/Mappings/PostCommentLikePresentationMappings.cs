using InstaConnect.Posts.Application.Features.PostCommentLikes.Commands.Add;
using InstaConnect.Posts.Application.Features.PostCommentLikes.Commands.Delete;
using InstaConnect.Posts.Application.Features.PostCommentLikes.Models;
using InstaConnect.Posts.Application.Features.PostCommentLikes.Queries.GetAll;
using InstaConnect.Posts.Application.Features.PostCommentLikes.Queries.GetById;
using InstaConnect.Posts.Application.Features.PostComments.Models;
using InstaConnect.Posts.Application.Features.Users.Models;
using InstaConnect.Posts.Presentation.Features.PostCommentLikes.Models.Payloads;
using InstaConnect.Posts.Presentation.Features.Users.Models.Responses;

using Mapster;

namespace InstaConnect.Posts.Presentation.Features.PostCommentLikes.Mappings;

internal class PostCommentLikePresentationMappings : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        config.NewConfig<GetAllPostCommentLikesApiRequest, GetAllPostCommentLikesQueryRequest>()
            .ConstructUsing(src => new(
                new(
                    new(
                        new(src.Id),
                        src.CommentId),
                    new(src.UserName)),
                new(
                    src.SortOrder,
                    src.SortProperty),
                new(
                    src.Page,
                    src.PageSize)));

        config.NewConfig<GetAllPostCommentLikesQueryResponse, GetAllPostCommentLikesApiResponse>()
            .ConstructUsing(pc => new(
                pc.Data.Adapt<ICollection<PostCommentLikeApiResponse>>(),
                pc.Page,
                pc.PageSize,
                pc.TotalCount,
                pc.HasNextPage,
                pc.HasPreviousPage));

        config.NewConfig<GetPostCommentLikeByIdApiRequest, GetPostCommentLikeByIdQueryRequest>()
            .ConstructUsing(src => new(
                                       new(
                                           new(
                                               new(src.Id),
                                               src.CommentId),
                                           new(src.UserId))));

        config.NewConfig<GetPostCommentLikeByIdQueryResponse, GetPostCommentLikeByIdApiResponse>()
            .ConstructUsing(src => new(src.Data.Adapt<PostCommentLikeApiResponse>()));

        config.NewConfig<AddPostCommentLikeApiRequest, AddPostCommentLikeCommandRequest>()
            .ConstructUsing(src => new(
                                       new(
                                           new(src.Id),
                                           src.CommentId),
                                       new(src.UserId)));

        config.NewConfig<AddPostCommentLikeCommandResponse, AddPostCommentLikeApiResponse>()
            .ConstructUsing(src => new(src.Id.Adapt<PostCommentLikeIdApiPayload>()));

        config.NewConfig<DeletePostCommentLikeApiRequest, DeletePostCommentLikeCommandRequest>()
            .ConstructUsing(src => new(
                                       new(
                                           new(
                                               new(src.Id),
                                               src.CommentId),
                                           new(src.UserId))));

        config.NewConfig<PostCommentLikeQueryResponse, PostCommentLikeApiResponse>()
            .ConstructUsing(src => new(
                src.Id.Adapt<PostCommentLikeIdApiPayload>(),
                src.User.Adapt<UserApiResponse>()));

        config.NewConfig<PostCommentLikeIdApiPayload, PostCommentLikeIdPayload>()
            .ConstructUsing(src => new(
                src.CommentId.Adapt<PostCommentIdPayload>(),
                src.UserId.Adapt<UserIdPayload>()));

        config.NewConfig<PostCommentLikeIdPayload, PostCommentLikeIdApiPayload>()
            .ConstructUsing(src => new(
                src.CommentId.Adapt<PostCommentIdApiPayload>(),
                src.UserId.Adapt<UserIdApiPayload>()));
    }
}
