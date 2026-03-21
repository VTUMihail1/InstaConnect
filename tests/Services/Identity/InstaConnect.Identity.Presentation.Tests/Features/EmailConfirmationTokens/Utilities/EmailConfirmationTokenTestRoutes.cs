namespace InstaConnect.Identity.Presentation.Tests.Features.EmailConfirmationTokens.Utilities;

public static class EmailConfirmationTokenTestRoutes
{
    private static string GetDefaultName(string name)
    {
        const string Format = "api/v1/users/{0}/email-confirmation-tokens";

        return Format.FormatCurrentCulture(name);
    }

    private static string GetDefaultId(string id)
    {
        const string Format = "api/v1/users/{0}/email-confirmation-tokens";

        return Format.FormatCurrentCulture(id);
    }

    public static string GetRoute(AddEmailConfirmationTokenApiRequest request)
    {
        return GetDefaultName(request.Name);
    }

    public static string GetRoute(VerifyEmailConfirmationTokenApiRequest request)
    {
        return GetDefaultId(request.Id);
    }
}
