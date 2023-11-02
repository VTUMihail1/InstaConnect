namespace InstaConnect.Business.Abstraction.Helpers
{
    /// <summary>
    /// Provides methods for generating email templates for specific actions.
    /// </summary>
    public interface ITemplateGenerator
    {
        /// <summary>
        /// Generates an email template for email confirmation.
        /// </summary>
        /// <param name="endpoint">The URL endpoint for email confirmation.</param>
        /// <returns>A string representing the generated email template for email confirmation.</returns>
        string GenerateEmailConfirmationTemplate(string endpoint);

        /// <summary>
        /// Generates an email template for the "Forgot Password" action.
        /// </summary>
        /// <param name="endpoint">The URL endpoint for password reset.</param>
        /// <returns>A string representing the generated email template for the "Forgot Password" action.</returns>
        string GenerateForgotPasswordTemplate(string endpoint);
    }
}