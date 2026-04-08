namespace InstaConnect.Identity.Presentation.Tests.Features.EmailConfirmationTokens.Utilities;

public static class EmailConfirmationTokenTestRoutes
{
    private static string GetDefaultName(string name)
    {
        const string Format = "api/v1/users/{0}/email-confirmation-tokens";

        return Format.FormatCurrentCulture(name);
    }

    private static string GetDefaultIdVerify(string id, string value)
    {
        const string Format = "api/v1/users/{0}/email-confirmation-tokens/{1}/verify";

        return Format.FormatCurrentCulture(id, value);
    }

    public static string GetRoute(AddEmailConfirmationTokenApiRequest request)
    {
        return GetDefaultName(request.Name);
    }

    public static string GetRoute(VerifyEmailConfirmationTokenApiRequest request)
    {
        return GetDefaultIdVerify(request.Id, request.Value);
    }
}
