namespace InstaConnect.Business.Models.DTOs.Token
{
    public class TokenAddDTO
    {
        public string Type { get; set; }

        public string Value { get; set; }

        public DateTime ValidUntil { get; set; }
    }
}
