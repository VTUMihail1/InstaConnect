namespace InstaConnect.Identity.Business.Features.Accounts.Utilities;

public class EmailConfigurations
{
    public const string EmailConfirmationUrlTemplate = "{0}/api/v1/accounts/confirm-email/by-user/{1}/by-token/{2}";

    public const string ForgotPasswordUrlTemplate = "{0}/api/v1/accounts/reset-password/by-user/{1}/by-token/{2}";
}
