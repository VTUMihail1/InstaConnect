using InstaConnect.Common.Domain.Features.Common.Extensions;
using InstaConnect.Common.Domain.Features.Emails.Models;
using InstaConnect.Common.Presentation.Features.Common.Models;
using InstaConnect.Identity.Domain.Features.EmailConfirmationTokens.Abstractions;
using InstaConnect.Identity.Domain.Features.EmailConfirmationTokens.Models.Entities;
using InstaConnect.Identity.Presentation.Features.EmailConfirmationTokens.Abstractions;

using Microsoft.Extensions.Options;

namespace InstaConnect.Identity.Presentation.Features.EmailConfirmationTokens.Helpers;

public class EmailConfirmationTokenSendEmailRequestFactory : IEmailConfirmationTokenSendEmailRequestFactory
{
    private readonly MainOptions _mainOptions;
    private readonly IEmailConfirmationTokenTemplateFactory _templateFactory;

    public EmailConfirmationTokenSendEmailRequestFactory(
        IOptions<MainOptions> options,
        IEmailConfirmationTokenTemplateFactory templateFactory)
    {
        _mainOptions = options.Value;
        _templateFactory = templateFactory;
    }

    public async Task<SendEmailRequest> GetAsync(EmailConfirmationToken emailConfirmationToken, CancellationToken cancellationToken)
    {
        const string Subject = "Verify your InstaConnect account";
        const string Format = "{0}/{1}";

        var route = EmailConfirmationTokenRouteFactory.GetDefaultIdVerify(emailConfirmationToken.Id.Id.Id, emailConfirmationToken.Id.Value);
        var link = Format.FormatCurrentCulture(_mainOptions.BaseUrl, route);
        var template = await _templateFactory.GetAddedAsync(new(link), cancellationToken);

        return new(emailConfirmationToken.User!.Email.Value, Subject, template);
    }
}
