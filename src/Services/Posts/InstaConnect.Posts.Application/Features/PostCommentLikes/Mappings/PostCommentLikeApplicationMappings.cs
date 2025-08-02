using InstaConnect.PostCommentLikes.Application.Features.PostCommentLikes.Commands.Add;
using InstaConnect.PostCommentLikes.Application.Features.PostCommentLikes.Commands.Delete;
using InstaConnect.PostCommentLikes.Application.Features.PostCommentLikes.Models;
using InstaConnect.PostCommentLikes.Application.Features.PostCommentLikes.Queries.GetAll;
using InstaConnect.PostCommentLikes.Application.Features.PostCommentLikes.Queries.GetById;
using InstaConnect.PostCommentLikes.Domain.Features.PostCommentLikes.Models.Entities;
using InstaConnect.PostCommentLikes.Domain.Features.PostCommentLikes.Models.Requests;
using InstaConnect.PostCommentLikes.Domain.Features.PostCommentLikes.Models.Responses;

using Mapster;

namespace InstaConnect.PostCommentLikes.Application.Features.PostCommentLikes.Mappings;

public class PostCommentLikeApplicationMappings : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        config.NewConfig<GetAllPostCommentLikesQueryRequest, GetAllPostCommentLikesQuery>()
            .ConstructUsing(src => new(
                new(src.Filter.Id, src.Filter.CommentId, src.Filter.UserId, src.Filter.UserName),
                new(src.Sorting.Order, src.Sorting.Property),
                new(src.Pagination.Page, src.Pagination.PageSize)));

        config.NewConfig<PostCommentLikeCollection, GetAllPostCommentLikesQueryResponse>()
            .ConstructUsing(pc => new(
                  pc.Data.Select(p => new PostCommentLikeQueryResponse(
                                      p.Id,
                                      p.CommentId,
                                      p.CommentLikeId,
                                      new(
                                          p.UserId,
                                          p.User!.Name,
                                          p.User.ProfileImage)))
                         .ToList(),
                  pc.Page,
                  pc.PageSize,
                  pc.TotalCount,
                  pc.HasNextPage,
                  pc.HasPreviousPage));

        config.NewConfig<GetPostCommentLikeByIdQueryRequest, GetPostCommentLikeByIdQuery>()
            .ConstructUsing(src => new(src.Id, src.CommentId, src.CommentLikeId));

        config.NewConfig<PostCommentLike, GetPostCommentLikeByIdQueryResponse>()
            .ConstructUsing(src => new(
                new(src.Id,
                    src.CommentId,
                    src.CommentLikeId,
                    new(
                        src.UserId,
                        src.User!.Name,
                        src.User.ProfileImage))));

        config.NewConfig<AddPostCommentLikeCommandRequest, AddPostCommentLikeCommand>()
            .ConstructUsing(src => new(src.Id, src.CommentId, src.UserId));

        config.NewConfig<PostCommentLike, AddPostCommentLikeCommandResponse>()
            .ConstructUsing(src => new(src.Id, src.CommentId, src.CommentLikeId, src.CreatedAt, src.UpdatedAt));

        config.NewConfig<DeletePostCommentLikeCommandRequest, DeletePostCommentLikeCommand>()
            .ConstructUsing(src => new(src.Id, src.CommentId, src.CommentLikeId, src.UserId));
    }
}
