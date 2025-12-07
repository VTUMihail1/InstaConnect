namespace InstaConnect.Posts.Application.Tests.Features.Posts.Assertions;

public static class PostMatchAssertions
{
    public static void ShouldSatisfy(this AddPostCommandResponse response, Post post)
    {
        response.ShouldSatisfy(p => p.Response.Id == post.Id.Id);
    }

    public static void ShouldSatisfy(this UpdatePostCommandResponse response, Post post)
    {
        response.ShouldSatisfy(p => p.Response.Id == post.Id.Id);
    }

    public static void ShouldSatisfy(this GetPostByIdQueryResponse response, Post post, User user)
    {
        response.ShouldSatisfy(p => p.Response.Id == post.Id.Id &&
                                    p.Response.Title == post.Title &&
                                    p.Response.Content == post.Content &&
                                    p.Response.User.Id == user.Id.Id &&
                                    p.Response.User.Name == user.Name.Value &&
                                    (user.ProfileImage.IsNull() || user.ProfileImage!.Url == p.Response.User.ProfileImageUrl) &&
                                    p.Response.CreatedAtUtc == post.CreatedAtUtc &&
                                    p.Response.UpdatedAtUtc == post.UpdatedAtUtc);
    }

    public static void ShouldSatisfy(this GetAllPostsQueryResponse response, Post post, User user, GetAllPostsQueryRequest request)
    {
        response.ShouldSatisfy(pp => pp.Response.Entities.All(p => p.Id == post.Id.Id &&
                                                      p.Title == post.Title &&
                                                      p.Content == post.Content &&
                                                      p.User.Id == user.Id.Id &&
                                                      p.User.Name == user.Name.Value &&
                                                      (user.ProfileImage.IsNull() || user.ProfileImage!.Url == p.User.ProfileImageUrl) &&
                                     pp.Response.Page == request.Page &&
                                     pp.Response.PageSize == request.PageSize &&
                                     pp.Response.TotalCount == pp.Response.Entities.Count &&
                                     pp.Response.HasPreviousPage == pp.Response.Page > 1 &&
                                     pp.Response.HasNextPage == pp.Response.Page * pp.Response.PageSize < pp.Response.TotalCount));
    }

    public static void ShouldSatisfy(this Post post, AddPostCommandRequest request)
    {
        post.ShouldSatisfy(p => p.UserId.Id == request.UserId &&
                                p.Title == request.Title &&
                                p.Content == request.Content);
    }

    public static void ShouldSatisfy(this Post post, UpdatePostCommandRequest request)
    {
        post.ShouldSatisfy(p => p.Id.Id == request.Id &&
                                p.UserId.Id == request.UserId &&
                                p.Title == request.Title &&
                                p.Content == request.Content);
    }
}
