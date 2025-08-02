using AutoMapper;

using InstaConnect.PostComments.Application.Features.PostComments.Commands.Add;
using InstaConnect.PostComments.Application.Features.PostComments.Commands.Delete;
using InstaConnect.PostComments.Application.Features.PostComments.Commands.Update;
using InstaConnect.PostComments.Application.Features.PostComments.Models;
using InstaConnect.PostComments.Application.Features.PostComments.Queries.GetAll;
using InstaConnect.PostComments.Application.Features.PostComments.Queries.GetById;
using InstaConnect.PostComments.Domain.Features.PostComments.Models.Entities;
using InstaConnect.PostComments.Domain.Features.PostComments.Models.Requests;
using InstaConnect.PostComments.Domain.Features.PostComments.Models.Responses;

using Mapster;

namespace InstaConnect.PostComments.Application.Features.PostComments.Mappings;

public class PostCommentApplicationMappings : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        config.NewConfig<GetAllPostCommentsQueryRequest, GetAllPostCommentsQuery>()
            .ConstructUsing(src => new(
                new(src.Filter.Id, src.Filter.UserId, src.Filter.UserName),
                new(src.Sorting.Order, src.Sorting.Property),
                new(src.Pagination.Page, src.Pagination.PageSize)));

        config.NewConfig<PostCommentCollection, GetAllPostCommentsQueryResponse>()
            .ConstructUsing(pc => new(
                  pc.Data.Select(p => new PostCommentQueryResponse(
                                      p.Id,
                                      p.CommentId,
                                      p.Content,
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

        config.NewConfig<GetPostCommentByIdQueryRequest, GetPostCommentByIdQuery>()
            .ConstructUsing(src => new(src.Id, src.CommentId));

        config.NewConfig<PostComment, GetPostCommentByIdQueryResponse>()
            .ConstructUsing(src => new(
                new(src.Id,
                    src.CommentId,
                    src.Content,
                    new(
                        src.UserId,
                        src.User!.Name,
                        src.User.ProfileImage))));

        config.NewConfig<AddPostCommentCommandRequest, AddPostCommentCommand>()
            .ConstructUsing(src => new(src.Id, src.Content, src.UserId));

        config.NewConfig<PostComment, AddPostCommentCommandResponse>()
            .ConstructUsing(src => new(src.Id, src.CommentId, src.CreatedAt, src.UpdatedAt));

        config.NewConfig<UpdatePostCommentCommandRequest, UpdatePostCommentCommand>()
            .ConstructUsing(src => new(src.Id, src.CommentId, src.UserId, src.Content));

        config.NewConfig<PostComment, UpdatePostCommentCommandResponse>()
            .ConstructUsing(src => new(src.Id, src.CommentId, src.CreatedAt, src.UpdatedAt));

        config.NewConfig<DeletePostCommentCommandRequest, DeletePostCommentCommand>()
            .ConstructUsing(src => new(src.Id, src.CommentId, src.UserId));
    }
}
