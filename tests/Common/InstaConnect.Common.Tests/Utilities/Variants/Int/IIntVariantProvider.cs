using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InstaConnect.Common.Tests.Utilities.Variants.Int;
public interface IIntVariantProvider
{
    public IntVariantType Type { get; }

    public int GetVariant(int value);
}
