namespace InstaConnect.Messages.Web.Features.Messages.Models.Binding;

public class UpdateMessageBindingModel
{
    public UpdateMessageBindingModel(string content)
    {
        Content = content;
    }

    public string Content { get; set; } = string.Empty;
}
