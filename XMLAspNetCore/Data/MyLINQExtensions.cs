using System.Linq;
using System.Collections.Generic;
using Azure.Core;

namespace XMLAspNetCore.Data
{
    public static class MyLINQExtensions
    {
        // this is a chainable LINQ extension method
        public static IEnumerable<T> ProcessSequence<T>(this IEnumerable<T> sequence)
        {
            return sequence;
        }

        // this is a scalar LINQ extension method
        public static long SummerizeSequence<T>(this IEnumerable<T> sequence)
        {
            return sequence.LongCount();
        }
    }
}
