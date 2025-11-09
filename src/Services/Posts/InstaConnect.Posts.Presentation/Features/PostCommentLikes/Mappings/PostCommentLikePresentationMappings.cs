using InstaConnect.Posts.Application.Features.PostCommentLikes.Commands.Add;
using InstaConnect.Posts.Application.Features.PostCommentLikes.Commands.Delete;
using InstaConnect.Posts.Application.Features.PostCommentLikes.Queries.GetAll;
using InstaConnect.Posts.Application.Features.PostCommentLikes.Queries.GetById;

using Mapster;

namespace InstaConnect.Posts.Presentation.Features.PostCommentLikes.Mappings;

internal class PostCommentLikePresentationMappings : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        config.NewConfig<GetAllPostCommentLikesApiRequest, GetAllPostCommentLikesQueryRequest>()
            .ConstructUsing(src => new(
                new(src.Filter.Id, src.Filter.CommentId, src.Filter.UserName),
                new(src.Sorting.Order, src.Sorting.Property),
                new(src.Pagination.Page, src.Pagination.PageSize)));

        config.NewConfig<GetAllPostCommentLikesQueryResponse, GetAllPostCommentLikesApiResponse>()
            .ConstructUsing(pc => new(
                  pc.Data.Select(p => new PostCommentLikeApiResponse(
                                      p.Id,
                                      p.CommentId,
                                      new(
                                          p.User.Id,
                                          p.User.Name,
                                          p.User.ProfileImage)))
                         .ToList(),
                  pc.Page,
                  pc.PageSize,
                  pc.TotalCount,
                  pc.HasNextPage,
                  pc.HasPreviousPage));

        config.NewConfig<GetPostCommentLikeByIdApiRequest, GetPostCommentLikeByIdQueryRequest>()
            .ConstructUsing(src => new(src.Id, src.CommentId, src.UserId));

        config.NewConfig<GetPostCommentLikeByIdQueryResponse, GetPostCommentLikeByIdApiResponse>()
            .ConstructUsing(src => new(
                new(src.Data.Id,
                    src.Data.CommentId,
                    new(
                        src.Data.User.Id,
                        src.Data.User.Name,
                        src.Data.User.ProfileImage))));

        config.NewConfig<AddPostCommentLikeApiRequest, AddPostCommentLikeCommandRequest>()
            .ConstructUsing(src => new(src.Id, src.CommentId, src.UserId));

        config.NewConfig<AddPostCommentLikeCommandResponse, AddPostCommentLikeApiResponse>()
            .ConstructUsing(src => new(src.Id, src.CommentId, src.UserId, src.CreatedAt, src.UpdatedAt));

        config.NewConfig<DeletePostCommentLikeApiRequest, DeletePostCommentLikeCommandRequest>()
            .ConstructUsing(src => new(src.Id, src.CommentId, src.UserId));
    }
}
