using InstaConnect.Shared.Business.Contracts.Users;

namespace InstaConnect.Messages.Write.Business.Models;

internal class MessageGetUserByIdModel
{
    public GetUserByIdRequest GetUserBySenderIdRequest { get; set; } = new();

    public GetUserByIdRequest GetUserByReceiverIdRequest { get; set; } = new();
}
