using InstaConnect.Common.Domain.Features.Common.Extensions;
using InstaConnect.Common.Domain.Features.Emails.Models;
using InstaConnect.Common.Presentation.Features.Common.Models;
using InstaConnect.Identity.Domain.Features.ForgotPasswordTokens.Abstractions;
using InstaConnect.Identity.Domain.Features.ForgotPasswordTokens.Models.Entities;

using Microsoft.Extensions.Options;

namespace InstaConnect.Identity.Presentation.Features.ForgotPasswordTokens.Helpers;

public class ForgotPasswordTokenSendEmailRequestFactory : IForgotPasswordTokenSendEmailRequestFactory
{
    private readonly MainOptions _options;

    public ForgotPasswordTokenSendEmailRequestFactory(IOptions<MainOptions> options)
    {
        _options = options.Value;
    }
    public SendEmailRequest Get(ForgotPasswordToken forgotPasswordToken)
    {
        var route = ForgotPasswordTokenTemplates.Added.FormatCurrentCulture(_options.BaseUrl, ForgotPasswordTokenRouteFactory.GetDefaultIdVerify(forgotPasswordToken.Id.Id.Id, forgotPasswordToken.Id.Value));

        return new(forgotPasswordToken.User!.Email.Value, ForgotPasswordTokenSubjects.Added, route);
    }
}
