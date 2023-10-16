using InstaConnect.Data.Models.Entities;

namespace InstaConnect.Business.UnitTests.Utilities.Services
{
    public static class TestPostCommentLikeServiceUtilities
    {

        public const string TestExistingPostCommentLikeId = "ExistingPostCommentLikeId";
        public const string TestNonExistingPostCommentLikeId = "NonExistingPostCommentLikeId"
            ;
        public const string TestExistingPostCommentId = "ExistingPostCommentId";
        public const string TestNonExistingPostCommentId = "NonExistingPostCommentId";

        public const string TestExistingUserId = "ExistingUserId";
        public const string TestNonExistingUserId = "NonExistingUserId";

        public const string TestExistingPostCommentLikeUserId = "ExistingLikeUserId";
        public const string TestExistingPostCommentLikePostCommentId = "ExistingLikePostCommentId";

        public static readonly List<PostCommentLike> TestPostCommentLikes = new List<PostCommentLike>()
        {
            new PostCommentLike()
            {
                Id = TestExistingPostCommentLikeId,
                UserId = TestExistingPostCommentLikeUserId,
                PostCommentId = TestExistingPostCommentLikePostCommentId
            }
        };

        public static readonly List<PostComment> TestPostComments = new List<PostComment>()
        {
            new PostComment() { Id = TestExistingPostCommentId},
            new PostComment() { Id = TestExistingPostCommentLikePostCommentId}
        };

        public static readonly User TestExistingUser = new User();

    }
}
