namespace InstaConnect.Common.Tests.DataAttributes.Enums.Base;

public interface IEnumTransformer<TEnum> : ITransformer<TEnum>
        where TEnum : Enum;
