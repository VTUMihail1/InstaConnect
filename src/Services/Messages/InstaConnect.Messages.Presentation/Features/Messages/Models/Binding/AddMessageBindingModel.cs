namespace InstaConnect.Messages.Web.Features.Messages.Models.Binding;

public class AddMessageBindingModel
{
    public AddMessageBindingModel(string receiverId, string content)
    {
        ReceiverId = receiverId;
        Content = content;
    }

    public string ReceiverId { get; set; } = string.Empty;

    public string Content { get; set; } = string.Empty;
}
