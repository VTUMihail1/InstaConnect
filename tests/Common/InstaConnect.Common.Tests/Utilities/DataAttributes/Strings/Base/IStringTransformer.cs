using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InstaConnect.Common.Tests.Utilities.DataAttributes.Strings.Base;
public interface IStringTransformer
{
    public string Transform(string? value);
}
