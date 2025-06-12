using InstaConnect.Common.Tests.Utilities;
using InstaConnect.Posts.Domain.Features.Posts.Exceptions;

namespace InstaConnect.Posts.Common.Tests.Features.Posts.Utilities.Assertions;

public static class PostExceptionAssertions
{
    public static async Task ShouldThrowPostNotFoundExceptionAsync(this Func<Task> action)
    {
        await action.ShouldThrowAsync<PostNotFoundException>();
    }
}
