namespace InstaConnect.Users.Business.Models
{
    public class TokenViewDTO
    {
        public string Type { get; set; }

        public string Value { get; set; }

        public DateTime ValidUntil { get; set; }
    }
}
