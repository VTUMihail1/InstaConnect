namespace InstaConnect.Posts.Presentation.Tests.Features.Posts.Assertions;

public static class PostMatchAssertions
{
    public static void ShouldSatisfy(this AddPostApiResponse response, Post post)
    {
        response.ShouldSatisfy(p => p.Response.Id == post.Id.Id);
    }

    public static void ShouldSatisfy(this UpdatePostApiResponse response, Post post)
    {
        response.ShouldSatisfy(p => p.Response.Id == post.Id.Id);
    }

    public static void ShouldSatisfy(this GetPostByIdApiResponse response, Post post, User user)
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

    public static void ShouldSatisfy(this GetAllPostsApiResponse response, Post post, User user, GetAllPostsApiRequest request)
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

    public static void ShouldSatisfy(this ActionResult<AddPostApiResponse> response, Post post)
    {
        response.ShouldBeActionResultAndSatisfy(p => p.Response.Id == post.Id.Id);
    }

    public static void ShouldSatisfy(this ActionResult<UpdatePostApiResponse> response, Post post)
    {
        response.ShouldBeActionResultAndSatisfy(p => p.Response.Id == post.Id.Id);
    }

    public static void ShouldSatisfy(this ActionResult<GetPostByIdApiResponse> response, Post post, User user)
    {
        response.ShouldBeActionResultAndSatisfy(p => p.Response.Id == post.Id.Id &&
                                                     p.Response.Title == post.Title &&
                                                     p.Response.Content == post.Content &&
                                                     p.Response.User.Id == user.Id.Id &&
                                                     p.Response.User.Name == user.Name.Value &&
                                                     (user.ProfileImage.IsNull() || user.ProfileImage!.Url == p.Response.User.ProfileImageUrl) &&
                                                     p.Response.CreatedAtUtc == post.CreatedAtUtc &&
                                                     p.Response.UpdatedAtUtc == post.UpdatedAtUtc);
    }

    public static void ShouldSatisfy(this ActionResult<GetAllPostsApiResponse> response, Post post, User user, GetAllPostsApiRequest request)
    {
        response.ShouldBeActionResultAndSatisfy(pp => pp.Response.Entities.All(p => p.Id == post.Id.Id &&
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

    public static void ShouldSatisfy(this Post post, AddPostApiRequest request)
    {
        post.ShouldSatisfy(p => p.UserId.Id == request.UserId &&
                                p.Title == request.Body.Title &&
                                p.Content == request.Body.Content);
    }

    public static void ShouldSatisfy(this Post post, UpdatePostApiRequest request)
    {
        post.ShouldSatisfy(p => p.Id.Id == request.Id &&
                                p.UserId.Id == request.UserId &&
                                p.Title == request.Body.Title &&
                                p.Content == request.Body.Content);
    }
}
