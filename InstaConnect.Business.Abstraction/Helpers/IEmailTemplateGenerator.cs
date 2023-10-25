namespace InstaConnect.Business.Abstraction.Helpers
{
    public interface IEmailTemplateGenerator
    {
        string GenerateEmailConfirmationTemplate(string endpoint);
        string GenerateForgotPasswordTemplate(string endpoint);
    }
}