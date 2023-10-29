namespace InstaConnect.Business.Helpers
{
    /// <summary>
    /// Provides methods for configuring URLs and endpoints related to user actions.
    /// </summary>
    public interface IEndpointHandler
    {
        /// <summary>
        /// Configures the URL for email confirmation based on the user ID and token.
        /// </summary>
        /// <param name="userId">The unique identifier of the user.</param>
        /// <param name="token">The token for email confirmation.</param>
        /// <returns>A string representing the configured URL for email confirmation.</returns>
        string ConfigureEmailConfirmationEndpoint(string userId, string token);

        /// <summary>
        /// Configures the URL for password reset based on the user ID and token.
        /// </summary>
        /// <param name="userId">The unique identifier of the user.</param>
        /// <param name="token">The token for password reset.</param>
        /// <returns>A string representing the configured URL for password reset.</returns>
        string ConfigurePasswordResetEndpoint(string userId, string token);
    }
}