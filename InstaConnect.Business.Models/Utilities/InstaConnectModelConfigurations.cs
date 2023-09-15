namespace InstaConnect.Business.Models.Utilities
{
    public static class InstaConnectModelConfigurations
    {
        public const int AccountFirstNameMinLength = 2;

        public const int AccountFirstNameMaxLength = 50;

        public const int AccountLastNameMinLength = 2;

        public const int AccountLastNameMaxLength = 50;

        public const int AccountUsernameMinLength = 8;

        public const int AccountUsernameMaxLength = 50;

        public const int AccountPasswordMinLength = 8;

        public const int AccountPasswordMaxLength = 50;

        public const int AccountEmailMinLength = 8;

        public const int AccountEmailMaxLength = 100;

        public const string AccountEmailRegex = @"^[a-zA-Z0-9_+&*-]+(?:\.[a-zA-Z0-9_+&*-]+)*@(?:[a-zA-Z0-9-]+\.)+[a-zA-Z]{2,}$";

        public const string AccountPasswordRegex = @"^(?=.*\d)(?=.*[a-z])(?=.*[A-Z]).{8,}$";

        public const int PostTitleMinLength = 3;

        public const int PostTitleMaxLength = 255;

        public const int PostContentMinLength = 3;

        public const int PostContentMaxLength = 5000;

    }
}
