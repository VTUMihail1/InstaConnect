using InstaConnect.Posts.Application.Features.PostCommentLikes.Commands.Add;
using InstaConnect.Posts.Application.Features.PostCommentLikes.Commands.Delete;
using InstaConnect.Posts.Application.Features.PostCommentLikes.Queries.GetAll;
using InstaConnect.Posts.Application.Features.PostCommentLikes.Queries.GetAllForUser;
using InstaConnect.Posts.Application.Features.PostCommentLikes.Queries.GetById;
using InstaConnect.Posts.Application.Features.PostComments.Queries.GetAllForUser;
using InstaConnect.Posts.Application.Features.Users.Models;
using InstaConnect.Posts.Domain.Features.PostCommentLikes.Models.Responses;

using Mapster;

namespace InstaConnect.Posts.Presentation.Features.PostCommentLikes.Mappings;

internal class PostCommentLikePresentationMappings : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        config.NewConfig<GetAllPostCommentLikesApiRequest, GetAllPostCommentLikesQueryRequest>()
            .ConstructUsing(src => new(
                src.Id,
                src.CommentId,
                src.UserName,
                src.CurrentUserId,
                src.SortOrder,
                src.SortTerm,
                src.Page,
                src.PageSize));

        config.NewConfig<GetAllPostCommentLikesQueryResponse, GetAllPostCommentLikesApiResponse>()
            .ConstructUsing(src => new(src.PostCommentLikeCollection.Adapt<PostCommentLikeCollectionApiResponse>(config)!));

        config.NewConfig<GetAllPostCommentLikesForUserApiRequest, GetAllPostCommentLikesForUserQueryRequest>()
            .ConstructUsing(src => new(
                    src.UserId,
                    src.CurrentUserId,
                    src.SortOrder,
                    src.SortTerm,
                    src.Page,
                    src.PageSize));

        config.NewConfig<GetAllPostCommentLikesForUserQueryResponse, GetAllPostCommentLikesForUserApiResponse>()
            .ConstructUsing(src => new(src.PostCommentLikeCollection.Adapt<PostCommentLikeCollectionApiResponse>(config)!));

        config.NewConfig<GetPostCommentLikeByIdApiRequest, GetPostCommentLikeByIdQueryRequest>()
            .ConstructUsing(src => new(
                src.Id,
                src.CommentId,
                src.UserId,
                src.CurrentUserId));

        config.NewConfig<GetPostCommentLikeByIdQueryResponse, GetPostCommentLikeByIdApiResponse>()
            .ConstructUsing(src => new(src.PostCommentLike.Adapt<PostCommentLikeApiResponse>(config)!));

        config.NewConfig<AddPostCommentLikeApiRequest, AddPostCommentLikeCommandRequest>()
            .ConstructUsing(src => new(
                src.Id,
                src.CommentId,
                src.UserId));

        config.NewConfig<AddPostCommentLikeCommandResponse, AddPostCommentLikeApiResponse>()
            .ConstructUsing(src => new(src.Id.Adapt<PostCommentLikeIdApiResponse>(config)!));

        config.NewConfig<DeletePostCommentLikeApiRequest, DeletePostCommentLikeCommandRequest>()
            .ConstructUsing(src => new(
                src.Id,
                src.CommentId,
                src.UserId));

        config.NewConfig<PostCommentLikeIdCommandResponse, PostCommentLikeIdApiResponse>()
            .ConstructUsing(src => new(
                src.Id,
                src.CommentId,
                src.UserId));

        config.NewConfig<PostCommentLikeQueryResponse, PostCommentLikeApiResponse>()
            .ConstructUsing(src => new(
                src.Id,
                src.CommentId,
                src.UserId,
                src.User.Adapt<UserApiResponse>(config),
                src.PostComment.Adapt<PostCommentApiResponse>(config),
                src.CreatedAtUtc));

        config.NewConfig<PostCommentLikeCollectionQueryResponse, PostCommentLikeCollectionApiResponse>()
            .ConstructUsing(src => new(
                  src.PostComment.Adapt<PostCommentApiResponse>(config),
                  src.User.Adapt<UserApiResponse>(config),
                  src.PostCommentLikes.Adapt<ICollection<PostCommentLikeApiResponse>>(config)!,
                  src.Page,
                  src.PageSize,
                  src.TotalCount,
                  src.HasNextPage,
                  src.HasPreviousPage));
    }
}
