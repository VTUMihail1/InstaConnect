﻿namespace InstaConnect.Business.Models.Utilities
{
    public static class InstaConnectErrorMessages
    {
        public const string AccountInvalidToken = "Token is expired or is invalid";

        public const string AccountInvalidLogin = "Email or password are invalid";

        public const string AccountAlreadyExists = "Account with that email already exists";

        public const string AccountEmailNotConfirmed = "Confirm your email before trying to login";

        public const string AccountEmailAlreadyConfirmed = "Email is already confirmed";

        public const string AccountEmailDoesNotExist = "Account with that email does not exist";

        public const string AccountAccessTokenNotFound = "Token with that value does not exist";

        public const string AccountAccessTokenNotInHeader = "You need to be logged in before you logout";

        public const string AccountSendEmailFailed = "Account was registered but failed to send email";

        public const string PostNotFound = "Post does not exist";

        public const string PostLikeNotFound = "You need to like the post before unliking it";

        public const string PostLikeAlreadyExists = "You need to unlike the post before liking it";

        public const string PostCommentNotFound = "Comment does not exist";
    }
}
