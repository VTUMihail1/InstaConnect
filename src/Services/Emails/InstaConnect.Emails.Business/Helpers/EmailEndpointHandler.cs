using InstaConnect.Emails.Business.Abstract;
using InstaConnect.Emails.Business.Models.Options;
using Microsoft.Extensions.Options;

namespace InstaConnect.Emails.Business.Helpers;

internal class EmailEndpointHandler : IEmailEndpointHandler
{
    private readonly EndpointOptions _endpointOptions;

    public EmailEndpointHandler(IOptions<EndpointOptions> options)
    {
        _endpointOptions = options.Value;
    }

    public string GetEmailConfirmationEndpoint(string userId, string token)
    {
        var endpoint = string.Format(_endpointOptions.ConfirmEmail, userId, token);

        return endpoint;
    }

    public string GetForgotPasswordEndpoint(string userId, string token)
    {
        var endpoint = string.Format(_endpointOptions.ForgotPassword, userId, token);

        return endpoint;
    }
}
