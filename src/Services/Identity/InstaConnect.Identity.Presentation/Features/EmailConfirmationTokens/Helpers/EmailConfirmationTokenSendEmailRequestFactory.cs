using InstaConnect.Common.Domain.Features.Common.Extensions;
using InstaConnect.Common.Domain.Features.Emails.Models;
using InstaConnect.Common.Presentation.Features.Common.Models;
using InstaConnect.Identity.Domain.Features.EmailConfirmationTokens.Abstractions;
using InstaConnect.Identity.Domain.Features.EmailConfirmationTokens.Models.Entities;

using Microsoft.Extensions.Options;

namespace InstaConnect.Identity.Presentation.Features.EmailConfirmationTokens.Helpers;

public class EmailConfirmationTokenSendEmailRequestFactory : IEmailConfirmationTokenSendEmailRequestFactory
{
    private readonly MainOptions _options;

    public EmailConfirmationTokenSendEmailRequestFactory(IOptions<MainOptions> options)
    {
        _options = options.Value;
    }
    public SendEmailRequest Get(EmailConfirmationToken emailConfirmationToken)
    {
        var route = EmailConfirmationTokenTemplates.Added.FormatCurrentCulture(_options.BaseUrl, EmailConfirmationTokenRouteFactory.GetDefaultIdVerify(emailConfirmationToken.Id.Id.Id, emailConfirmationToken.Id.Value));

        return new(emailConfirmationToken.User!.Email.Value, EmailConfirmationTokenSubjects.Added, route);
    }
}
