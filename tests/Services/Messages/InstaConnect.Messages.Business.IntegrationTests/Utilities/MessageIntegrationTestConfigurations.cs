﻿using InstaConnect.Shared.Data.Models.Enums;

namespace InstaConnect.Messages.Business.IntegrationTests.Utilities;

public class MessageIntegrationTestConfigurations
{
    public const string EXISTING_SENDER_NAME = nameof(EXISTING_SENDER_NAME);
    public const string EXISTING_SENDER_FIRST_NAME = nameof(EXISTING_SENDER_FIRST_NAME);
    public const string EXISTING_SENDER_LAST_NAME = nameof(EXISTING_SENDER_LAST_NAME);
    public const string EXISTING_SENDER_EMAIL = nameof(EXISTING_SENDER_EMAIL);
    public const string EXISTING_SENDER_PROFILE_IMAGE = nameof(EXISTING_SENDER_PROFILE_IMAGE);
    public const string EXISTING_MESSAGE_ADD_NAME = nameof(EXISTING_MESSAGE_ADD_NAME);
    public const string EXISTING_MESSAGE_UPDATE_NAME = nameof(EXISTING_MESSAGE_UPDATE_NAME);

    public const string EXISTING_RECEIVER_NAME = nameof(EXISTING_RECEIVER_NAME);
    public const string NON_EXISTING_USER_ID = nameof(NON_EXISTING_USER_ID);

    public const string EXISTING_MESSAGE_CONTENT = nameof(EXISTING_MESSAGE_CONTENT);
    public const string EXISTING_MESSAGE_ADD_CONTENT = nameof(EXISTING_MESSAGE_ADD_CONTENT);
    public const string EXISTING_MESSAGE_UPDATE_CONTENT = nameof(EXISTING_MESSAGE_UPDATE_CONTENT);

    public const string NON_EXISTING_MESSAGE_ID = nameof(NON_EXISTING_MESSAGE_ID);

    public const string SORT_PROPERTY_ORDER_VALUE = "CreatedAt";
    public const string SORT_ORDER_NAME = "ASC";
    public const SortOrder SORT_ORDER_VALUE = SortOrder.ASC;
}