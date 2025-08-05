using InstaConnect.Common.Tests.Utilities;
using InstaConnect.Common.Tests.Utilities.Events;
using InstaConnect.PostComments.Domain.Features.PostComments.Models.Entities;
using InstaConnect.PostComments.Domain.Features.PostComments.Models.Events;

namespace InstaConnect.PostComments.Common.Tests.Features.PostComments.Utilities;

public static class PostCommentEventHarness
{
    public static async Task<bool> HasPublishPostCommentAddedEventAsync(
        this IEventHarness eventHarness,
        PostComment postComment,
        CancellationToken cancellationToken)
    {
        var result = await eventHarness.PublishedAsync<PostCommentAddedEvent>(p => p.IsSatisfied(postComment), cancellationToken);

        return result;
    }

    public static async Task<bool> HasPublishPostCommentUpdatedEventAsync(
        this IEventHarness eventHarness,
        PostComment postComment,
        CancellationToken cancellationToken)
    {
        var result = await eventHarness.PublishedAsync<PostCommentUpdatedEvent>(p => p.IsSatisfied(postComment), cancellationToken);

        return result;
    }

    public static async Task<bool> HasPublishPostCommentDeletedEventAsync(
        this IEventHarness eventHarness,
        PostComment postComment,
        CancellationToken cancellationToken)
    {
        var result = await eventHarness.PublishedAsync<PostCommentDeletedEvent>(p => p.IsSatisfied(postComment), cancellationToken);

        return result;
    }
}
