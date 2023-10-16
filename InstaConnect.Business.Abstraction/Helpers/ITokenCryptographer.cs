namespace InstaConnect.Business.Abstraction.Helpers
{
    /// <summary>
    /// Represents an interface for token encoding and decoding operations.
    /// </summary>
    public interface ITokenCryptographer
    {
        /// <summary>
        /// Decodes an encoded token.
        /// </summary>
        /// <param name="encodedToken">The encoded token to decode.</param>
        /// <returns>The decoded token.</returns>
        string DecodeToken(string encodedToken);

        /// <summary>
        /// Encodes a decoded token.
        /// </summary>
        /// <param name="decodedToken">The token to encode.</param>
        /// <returns>The encoded token.</returns>
        string EncodeToken(string decodedToken);
    }
}