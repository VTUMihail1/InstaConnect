using InstaConnect.Posts.Presentation.Tests.Features.Posts.Assertions;

namespace InstaConnect.Posts.Presentation.Tests.Features.Posts.Assertions;

public static class PostMatchAssertions
{
    public static void ShouldSatisfy(this AddPostApiResponse response, Post post)
    {
        response.ShouldSatisfy(p => p.Id == post.Id &&
                                    p.CreatedAt == post.CreatedAtUtc &&
                                    p.UpdatedAt == post.UpdatedAtUtc);
    }

    public static void ShouldSatisfy(this UpdatePostApiResponse response, Post post)
    {
        response.ShouldSatisfy(p => p.Id == post.Id &&
                                    p.CreatedAt == post.CreatedAtUtc &&
                                    p.UpdatedAt == post.UpdatedAtUtc);
    }

    public static void ShouldSatisfy(this GetPostByIdApiResponse response, Post post, User user)
    {
        response.ShouldSatisfy(p => p.Data.Id == post.Id &&
                                    p.Data.Title == post.Title &&
                                    p.Data.Content == post.Content &&
                                    p.Data.User.Id == user.Id &&
                                    p.Data.User.Name == user.Name &&
                                    p.Data.User.ProfileImage == user.ProfileImage);
    }

    public static void ShouldSatisfy(this GetAllPostsApiResponse response, Post post, User user, GetAllPostsApiRequest request)
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

    public static void ShouldSatisfy(this ActionResult<AddPostApiResponse> response, Post post)
    {
        response.ShouldBeActionResultAndSatisfy(p => p.Id == post.Id &&
                                                     p.CreatedAt == post.CreatedAtUtc &&
                                                     p.UpdatedAt == post.UpdatedAtUtc);
    }

    public static void ShouldSatisfy(this ActionResult<UpdatePostApiResponse> response, Post post)
    {
        response.ShouldBeActionResultAndSatisfy(p => p.Id == post.Id &&
                                                     p.CreatedAt == post.CreatedAtUtc &&
                                                     p.UpdatedAt == post.UpdatedAtUtc);
    }

    public static void ShouldSatisfy(this ActionResult<GetPostByIdApiResponse> response, Post post, User user)
    {
        response.ShouldBeActionResultAndSatisfy(p => p.Data.Id == post.Id &&
                                                     p.Data.Title == post.Title &&
                                                     p.Data.Content == post.Content &&
                                                     p.Data.User.Id == user.Id &&
                                                     p.Data.User.Name == user.Name &&
                                                     p.Data.User.ProfileImage == user.ProfileImage);
    }

    public static void ShouldSatisfy(this ActionResult<GetAllPostsApiResponse> response, Post post, User user, GetAllPostsApiRequest request)
    {
        response.ShouldBeActionResultAndSatisfy(pp => pp.Data.All(p => p.Id == post.Id &&
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

    public static void ShouldSatisfy(this Post post, AddPostApiRequest request)
    {
        post.ShouldSatisfy(p => p.UserId == request.UserId &&
                                p.Title == request.Body.Title &&
                                p.Content == request.Body.Content);
    }

    public static void ShouldSatisfy(this Post post, UpdatePostApiRequest request)
    {
        post.ShouldSatisfy(p => p.Id == request.Id &&
                                p.UserId == request.UserId &&
                                p.Title == request.Body.Title &&
                                p.Content == request.Body.Content);
    }
}
