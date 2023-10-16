using InstaConnect.Data.Models.Entities;

namespace InstaConnect.Business.UnitTests.Utilities.Services
{
    public static class TestFollowServiceUtilities
    {
        public const string TestExistingFollowId = "ExistingFollowId";
        public const string TestNonExistingFollowId = "NonExistingFollowId";

        public const string TestExistingFollowerId = "ExistingFollowerId";
        public const string TestNonExistingFollowerId = "NonExistingFollowerId";

        public const string TestExistingFollowingId = "ExistingFollowingId";
        public const string TestNonExistingFollowingId = "NonExistingFolloweingId";

        public const string TestExistingFollowFollowerId = "ExistingFollowFollowerId";
        public const string TestExistingFollowFollowingId = "ExistingFollowFollowingId";

        public static readonly List<Follow> TestFollows = new List<Follow>()
        {
            new Follow()
            {
                Id = TestExistingFollowId,
                FollowerId = TestExistingFollowFollowerId,
                FollowingId = TestExistingFollowFollowingId
            }
        };

        public static readonly User TestExistingUser = new User();

    }
}
