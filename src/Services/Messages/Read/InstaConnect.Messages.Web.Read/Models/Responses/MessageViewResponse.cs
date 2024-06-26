namespace InstaConnect.Messages.Web.Read.Models.Responses;

public class MessageViewResponse
{
    public int Id { get; set; }

    public string SenderId { get; set; }

    public string SenderName { get; set; }

    public string ReceiverId { get; set; }

    public string ReceiverName { get; set; }

    public string Content { get; set; }
}
