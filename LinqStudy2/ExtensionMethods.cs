using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LinqStudy2
{
    static class ExtensionMethods
    {
        public static Queue<T> ToQueue<T>(this IEnumerable<T> source)
        {
            return new Queue<T>(source);
        }
    }
}
