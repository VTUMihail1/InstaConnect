namespace InstaConnect.Common.Tests.Features.DataAttributes.Enums.Base;

public interface IEnumTransformer<TEnum> : ITransformer<TEnum>
        where TEnum : Enum;
