using InstaConnect.Data.Models.Entities;

namespace InstaConnect.Business.UnitTests.Constants
{
    public static class TokenTestConstants
    {
        public const string TestExistingTokenValue = "ValidToken";

        public const string TestNonExistingTokenValue = "InvalidToken";

        public const string TestInvalidTokenValue = null;

        public static readonly Token TestExistingToken = new Token();

        public static readonly Token TestNonExistingToken = null;
    }
}
