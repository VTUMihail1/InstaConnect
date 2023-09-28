namespace InstaConnect.Data.Abstraction.Helpers
{
    /// <summary>
    /// Represents a token generator for generating access tokens.
    /// </summary>
    public interface ITokenGenerator
    {
        /// <summary>
        /// Generates an access token for the specified user ID.
        /// </summary>
        /// <param name="userId">The user ID for which the access token is generated.</param>
        /// <returns>The generated access token as a string.</returns>
        string GenerateAccessToken(string userId);
    }
}