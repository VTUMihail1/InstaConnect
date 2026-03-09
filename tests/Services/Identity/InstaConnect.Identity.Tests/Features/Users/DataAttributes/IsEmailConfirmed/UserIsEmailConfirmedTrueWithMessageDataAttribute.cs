namespace InstaConnect.Identity.Tests.Features.Users.DataAttributes.IsEmailConfirmed;

[AttributeUsage(AttributeTargets.Method, AllowMultiple = true, Inherited = true)]
public sealed class UserIsEmailConfirmedTrueWithMessageDataAttribute : TrueBooleanWithMessageDataAttribute;
