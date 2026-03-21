namespace InstaConnect.Identity.Presentation.Tests.Features.Users.Utilities;

public static class UserTestRoutes
{
    private static string GetDefault()
    {
        const string Route = "api/v1/users";

        return Route;
    }

    private static string GetId(string id)
    {
        const string Format = "{0}/{1}";

        return Format.FormatCurrentCulture(
            GetDefault(),
            id);
    }

    private static string GetCurrent()
    {
        const string Format = "{0}/current";

        return Format.FormatCurrentCulture(
            GetDefault());
    }

    private static string GetIdDetails(string id)
    {
        const string Format = "{0}/details";

        return Format.FormatCurrentCulture(
            GetId(id),
            id);
    }

    private static string GetCurrentDetails()
    {
        const string Format = "{0}/details";

        return Format.FormatCurrentCulture(
            GetCurrent());
    }

    public static string GetRoute(GetAllUsersApiRequest request)
    {
        const string Format = "{0}?name={1}&firstName={2}&lastName={3}&sortOrder={4}&sortTerm={5}&page={6}&pageSize={7}";

        return Format.FormatCurrentCulture(
            GetDefault(),
            request.Name,
            request.FirstName,
            request.LastName,
            request.SortOrder,
            request.SortTerm,
            request.Page,
            request.PageSize);
    }

    public static string GetRoute(GetUserByIdApiRequest request)
    {
        return GetId(request.Id);
    }

    public static string GetRoute(GetUserDetailsByIdApiRequest request)
    {
        return GetIdDetails(request.Id);
    }

    public static string GetRoute(GetCurrentUserByIdApiRequest request)
    {
        return GetCurrent();
    }

    public static string GetRoute(GetCurrentUserDetailsByIdApiRequest request)
    {
        return GetCurrentDetails();
    }

    public static string GetRoute(AddUserApiRequest request)
    {
        return GetDefault();
    }

    public static string GetRoute(UpdateCurrentUserApiRequest request)
    {
        return GetCurrent();
    }

    public static string GetRoute(DeleteUserApiRequest request)
    {
        return GetId(request.Id);
    }

    public static string GetRoute(DeleteCurrentUserApiRequest request)
    {
        return GetCurrent();
    }
}
