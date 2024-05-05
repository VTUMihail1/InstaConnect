using InstaConnect.Shared.Business.Models.Requests;
using MassTransit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InstaConnect.Shared.Business.RequestClients
{
    public interface IValidateUserIdRequestClient : IRequestClient<ValidateUserIdRequest>
    {
    }
}
