using InstaConnect.Business.Models.Options;
using Microsoft.Extensions.Options;

namespace InstaConnect.Business.Helpers
{
    public class EndpointHandler : IEndpointHandler
    {
        private readonly EmailOptions _emailOptions;

        public EndpointHandler(IOptions<EmailOptions> options)
        {
            _emailOptions = options.Value;
        }

        public string ConfigureEmailConfirmationEndpoint(string userId, string token)
        {
            var endpoint = $"{_emailOptions.ConfirmEmailEndpoint}/by-user/{userId}/by-token/{token}";

            return endpoint;
        }

        public string ConfigurePasswordResetEndpoint(string userId, string token)
        {
            var endpoint = $"{_emailOptions.ResetPasswordEndpoint}/by-user/{userId}/by-token/{token}";

            return endpoint;
        }
    }
}
