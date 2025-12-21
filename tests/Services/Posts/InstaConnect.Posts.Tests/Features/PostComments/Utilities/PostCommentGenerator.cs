using System.Linq;

using InstaConnect.Posts.Tests.Features.Posts.Utilities;

namespace InstaConnect.Posts.Tests.Features.PostComments.Utilities;
public static class PostCommentGenerator
{
    public static ICollection<PostComment> GenerateRange(this PostComment template, IEnumerable<User> users)
    {
        return [.. users
            .Select(user =>
            {
                var postComment = new PostComment(new(
                                                      template.Id.Id,
                                                      PostCommentDataFaker.GetId()),
                                                      PostCommentDataFaker.GetContent(),
                                                      user.Id,
                                                      PostCommentDataFaker.GetCreatedAtUtc(),
                                                      PostCommentDataFaker.GetUpdatedAtUtc());

                postComment.AddUser(user);

                return postComment;
            })];
    }
}
