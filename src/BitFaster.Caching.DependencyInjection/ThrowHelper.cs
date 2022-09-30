using System;
using System.Collections.Generic;
using System.Text;

namespace BitFaster.Caching.DependencyInjection
{
    internal static class ThrowHelper
    {
        internal static void ThrowIfNull(
            object argument,
            string paramName = null)
        {
            if (argument is null)
            {
                Throw(paramName);
            }
        }

        private static void Throw(string paramName) => throw new ArgumentNullException(paramName);
    }
}

