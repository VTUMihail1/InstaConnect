namespace InstaConnect.Identity.Business.Features.Accounts.Models;

public record AccountTokenCommandViewModel(string Type, string Value, DateTime ValidUntil);
