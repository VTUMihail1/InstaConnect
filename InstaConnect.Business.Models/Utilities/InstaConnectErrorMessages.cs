namespace InstaConnect.Business.Models.Utilities
{
    public static class InstaConnectErrorMessages
    {
        public const string AccountInvalidToken = "Token is expired or is invalid";

        public const string AccountInvalidLogin = "Email Or password Is invalid";

        public const string AccountAlreadyExists = "Account with that email already exists";

        public const string AccountEmailNotConfirmed = "Confirm your email before trying to login";

        public const string AccountEmailAlreadyConfirmed = "Email is already confirmed";

        public const string AccountEmailDoesNotExist = "Account with that email does not exist";

        public const string AccountAccessTokenNotFound = "Token with that value does not exist";

        public const string AccountAccessTokenNotInHeader = "You need to be logged in before you logout";
    }
}
