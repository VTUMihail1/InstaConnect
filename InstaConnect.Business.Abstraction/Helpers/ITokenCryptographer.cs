namespace InstaConnect.Business.Abstraction.Helpers
{
    public interface ITokenCryptographer
    {
        string DecodeToken(string encodedToken);
    }
}