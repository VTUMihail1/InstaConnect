using InstaConnect.Data.Models.Entities;

namespace InstaConnect.Business.UnitTests.Utilities.Services
{
    public static class TestMessageServiceTestUtilities
    {
        public const string TestExistingMessageId = "ExistingMessageId";
        public const string TestNonExistingMessageId = "NonExistingMessageId";

        public const string TestExistingSenderId = "ExistingSenderId";
        public const string TestNonExistingSenderId = "NonExistingSenderId";

        public const string TestExistingReceiverId = "ExistingReceiverId";
        public const string TestNonExistingReceiverId = "NonExistingReceiverId";

        public static readonly List<Message> TestMessages = new List<Message>()
        {
            new Message()
            {
                Id = TestExistingMessageId,
                SenderId = TestExistingSenderId,
                ReceiverId = TestExistingReceiverId
            }
        };

        public static readonly User TestExistingUser = new User();
    }
}
