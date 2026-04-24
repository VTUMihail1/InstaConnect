using InstaConnect.Common.Events.Features.Tokens.Models;

namespace InstaConnect.Identity.Application.Features.UserClaims.Commands.Add;

public record AddUserClaimCommandRequest(
    string Id,
    ApplicationClaims Claim) : ICommandRequest<AddUserClaimCommandResponse>;
