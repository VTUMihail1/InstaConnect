using FluentValidation;

namespace InstaConnect.Common.Tests.Utilities;

public abstract class BaseTest
{
    protected BaseTest()
    {
        ValidatorOptions.Global.DefaultRuleLevelCascadeMode = CascadeMode.Stop;
    }
}
