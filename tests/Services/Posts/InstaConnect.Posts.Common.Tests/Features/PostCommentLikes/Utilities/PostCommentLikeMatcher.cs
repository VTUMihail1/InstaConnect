using InstaConnect.Common.Tests.Utilities;
using InstaConnect.PostCommentLikes.Application.Features.PostCommentLikes.Commands.Add;
using InstaConnect.PostCommentLikes.Application.Features.PostCommentLikes.Commands.Delete;
using InstaConnect.PostCommentLikes.Application.Features.PostCommentLikes.Queries.GetAll;
using InstaConnect.PostCommentLikes.Application.Features.PostCommentLikes.Queries.GetById;
using InstaConnect.PostCommentLikes.Domain.Features.PostCommentLikes.Models.Requests;
using InstaConnect.PostCommentLikes.Presentation.Features.PostCommentLikes.Models.Requests;

namespace InstaConnect.PostCommentLikes.Common.Tests.Features.PostCommentLikes.Utilities;
public static class PostCommentLikeMatcher
{
    public static GetAllPostCommentLikesQueryRequest IsGetAllPostCommentLikesQueryRequest(GetAllPostCommentLikesApiRequest request)
    {
        return Matcher.Is<GetAllPostCommentLikesQueryRequest>(p => p.Filter.Id == request.Filter.Id &&
                                                                   p.Filter.CommentId == request.Filter.CommentId &&
                                                                   p.Filter.UserName == request.Filter.UserName &&
                                                                   p.Pagination.Page == request.Pagination.Page &&
                                                                   p.Pagination.PageSize == request.Pagination.PageSize &&
                                                                   p.Sorting.Order == request.Sorting.Order &&
                                                                   p.Sorting.Property == request.Sorting.Property);
    }

    public static GetPostCommentLikeByIdQueryRequest IsGetPostCommentLikeByIdQueryRequest(GetPostCommentLikeByIdApiRequest request)
    {
        return Matcher.Is<GetPostCommentLikeByIdQueryRequest>(p => p.Id == request.Id &&
                                                                   p.CommentId == request.CommentId &&
                                                                   p.UserId == request.UserId);
    }

    public static AddPostCommentLikeCommandRequest IsAddPostCommentLikeCommandRequest(AddPostCommentLikeApiRequest request)
    {
        return Matcher.Is<AddPostCommentLikeCommandRequest>(p => p.Id == request.Id &&
                                                                 p.CommentId == request.CommentId &&
                                                                 p.UserId == request.UserId);
    }

    public static DeletePostCommentLikeCommandRequest IsDeletePostCommentLikeCommandRequest(DeletePostCommentLikeApiRequest request)
    {
        return Matcher.Is<DeletePostCommentLikeCommandRequest>(p => p.Id == request.Id &&
                                                                    p.CommentId == request.CommentId &&
                                                                    p.UserId == request.UserId);
    }
    public static GetAllPostCommentLikesQuery IsGetAllPostCommentLikesQuery(GetAllPostCommentLikesQueryRequest request)
    {
        return Matcher.Is<GetAllPostCommentLikesQuery>(p => p.Filter.Id == request.Filter.Id &&
                                                            p.Filter.CommentId == request.Filter.CommentId &&
                                                            p.Filter.UserName == request.Filter.UserName &&
                                                            p.Pagination.Page == request.Pagination.Page &&
                                                            p.Pagination.PageSize == request.Pagination.PageSize &&
                                                            p.Sorting.Order == request.Sorting.Order &&
                                                            p.Sorting.Property == request.Sorting.Property);
    }

    public static GetPostCommentLikeByIdQuery IsGetPostCommentLikeByIdQuery(GetPostCommentLikeByIdQueryRequest request)
    {
        return Matcher.Is<GetPostCommentLikeByIdQuery>(p => p.Id == request.Id &&
                                                            p.CommentId == request.CommentId &&
                                                            p.UserId == request.UserId);
    }

    public static AddPostCommentLikeCommand IsAddPostCommentLikeCommand(AddPostCommentLikeCommandRequest request)
    {
        return Matcher.Is<AddPostCommentLikeCommand>(p => p.Id == request.Id &&
                                                          p.CommentId == request.CommentId &&
                                                          p.UserId == request.UserId);
    }

    public static DeletePostCommentLikeCommand IsDeletePostCommentLikeCommand(DeletePostCommentLikeCommandRequest request)
    {
        return Matcher.Is<DeletePostCommentLikeCommand>(p => p.Id == request.Id &&
                                                             p.CommentId == request.CommentId &&
                                                             p.UserId == request.UserId);
    }
}
