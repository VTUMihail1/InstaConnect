namespace InstaConnect.Emails.Business.Features.Emails.Abstractions;

public interface IEmailEndpointHandler
{
    string GetEmailConfirmationEndpoint(string userId, string token);

    string GetForgotPasswordEndpoint(string userId, string token);
}
