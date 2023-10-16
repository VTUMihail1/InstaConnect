using InstaConnect.Data.Models.Entities;

namespace InstaConnect.Business.UnitTests.Utilities.Services
{
    public static class TestPostLikeServiceUtilities
    {
        public const string TestExistingPostId = "ExistingPostId";
        public const string TestNonExistingPostId = "NonExistingPostId";

        public const string TestExistingPostLikeId = "ExistingPostLikeId";
        public const string TestNonExistingPostLikeId = "NonExistingPostLikeId";

        public const string TestExistingUserId = "ExistingUserId";
        public const string TestNonExistingUserId = "NonExistingUserId";

        public const string TestExistingPostCommentPostId = "ExistingPostCommentPostId";
        public const string TestExistingPostCommentUserId = "ExistingPostCommentUserId";

        public static readonly List<Post> TestPosts = new List<Post>()
        {
            new Post() { Id = TestExistingPostId, UserId = TestExistingUserId},
            new Post() { Id = TestExistingPostCommentPostId, UserId = TestExistingPostCommentUserId}
        };

        public static readonly List<PostLike> TestPostLikes = new List<PostLike>()
        {
            new PostLike() { Id = TestExistingPostLikeId, UserId = TestExistingPostCommentUserId, PostId = TestExistingPostCommentPostId},
        };

        public static readonly User TestExistingUser = new User();
    }
}
