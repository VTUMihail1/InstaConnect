namespace InstaConnect.Business.Models.Options
{
    public class TokenOptions
    {
        public string Issuer { get; set; }

        public string Audience { get; set; }

        public string SecurityKey { get; set; }

        public int AccessTokenLifetimeSeconds { get; set; }

        public int UserTokenLifetimeSeconds { get; set; }
    }
}
