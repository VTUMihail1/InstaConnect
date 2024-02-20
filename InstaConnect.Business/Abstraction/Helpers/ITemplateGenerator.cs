namespace InstaConnect.Business.Abstraction.Helpers
{
    /// <summary>
    /// Represents an interface for generating email templates for specific purposes.
    /// </summary>
    public interface ITemplateGenerator
    {
        /// <summary>
        /// Generates an email confirmation template for the specified endpoint.
        /// </summary>
        /// <param name="endpoint">The endpoint URL for confirming the email.</param>
        /// <returns>A string containing the generated email confirmation template.</returns>
        string GenerateEmailConfirmationTemplate(string endpoint);

        /// <summary>
        /// Generates a "Forgot Password" email template for the specified endpoint.
        /// </summary>
        /// <param name="endpoint">The endpoint URL for resetting the password.</param>
        /// <returns>A string containing the generated "Forgot Password" email template.</returns>
        string GenerateForgotPasswordTemplate(string endpoint);
    }
}