using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InstaConnect.Common.Tests.Utilities.Types.Enums.Base;
public interface IEnumTransformer<TEnum>
        where TEnum : Enum
{
    public TEnum Transform(TEnum value);
}
