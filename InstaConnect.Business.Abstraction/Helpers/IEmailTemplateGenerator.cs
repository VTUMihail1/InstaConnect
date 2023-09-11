namespace InstaConnect.Business.Helpers
{
    public interface IEmailTemplateGenerator
    {
        string GenerateEmailConfirmationTemplate(string userId, string token);
        string GenerateForgotPasswordTemplate(string userId, string token);
    }
}