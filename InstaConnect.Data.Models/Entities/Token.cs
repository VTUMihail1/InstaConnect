using InstaConnect.Data.Models.Entities.Base;

namespace InstaConnect.Data.Models.Entities
{
    public class Token : BaseEntity
    {
        public Token()
        {
            Id = Guid.NewGuid().ToString();
        }

        public string Id { get; set; }

        public string Value { get; set; }

        public string Type { get; set; }

        public DateTime ValidUntil { get; set; }

        public string UserId { get; set; }

        public User User { get; set; }
    }
}
