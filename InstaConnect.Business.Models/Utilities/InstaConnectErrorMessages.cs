namespace InstaConnect.Business.Models.Utilities
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

        public const string LikeNotFound = "You need to like before unliking it";

        public const string LikeAlreadyExists = "You need to unlike before liking it";

        public const string CommentNotFound = "Comment does not exist";

        public const string UserNotFound = "User does not exist";

        public const string FollowNotFound = "You need to follow before unfollowing";

        public const string FollowAlreadyExists = "You need to unfollow before following";

        public const string FollowerNotFound = "Follower does not exist";

        public const string FollowingNotFound = "Following does not exist";

        public const string ReceiverNotFound = "Receiver does not exist";

        public const string SenderNotFound = "Sender does not exist";

        public const string MessageNotFound = "Message does not exist";

        public const string UserHasNoPermission = "You dont have permission";
    }
}
