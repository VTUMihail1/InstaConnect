namespace InstaConnect.Identity.Web.Models.Response;

public class AccountResponse
{
    public string Type { get; set; } = string.Empty;

    public string Value { get; set; } = string.Empty;

    public DateTime ValidUntil { get; set; } = DateTime.MinValue;
}
