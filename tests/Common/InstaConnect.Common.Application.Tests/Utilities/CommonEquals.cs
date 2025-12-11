using FluentValidation.Results;

namespace InstaConnect.Common.Application.Tests.Utilities;
public static class CommonEquals
{
    public static bool Matches(
        this ValidationFailure v,
        string errorMessage)
    {
        return v.ErrorMessage == errorMessage;
    }
}
