using InstaConnect.Data.Models.Entities;

namespace InstaConnect.Business.UnitTests.Utilities.Services
{
    public class TestUserServiceUtilities
    {
        public const string TestExistingUserId = "ExistingUserId";
        public const string TestNonExistingUserId = "NonExistingUserId";

        public const string TestExistingUserUsername = "ExistingUserUsername";
        public const string TestNonExistingUserUsername = "NonExistingUserUsername";

        public static readonly List<User> TestUsers = new List<User>()
        {
            new User()
            {
                Id = TestExistingUserId,
                UserName = TestExistingUserUsername
            }
        };
    }
}
