using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InstaConnect.Common.Tests.Utilities.DataAttributes.DateTimeOffsets.Base;
public interface IDateTimeOffsetTransformer
{
    public DateTimeOffset Transform(DateTimeOffset value);
}
