using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace InstaConnect.Follows.Web.Features.Follows.Utilities;

public class FollowRoutes
{
    public const string Prefix = "api/v{version:apiVersion}/follows";

    public const string Default = "";

    public const string Id = "{id}";
}
