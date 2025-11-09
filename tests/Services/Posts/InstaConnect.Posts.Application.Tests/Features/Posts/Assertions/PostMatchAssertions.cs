namespace InstaConnect.Posts.Application.Tests.Features.Posts.Assertions;

public static class PostMatchAssertions
{
    public static void ShouldSatisfy(this AddPostCommandResponse response, Post post)
    {
        response.ShouldSatisfy(p => p.Id == post.Id &&
                                    p.CreatedAt == post.CreatedAt &&
                                    p.UpdatedAt == post.UpdatedAt);
    }

    public static void ShouldSatisfy(this UpdatePostCommandResponse response, Post post)
    {
        response.ShouldSatisfy(p => p.Id == post.Id &&
                                    p.CreatedAt == post.CreatedAt &&
                                    p.UpdatedAt == post.UpdatedAt);
    }

    public static void ShouldSatisfy(this GetPostByIdQueryResponse response, Post post, User user)
    {
        response.ShouldSatisfy(p => p.Data.Id == post.Id &&
                                    p.Data.Title == post.Title &&
                                    p.Data.Content == post.Content &&
                                    p.Data.User.Id == user.Id &&
                                    p.Data.User.Name == user.Name &&
                                    p.Data.User.ProfileImage == user.ProfileImage);
    }

    public static void ShouldSatisfy(this GetAllPostsQueryResponse response, Post post, User user, GetAllPostsQueryRequest request)
    {
        response.ShouldSatisfy(pp => pp.Data.All(p => p.Id == post.Id &&
                                                      p.Title == post.Title &&
                                                      p.Content == post.Content &&
                                                      p.User.Id == user.Id &&
                                                      p.User.Name == user.Name &&
                                                      p.User.ProfileImage == user.ProfileImage) &&
                                     pp.Page == request.Pagination.Page &&
                                     pp.PageSize == request.Pagination.PageSize &&
                                     pp.TotalCount == pp.Data.Count &&
                                     pp.HasPreviousPage == pp.Page > 1 &&
                                     pp.HasNextPage == pp.Page * pp.PageSize < pp.TotalCount);
    }

    public static void ShouldSatisfy(this Post post, AddPostCommandRequest request)
    {
        post.ShouldSatisfy(p => p.UserId == request.UserId &&
                                p.Title == request.Title &&
                                p.Content == request.Content);
    }

    public static void ShouldSatisfy(this Post post, UpdatePostCommandRequest request)
    {
        post.ShouldSatisfy(p => p.Id == request.Id &&
                                p.UserId == request.UserId &&
                                p.Title == request.Title &&
                                p.Content == request.Content);
    }
}
