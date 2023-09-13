﻿namespace InstaConnect.Business.Models.Utilities
{
    public static class InstaConnectBusinessConstants
    {
        public const string AccessTokenPrefix = "Bearer ";

        public const string AccessTokenType = "AccessToken";

        public const string AccountConfirmEmailTokenType = "ConfirmEmailToken";

        public const string AccountForgotPasswordTokenType = "ForgotPasswordToken";

        public const string AccountEmailConfirmationTitle = "InstaConnect Email Verification";

        public const string AccountForgotPasswordTitle = "InstaConnect Reset Password";

        public const string EmailConfirmationTemplatePath = @"C:\Users\Misho\Desktop\InstaConnect\InstaConnect\InstaConnect.Business\Templates\InstaConnectConfirmEmailTemplate.html";

        public const string ForgotPasswordTemplatePath = @"C:\Users\Misho\Desktop\InstaConnect\InstaConnect\InstaConnect.Business\Templates\InstaConnectResetPasswordTemplate.html";

        public const string TemplateLinkPlaceholder = "InsertYourRouteValuesHere";
    }
}
