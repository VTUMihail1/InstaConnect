namespace InstaConnect.Messages.Web.Models.Responses;

public class MessageViewModel
{
    public int Id { get; set; }

    public string SenderId { get; set; }

    public string ReceiverId { get; set; }

    public string Content { get; set; }
}
