using InstaConnect.Common.Tests.Utilities;
using InstaConnect.PostLikes.Application.Features.PostLikes.Commands.Add;
using InstaConnect.PostLikes.Application.Features.PostLikes.Commands.Delete;
using InstaConnect.PostLikes.Application.Features.PostLikes.Queries.GetAll;
using InstaConnect.PostLikes.Application.Features.PostLikes.Queries.GetById;
using InstaConnect.PostLikes.Domain.Features.PostLikes.Models.Requests;
using InstaConnect.PostLikes.Presentation.Features.PostLikes.Models.Requests;

namespace InstaConnect.PostLikes.Common.Tests.Features.PostLikes.Utilities;
public static class PostLikeMatcher
{
    public static GetAllPostLikesQueryRequest IsGetAllPostLikesQueryRequest(GetAllPostLikesApiRequest request)
    {
        return Matcher.Is<GetAllPostLikesQueryRequest>(p => p.Filter.Id == request.Filter.Id &&
                                                            p.Filter.UserId == request.Filter.UserId &&
                                                            p.Filter.UserName == request.Filter.UserName &&
                                                            p.Pagination.Page == request.Pagination.Page &&
                                                            p.Pagination.PageSize == request.Pagination.PageSize &&
                                                            p.Sorting.Order == request.Sorting.Order &&
                                                            p.Sorting.Property == request.Sorting.Property);
    }

    public static GetPostLikeByIdQueryRequest IsGetPostLikeByIdQueryRequest(GetPostLikeByIdApiRequest request)
    {
        return Matcher.Is<GetPostLikeByIdQueryRequest>(p => p.Id == request.Id &&
                                                            p.LikeId == request.LikeId);
    }

    public static AddPostLikeCommandRequest IsAddPostLikeCommandRequest(AddPostLikeApiRequest request)
    {
        return Matcher.Is<AddPostLikeCommandRequest>(p => p.Id == request.Id &&
                                                          p.UserId == request.UserId);
    }

    public static DeletePostLikeCommandRequest IsDeletePostLikeCommandRequest(DeletePostLikeApiRequest request)
    {
        return Matcher.Is<DeletePostLikeCommandRequest>(p => p.Id == request.Id &&
                                                             p.LikeId == request.LikeId &&
                                                             p.UserId == request.UserId);
    }
    public static GetAllPostLikesQuery IsGetAllPostLikesQuery(GetAllPostLikesQueryRequest request)
    {
        return Matcher.Is<GetAllPostLikesQuery>(p => p.Filter.Id == request.Filter.Id &&
                                                        p.Filter.UserId == request.Filter.UserId &&
                                                        p.Filter.UserName == request.Filter.UserName &&
                                                        p.Pagination.Page == request.Pagination.Page &&
                                                        p.Pagination.PageSize == request.Pagination.PageSize &&
                                                        p.Sorting.Order == request.Sorting.Order &&
                                                        p.Sorting.Property == request.Sorting.Property);
    }

    public static GetPostLikeByIdQuery IsGetPostLikeByIdQuery(GetPostLikeByIdQueryRequest request)
    {
        return Matcher.Is<GetPostLikeByIdQuery>(p => p.Id == request.Id &&
                                                     p.LikeId == request.LikeId);
    }

    public static AddPostLikeCommand IsAddPostLikeCommand(AddPostLikeCommandRequest request)
    {
        return Matcher.Is<AddPostLikeCommand>(p => p.Id == request.Id &&
                                                   p.UserId == request.UserId);
    }

    public static DeletePostLikeCommand IsDeletePostLikeCommand(DeletePostLikeCommandRequest request)
    {
        return Matcher.Is<DeletePostLikeCommand>(p => p.Id == request.Id &&
                                                      p.LikeId == request.LikeId &&
                                                      p.UserId == request.UserId);
    }
}
