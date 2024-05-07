using InstaConnect.Data.Models.Entities;
using InstaConnect.Shared.Data.Repositories.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InstaConnect.Messages.Data.Abstractions.Repositories;

public interface IMessageRepository : IBaseRepository<Message>
{
}
