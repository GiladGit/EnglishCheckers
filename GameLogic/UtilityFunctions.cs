using System;
using System.Collections.Generic;

namespace GameLogic
{
    internal static class UtilityFunctions
    {
        internal static bool IsListEmpty<T>(List<T> list)
        {
            if (list == null)
            {
                throw new NullReferenceException();
            }
            return (list.Count == 0) ? true : false;
        }
    }
}
