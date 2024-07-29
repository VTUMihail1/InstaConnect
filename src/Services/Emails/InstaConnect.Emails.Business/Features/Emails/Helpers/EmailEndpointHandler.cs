using InstaConnect.Emails.Business.Features.Emails.Abstractions;
using InstaConnect.Emails.Business.Features.Emails.Models.Options;
using Microsoft.Extensions.Options;

namespace InstaConnect.Emails.Business.Features.Emails.Helpers;

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
