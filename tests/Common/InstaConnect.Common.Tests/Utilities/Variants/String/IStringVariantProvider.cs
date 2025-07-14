using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InstaConnect.Common.Tests.Utilities.Variants.String;
public interface IStringVariantProvider
{
    public StringVariantType Type { get; }

    public string GetVariant(string? value);
}
