﻿using System.Security.Claims;

namespace InstaConnect.Users.Business.Extensions;

internal static class ClaimsPrincipalExtensions
{
    public static string GetUserId(this ClaimsPrincipal? principal)
    {
        return principal?.FindFirstValue(ClaimTypes.NameIdentifier)!;
    }
}
