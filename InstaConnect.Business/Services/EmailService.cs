using InstaConnect.Business.Abstraction.Factories;
using InstaConnect.Business.Abstraction.Helpers;
using InstaConnect.Business.Abstraction.Services;
using InstaConnect.Business.Models.DTOs.Email;
using InstaConnect.Business.Models.Results;
using InstaConnect.Data.Models.Utilities;

namespace InstaConnect.Business.Services
{
    public class EmailService : IEmailService
    {
        private readonly IResultFactory _resultFactory;
        private readonly IEmailSender _emailSender;
        private readonly IEmailFactory _emailFactory;
        private readonly IEndpointHandler _endpointHandler;
        private readonly ITemplateGenerator _templateGenerator;

        public EmailService(
            IEmailSender emailSender,
            IEmailFactory emailFactory,
            IEndpointHandler endpointHandler,
            ITemplateGenerator templateGenerator,
            IResultFactory resultFactory)
        {
            _emailSender = emailSender;
            _emailFactory = emailFactory;
            _endpointHandler = endpointHandler;
            _templateGenerator = templateGenerator;
            _resultFactory = resultFactory;
        }

        public async Task<IResult<EmailResultDTO>> SendEmailConfirmationAsync(string email, string userId, string token)
        {
            var endpoint = _endpointHandler.ConfigureEmailConfirmationEndpoint(userId, token);
            var template = _templateGenerator.GenerateEmailConfirmationTemplate(endpoint);

            var emailContent = _emailFactory.GetEmail(email, InstaConnectConstants.AccountEmailConfirmationTitle, string.Empty, template);

            var result = await _emailSender.SendEmailAsync(emailContent);

            if (!result.IsSuccessStatusCode)
            {
                var badRequestResult = _resultFactory.GetBadRequestResult<EmailResultDTO>();

                return badRequestResult;
            }

            var noContentResult = _resultFactory.GetNoContentResult<EmailResultDTO>();

            return noContentResult;
        }

        public async Task<IResult<EmailResultDTO>> SendPasswordResetAsync(string email, string userId, string token)
        {
            var endpoint = _endpointHandler.ConfigurePasswordResetEndpoint(userId, token);
            var template = _templateGenerator.GenerateForgotPasswordTemplate(endpoint);

            var emailContent = _emailFactory.GetEmail(email, InstaConnectConstants.AccountForgotPasswordTitle, string.Empty, template);

            var result = await _emailSender.SendEmailAsync(emailContent);

            if (!result.IsSuccessStatusCode)
            {
                var badRequestResult = _resultFactory.GetBadRequestResult<EmailResultDTO>();

                return badRequestResult;
            }

            var noContentResult = _resultFactory.GetNoContentResult<EmailResultDTO>();

            return noContentResult;
        }
    }
}
