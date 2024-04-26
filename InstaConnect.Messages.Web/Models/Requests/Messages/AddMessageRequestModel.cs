namespace InstaConnect.Messages.Web.Models.Requests.PostComment
{
    public class AddMessageRequestModel
    {
        public string SenderId { get; set; }

        public string ReceiverId { get; set; }

        public string Content { get; set; }
    }
}
