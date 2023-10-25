namespace InstaConnect.Business.Helpers
{
    public interface IEndpointHandler
    {
        string ConfigureEmailConfirmationEndpoint(string userId, string token);
        string ConfigurePasswordResetEndpoint(string userId, string token);
    }
}