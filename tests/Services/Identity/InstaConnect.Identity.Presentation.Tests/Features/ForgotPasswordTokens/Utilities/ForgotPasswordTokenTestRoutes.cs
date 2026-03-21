namespace InstaConnect.Identity.Presentation.Tests.Features.ForgotPasswordTokens.Utilities;

public static class ForgotPasswordTokenTestRoutes
{
    private static string GetDefaultName(string name)
    {
        const string Format = "api/v1/users/{0}/forgot-password-tokens";

        return Format.FormatCurrentCulture(name);
    }

    private static string GetDefaultId(string id)
    {
        const string Format = "api/v1/users/{0}/forgot-password-tokens";

        return Format.FormatCurrentCulture(id);
    }

    public static string GetRoute(AddForgotPasswordTokenApiRequest request)
    {
        return GetDefaultName(request.Name);
    }

    public static string GetRoute(VerifyForgotPasswordTokenApiRequest request)
    {
        return GetDefaultId(request.Id);
    }
}
