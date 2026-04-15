using InstaConnect.Posts.Presentation.Tests.Features.Posts.Utilities;

namespace InstaConnect.Posts.Presentation.Tests.Features.Posts.Assertions;

public static class PostMockAssertions
{
    extension(IApplicationSender sender)
    {
        public async Task ShouldReceiveOneSendAsync(
        GetAllPostsApiRequest request,
        CancellationToken cancellationToken)
        {
            await sender.ShouldHaveReceivedOne().SendAsync(PostMatcher.IsGetAllPostsQueryRequest(request), cancellationToken);
        }

        public async Task ShouldReceiveOneSendAsync(
            GetAllPostsForUserApiRequest request,
            CancellationToken cancellationToken)
        {
            await sender.ShouldHaveReceivedOne().SendAsync(PostMatcher.IsGetAllPostsForUserQueryRequest(request), cancellationToken);
        }

        public async Task ShouldReceiveOneSendAsync(
            GetPostByIdApiRequest request,
            CancellationToken cancellationToken)
        {
            await sender.ShouldHaveReceivedOne().SendAsync(PostMatcher.IsGetPostByIdQueryRequest(request), cancellationToken);
        }

        public async Task ShouldReceiveOneSendAsync(
            AddPostApiRequest request,
            CancellationToken cancellationToken)
        {
            await sender.ShouldHaveReceivedOne().SendAsync(PostMatcher.IsAddPostCommandRequest(request), cancellationToken);
        }

        public async Task ShouldReceiveOneSendAsync(
            UpdatePostApiRequest request,
            CancellationToken cancellationToken)
        {
            await sender.ShouldHaveReceivedOne().SendAsync(PostMatcher.IsUpdatePostCommandRequest(request), cancellationToken);
        }

        public async Task ShouldReceiveOneSendAsync(
            DeletePostApiRequest request,
            CancellationToken cancellationToken)
        {
            await sender.ShouldHaveReceivedOne().SendAsync(PostMatcher.IsDeletePostCommandRequest(request), cancellationToken);
        }
    }
}
