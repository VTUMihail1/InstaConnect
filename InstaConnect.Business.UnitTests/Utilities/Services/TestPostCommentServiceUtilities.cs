using InstaConnect.Data.Models.Entities;

namespace InstaConnect.Business.UnitTests.Utilities.Services
{
    public static class TestPostCommentServiceUtilities
    {
        public const string TestExistingPostId = "ExistingPostId";
        public const string TestNonExistingPostId = "NonExistingPostId";

        public const string TestExistingPostCommentId = "ExistingPostCommentId";
        public const string TestNonExistingPostCommentId = "NonExistingPostCommentId";

        public const string TestExistingUserId = "ExistingUserId";
        public const string TestNonExistingUserId = "NonExistingUserId";

        public static readonly List<Post> TestPosts = new List<Post>()
        {
            new Post() { Id = TestExistingPostId}
        };

        public static readonly List<PostComment> TestPostComments = new List<PostComment>()
        {
            new PostComment() {
                Id = TestExistingPostCommentId,
                UserId = TestExistingUserId,
                PostId = TestExistingPostId,
                PostCommentId = TestExistingPostCommentId
            }
        };

        public static readonly User TestExistingUser = new User();
    }
}
