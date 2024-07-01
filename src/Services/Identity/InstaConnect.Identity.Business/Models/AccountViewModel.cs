namespace InstaConnect.Identity.Business.Models;

public class AccountViewModel
{
    public string Type { get; set; } = string.Empty;

    public string Value { get; set; } = string.Empty;

    public DateTime ValidUntil { get; set; } = DateTime.MinValue;
}
