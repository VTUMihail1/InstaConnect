using InstaConnect.Posts.Tests.Features.PostCommentLikes.Utilities;
using InstaConnect.Posts.Tests.Features.PostLikes.Utilities;
using InstaConnect.Posts.Tests.Features.Posts.Utilities;

namespace InstaConnect.Posts.Tests.Features.PostComments.Utilities;
public static class PostCommentGenerator
{
    public static ICollection<PostComment> GeneratePostCommentsRange(this PostComment template, IEnumerable<User> users)
    {
        const int NumberOfIterationsPerUser = 5;

        return [.. users
            .SelectMany(user =>
                Enumerable.Range(default, NumberOfIterationsPerUser).Select(_ =>
                {
                    var postComment = new PostComment(new(
                                                      template.Id.Id,
                                                      PostCommentDataFaker.GetId()),
                                                      PostCommentDataFaker.GetContent(),
                                                      user.Id,
                                                      PostCommentDataFaker.GetCreatedAtUtc(),
                                                      PostCommentDataFaker.GetUpdatedAtUtc());


                var postCommentLike = new PostCommentLike(new(postComment.Id, user.Id),
                                            PostCommentLikeDataFaker.GetCreatedAtUtc());

                postComment.AddUser(user);
                postComment.AddPostCommentLike(postCommentLike);

                return postComment;
                }))];
    }
}
