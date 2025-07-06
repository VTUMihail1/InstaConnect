using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace InstaConnect.Common.Utilities;
public static class CommonErrorMessages
{
    public static readonly string GetSortOrderEmpty()
    {
        const string Message = "Sort order must not be empty.";

        return Message; 
    }
}
