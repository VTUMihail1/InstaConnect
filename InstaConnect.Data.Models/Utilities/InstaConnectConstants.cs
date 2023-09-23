namespace InstaConnect.Data.Models.Utilities
{
    public static class InstaConnectConstants
    {
        public const string AdminRole = "Admin";

        public const string UserRole = "User";

        public const string AccessTokenPrefix = "Bearer ";

        public const string AccessTokenType = "AccessToken";

        public const string AccountConfirmEmailTokenType = "ConfirmEmailToken";

        public const string AccountForgotPasswordTokenType = "ForgotPasswordToken";

        public const string AccountEmailConfirmationTitle = "InstaConnect Email Verification";

        public const string AccountForgotPasswordTitle = "InstaConnect Reset Password";

        public static readonly string EmailTemplatePrefixPath = Environment.CurrentDirectory.Substring(default, Environment.CurrentDirectory.IndexOf("InstaConnect"));

        public const string EmailConfirmationTemplatePath = @"InstaConnect\InstaConnect.Business\Templates\InstaConnectConfirmEmailTemplate.html";

        public const string ForgotPasswordTemplatePath = @"InstaConnect\InstaConnect.Business\Templates\InstaConnectResetPasswordTemplate.html";

        public const string TemplateLinkPlaceholder = "InsertYourRouteValuesHere";
    }
}
