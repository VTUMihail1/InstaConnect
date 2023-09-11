namespace InstaConnect.Business.Abstraction.Helpers
{
    /// <summary>
    /// Represents an interface for generating email templates for various purposes such as email confirmation and password reset.
    /// </summary>
    public interface IEmailTemplateGenerator
    {
        /// <summary>
        /// Generates an email confirmation template based on the provided <paramref name="userId"/> and <paramref name="token"/>.
        /// </summary>
        /// <param name="userId">The user's unique identifier.</param>
        /// <param name="token">The email confirmation token.</param>
        /// <returns>A string representing the generated email confirmation template.</returns>
        string GenerateEmailConfirmationTemplate(string userId, string token);

        /// <summary>
        /// Generates a forgot password template based on the provided <paramref name="userId"/> and <paramref name="token"/>.
        /// </summary>
        /// <param name="userId">The user's unique identifier.</param>
        /// <param name="token">The password reset token.</param>
        /// <returns>A string representing the generated forgot password template.</returns>
        string GenerateForgotPasswordTemplate(string userId, string token);
    }
}