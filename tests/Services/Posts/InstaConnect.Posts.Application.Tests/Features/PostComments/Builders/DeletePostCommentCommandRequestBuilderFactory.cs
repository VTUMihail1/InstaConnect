namespace InstaConnect.Posts.Application.Tests.Features.PostComments.Builders;

public class DeletePostCommentCommandRequestBuilderFactory
{
    public DeletePostCommentCommandRequestBuilder Create(PostComment postComment)
    {
        return new(postComment);
    }
}
