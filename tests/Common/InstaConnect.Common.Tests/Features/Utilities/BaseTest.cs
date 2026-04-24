using FluentValidation;

namespace InstaConnect.Common.Tests.Features.Utilities;

public abstract class BaseTest
{
    protected BaseTest()
    {
        ValidatorOptions.Global.DefaultRuleLevelCascadeMode = CascadeMode.Stop;
    }
}
