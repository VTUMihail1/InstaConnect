namespace InstaConnect.Common.Domain.Features.Emails.Models;

public record SendEmailRequest(string Receiver, string Subject, string Template);
