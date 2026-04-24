using InstaConnect.Common.Application.Features.Messaging.Abstractions;
using InstaConnect.Posts.Presentation.Tests.Features.PostCommentLikes.Utilities;

namespace InstaConnect.Posts.Presentation.Tests.Features.PostCommentLikes.Assertions;

public static class PostCommentLikeMockAssertions
{
    extension(IApplicationSender sender)
    {
        public async Task ShouldReceiveOneSendAsync(
        GetAllPostCommentLikesApiRequest request,
        CancellationToken cancellationToken)
        {
            await sender.ShouldHaveReceivedOne().SendAsync(PostCommentLikeMatcher.IsGetAllPostCommentLikesQueryRequest(request), cancellationToken);
        }

        public async Task ShouldReceiveOneSendAsync(
            GetAllPostCommentLikesForUserApiRequest request,
            CancellationToken cancellationToken)
        {
            await sender.ShouldHaveReceivedOne().SendAsync(PostCommentLikeMatcher.IsGetAllPostCommentLikesForUserQueryRequest(request), cancellationToken);
        }

        public async Task ShouldReceiveOneSendAsync(
            GetPostCommentLikeByIdApiRequest request,
            CancellationToken cancellationToken)
        {
            await sender.ShouldHaveReceivedOne().SendAsync(PostCommentLikeMatcher.IsGetPostCommentLikeByIdQueryRequest(request), cancellationToken);
        }

        public async Task ShouldReceiveOneSendAsync(
            AddPostCommentLikeApiRequest request,
            CancellationToken cancellationToken)
        {
            await sender.ShouldHaveReceivedOne().SendAsync(PostCommentLikeMatcher.IsAddPostCommentLikeCommandRequest(request), cancellationToken);
        }

        public async Task ShouldReceiveOneSendAsync(
            DeletePostCommentLikeApiRequest request,
            CancellationToken cancellationToken)
        {
            await sender.ShouldHaveReceivedOne().SendAsync(PostCommentLikeMatcher.IsDeletePostCommentLikeCommandRequest(request), cancellationToken);
        }
    }
}
