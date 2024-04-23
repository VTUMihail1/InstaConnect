using InstaConnect.Shared.Business.Models.Requests;
using MassTransit;

namespace InstaConnect.Shared.Business.RequestClients
{
    public interface IValidateUserByIdRequestClient : IRequestClient<ValidateUserByIdRequest>
    {
    }
}
