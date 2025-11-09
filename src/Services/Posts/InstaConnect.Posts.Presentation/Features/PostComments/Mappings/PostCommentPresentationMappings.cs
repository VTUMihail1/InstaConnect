using InstaConnect.Posts.Application.Features.PostComments.Commands.Add;
using InstaConnect.Posts.Application.Features.PostComments.Commands.Delete;
using InstaConnect.Posts.Application.Features.PostComments.Commands.Update;
using InstaConnect.Posts.Application.Features.PostComments.Queries.GetAll;
using InstaConnect.Posts.Application.Features.PostComments.Queries.GetById;

using Mapster;

namespace InstaConnect.Posts.Presentation.Features.PostComments.Mappings;

internal class PostCommentPresentationMappings : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        config.NewConfig<GetAllPostCommentsApiRequest, GetAllPostCommentsQueryRequest>()
            .ConstructUsing(src => new(
                new(src.Filter.Id, src.Filter.UserId, src.Filter.UserName),
                new(src.Sorting.Order, src.Sorting.Property),
                new(src.Pagination.Page, src.Pagination.PageSize)));

        config.NewConfig<GetAllPostCommentsQueryResponse, GetAllPostCommentsApiResponse>()
            .ConstructUsing(pc => new(
                  pc.Data.Select(p => new PostCommentApiResponse(
                                      p.Id,
                                      p.CommentId,
                                      p.Content,
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

        config.NewConfig<GetPostCommentByIdApiRequest, GetPostCommentByIdQueryRequest>()
            .ConstructUsing(src => new(src.Id, src.CommentId));

        config.NewConfig<GetPostCommentByIdQueryResponse, GetPostCommentByIdApiResponse>()
            .ConstructUsing(src => new(
                new(src.Data.Id,
                    src.Data.CommentId,
                    src.Data.Content,
                    new(
                        src.Data.User.Id,
                        src.Data.User.Name,
                        src.Data.User.ProfileImage))));

        config.NewConfig<AddPostCommentApiRequest, AddPostCommentCommandRequest>()
            .ConstructUsing(src => new(src.Id, src.Body.Content, src.UserId));

        config.NewConfig<AddPostCommentCommandResponse, AddPostCommentApiResponse>()
            .ConstructUsing(src => new(src.Id, src.CommentId, src.CreatedAt, src.UpdatedAt));

        config.NewConfig<UpdatePostCommentApiRequest, UpdatePostCommentCommandRequest>()
            .ConstructUsing(src => new(src.Id, src.CommentId, src.UserId, src.Body.Content));

        config.NewConfig<UpdatePostCommentCommandResponse, UpdatePostCommentApiResponse>()
            .ConstructUsing(src => new(src.Id, src.CommentId, src.CreatedAt, src.UpdatedAt));

        config.NewConfig<DeletePostCommentApiRequest, DeletePostCommentCommandRequest>()
            .ConstructUsing(src => new(src.Id, src.CommentId, src.UserId));
    }
}
