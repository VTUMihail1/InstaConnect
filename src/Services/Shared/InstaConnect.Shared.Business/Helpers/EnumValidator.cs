﻿namespace InstaConnect.Messages.Read.Business.Queries.Messages.GetAllFilteredMessages;

internal class EnumValidator : IEnumValidator
{
    public bool IsEnumValid<T>(string enumValueName) where T : Enum
    {
        var IsEnumValueValid = Enum.TryParse(typeof(T), enumValueName, out _);

        return IsEnumValueValid;
    }
}
