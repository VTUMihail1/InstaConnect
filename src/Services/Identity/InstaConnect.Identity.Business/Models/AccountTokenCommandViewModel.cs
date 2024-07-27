namespace InstaConnect.Identity.Business.Models;

public record AccountTokenCommandViewModel(string Type, string Value, DateTime ValidUntil);
