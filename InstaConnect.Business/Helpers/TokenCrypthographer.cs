using InstaConnect.Business.Abstraction.Helpers;
using System.Text;

namespace InstaConnect.Business.Helpers
{
    public class TokenCrypthographer : ITokenCryptographer
    {
        public string DecodeToken(string encodedToken)
        {
            var decodedToken = Encoding.UTF8.GetString(Convert.FromBase64String(encodedToken));

            return decodedToken;
        }
    }
}
