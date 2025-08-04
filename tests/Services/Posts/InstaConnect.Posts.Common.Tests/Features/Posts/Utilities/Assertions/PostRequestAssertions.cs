using InstaConnect.Common.Tests.Utilities;
using InstaConnect.Posts.Application.Features.Posts.Commands.Add;
using InstaConnect.Posts.Application.Features.Posts.Commands.Update;
using InstaConnect.Posts.Presentation.Features.Posts.Models.Requests;

namespace InstaConnect.Posts.Common.Tests.Features.Posts.Utilities.Assertions;

public static class PostRequestAssertions
{
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
