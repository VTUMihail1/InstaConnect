﻿using Bogus;
using InstaConnect.Messages.Write.Business.Utilities;
using InstaConnect.Shared.Data.Models.Enums;

namespace InstaConnect.Messages.Write.Business.UnitTests.Utilities;

public class MessageUnitTestConfigurations
{
    public const string EXISTING_SENDER_ID = nameof(EXISTING_SENDER_ID);
    public const string EXISTING_SENDER_NAME = nameof(EXISTING_SENDER_NAME);
    public const string EXISTING_RECEIVER_ID = nameof(EXISTING_RECEIVER_ID);
    public const string EXISTING_RECEIVER_NAME = nameof(EXISTING_RECEIVER_NAME);
    public const string NON_EXISTING_USER_ID = nameof(NON_EXISTING_USER_ID);
 
    public const string EXISTING_MESSAGE_ID = nameof(EXISTING_MESSAGE_ID);
    public const string EXISTING_MESSAGE_SENDER_ID = nameof(EXISTING_MESSAGE_SENDER_ID);
    public const string EXISTING_MESSAGE_RECEIVER_ID = nameof(EXISTING_MESSAGE_RECEIVER_ID);
    public const string EXISTING_MESSAGE_CONTENT = nameof(EXISTING_MESSAGE_CONTENT);

    public const string NON_EXISTING_MESSAGE_ID = nameof(NON_EXISTING_MESSAGE_ID);

    public const string SORT_PROPERTY_ORDER_VALUE = "CreatedAt";
    public const SortOrder SORT_ORDER_VALUE = SortOrder.ASC;
    public const int LIMIT_VALUE = int.MaxValue;
    public const int OFFSER_VALUE = default;
}
