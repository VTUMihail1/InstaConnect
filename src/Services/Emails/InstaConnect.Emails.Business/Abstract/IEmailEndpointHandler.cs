namespace InstaConnect.Emails.Business.Abstract;

public interface IEmailEndpointHandler
{
    string GetEmailConfirmationEndpoint(string userId, string token);

    string GetForgotPasswordEndpoint(string userId, string token);
}
