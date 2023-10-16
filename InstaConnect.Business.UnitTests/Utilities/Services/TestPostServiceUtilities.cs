using InstaConnect.Data.Models.Entities;

namespace InstaConnect.Business.UnitTests.Utilities.Services
{
    public static class TestPostServiceUtilities
    {

        public const string TestExistingUserId = "ExistingUserId";
        public const string TestInvalidUserId = "NonExistingUserId";

        public const string TestExistingPostId = "ExistingPostId";
        public const string TestNonExistingPostId = "NonExistingPostId";

        public static readonly List<Post> TestPosts = new List<Post>()
            {
                new Post()
                {
                    Id = TestExistingPostId,
                    UserId = TestExistingUserId
                }
            };

        public static readonly User TestExistingUser = new User();
    }
}
