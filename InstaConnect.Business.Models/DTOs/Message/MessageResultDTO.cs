namespace InstaConnect.Business.Models.DTOs.Message
{
    public class MessageResultDTO
    {
        public string Id { get; set; }

        public string SenderId { get; set; }

        public string SenderUsername { get; set; }

        public string ReceiverId { get; set; }

        public string ReceiverUsername { get; set; }
    }
}
