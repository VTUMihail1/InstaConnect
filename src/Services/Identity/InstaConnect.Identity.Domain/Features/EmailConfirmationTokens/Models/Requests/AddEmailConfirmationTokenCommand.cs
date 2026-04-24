using InstaConnect.Common.Domain.Features.ValueObjects.Models;

namespace InstaConnect.Identity.Domain.Features.EmailConfirmationTokens.Models.Requests;

public record AddEmailConfirmationTokenCommand(Name Name);
