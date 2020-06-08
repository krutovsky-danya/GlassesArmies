using System;
using System.Collections.Generic;

namespace GlassesArmies
{
    public static partial class EnumerableExtension
    {
        public static void For<T>(this IEnumerable<T> sequence, Action<T, int> action)
        {
            var i = 0;
            foreach (var element in sequence)
            {
                action(element, i++);
            }
        }
    }
}