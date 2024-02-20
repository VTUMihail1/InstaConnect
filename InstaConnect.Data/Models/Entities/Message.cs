using InstaConnect.Data.Models.Entities.Base;

namespace InstaConnect.Data.Models.Entities
{
    public class Message : BaseEntity
    {
        public string SenderId { get; set; }

        public string ReceiverId { get; set; }

        public string Content { get; set; }

        public User Sender { get; set; }

        public User Receiver { get; set; }
    }
}
