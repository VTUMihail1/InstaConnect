using InstaConnect.Business.Models.DTOs.Account;
using InstaConnect.Business.Models.DTOs.Token;
using InstaConnect.Data.Models.Entities;

namespace InstaConnect.Business.UnitTests.Utilities.Services
{
    public static class TestAccountServiceUtilities
    {
        public const string TestExistingUserId = "ExistingUserId";
        public const string TestNonExistingUserId = "NonExistingUserId";
        public const string TestExistingUserIdWithUnconfirmedEmail = "ExistingUserIdWithUnconfirmedEmail";

        public const string TestExistingUserEmail = "ExistingUserEmail";
        public const string TestNonExistingUserEmail = "NonExistingUserEmail";
        public const string TestExistingUserUnconfirmedEmail = "ExistingUserUnconfimerEmail";
        public const string TestNonExistingUserValidEmailProvider = "NonExistingUserValidEmailProvider";
        public const string TestNonExistingUserInvalidEmailProvider = "NonExistingUserInvalidEmailProvider";

        public const string TestExistingUserUsername = "ExistingUserUsername";
        public const string TestExistingUserUnconfirmedEmailUsername = "ExistingUserUnconfirmedEmailUsername";
        public const string TestNonExistingValidUserUsername = "NonExistingValidUserUsername";
        public const string TestNonExistingInvalidUserUsername = "NonExistingInvalidUserUsername";

        public const string TestExistingUserPassword = "ExistingUserValidPassword";
        public const string TestNonExistingValidUserPassword = "NonExistingValidUserPassword";
        public const string TestNonExistingInvalidUserPassword = "NonExistingInvalidUserPassword";

        public const string TestValidUserToken = "ValidUserToken";
        public const string TestInvalidUserToken = "InvalidUserToken";

        public static readonly AccountRegistrationDTO TestExistingAccountRegistrationDTO = new AccountRegistrationDTO()
        {
            Email = TestExistingUserEmail,
            Username = TestExistingUserUsername,
            Password = TestExistingUserPassword
        };

        public static readonly AccountRegistrationDTO TestNonExistingAccountRegistrationDTOWithValidEmailProvider = new AccountRegistrationDTO()
        {
            Email = TestNonExistingUserValidEmailProvider,
            Username = TestNonExistingValidUserUsername,
            Password = TestNonExistingValidUserPassword
        };

        public static readonly AccountRegistrationDTO TestNonExistingAccountRegistrationDTOWithInvalidEmailProvider = new AccountRegistrationDTO()
        {
            Email = TestNonExistingUserInvalidEmailProvider,
            Username = TestNonExistingValidUserUsername,
            Password = TestNonExistingValidUserPassword
        };

        public static readonly AccountRegistrationDTO TestNonExistingAccountRegistrationDTOWithInvalidPassword = new AccountRegistrationDTO()
        {
            Email = TestNonExistingUserValidEmailProvider,
            Username = TestNonExistingValidUserUsername,
            Password = TestNonExistingInvalidUserPassword
        };

        public static readonly AccountRegistrationDTO TestNonExistingAccountRegistrationDTOWithInvalidEmail = new AccountRegistrationDTO()
        {
            Email = TestExistingUserEmail,
            Username = TestNonExistingValidUserUsername,
            Password = TestNonExistingValidUserPassword
        };

        public static readonly AccountRegistrationDTO TestNonExistingAccountRegistrationDTOWithInvalidUsername = new AccountRegistrationDTO()
        {
            Email = TestNonExistingUserValidEmailProvider,
            Username = TestExistingUserUsername,
            Password = TestNonExistingValidUserPassword
        };

        public static readonly TokenResultDTO TestValidToken = new TokenResultDTO()
        {
            Value = TestValidUserToken
        };

		public static readonly User TestExistingUser = new User()
        {
            Id = TestExistingUserId,
            Email = TestExistingUserEmail,
            UserName = TestExistingUserUsername
        };

        public static readonly User TestExistingUserWithUnconfirmedEmail = new User()
        {
            Id = TestExistingUserIdWithUnconfirmedEmail,
            Email = TestExistingUserUnconfirmedEmail,
            UserName = TestExistingUserUnconfirmedEmailUsername
        };

        public static readonly User TestNonExistingUserWithValidEmailProvider = new User()
        {
            Id = TestNonExistingUserId,
            Email = TestNonExistingUserValidEmailProvider,
            UserName = TestNonExistingValidUserUsername
        };

        public static readonly User TestNonExistingUserWithInvalidEmailProvider = new User()
        {
            Id = TestNonExistingUserId,
            Email = TestNonExistingUserInvalidEmailProvider,
            UserName = TestNonExistingValidUserUsername
        };

        public static readonly User TestNonExistingUserWithInvalidPassword = new User()
        {
            Id = TestNonExistingUserId,
            Email = TestNonExistingUserValidEmailProvider,
            UserName = TestNonExistingValidUserUsername
        };

        public static readonly User TestNonExistingUserWithInvalidEmail = new User()
        {
            Id = TestNonExistingUserId,
            Email = TestExistingUserEmail,
            UserName = TestNonExistingValidUserUsername
        };

        public static readonly User TestNonExistingUserWithInvalidUsername = new User()
        {
            Id = TestNonExistingUserId,
            Email = TestNonExistingUserValidEmailProvider,
            UserName = TestExistingUserUsername
        };
    }
}
