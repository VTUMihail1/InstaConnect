using InstaConnect.Business.Abstraction.Helpers;
using InstaConnect.Data.Models.Entities;
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

        public string EncodeToken(string decodedToken)
        {
            var encodedToken = Convert.ToBase64String(Encoding.UTF8.GetBytes(decodedToken)));

            return encodedToken;
        }
    }
}
