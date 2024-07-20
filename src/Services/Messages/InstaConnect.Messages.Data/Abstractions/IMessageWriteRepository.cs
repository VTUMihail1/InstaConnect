﻿using InstaConnect.Messages.Data.Models.Entities;
using InstaConnect.Shared.Data.Abstract;

namespace InstaConnect.Messages.Data.Abstractions;

public interface IMessageWriteRepository : IBaseWriteRepository<Message>
{
}