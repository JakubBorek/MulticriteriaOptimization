using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Qualiflex
{
    public static class PermutationsGenerator
    {
        public static IEnumerable<IEnumerable<T>> GetPermutations<T>(this IEnumerable<T> input)
        {
            if (input.Count() == 1) { yield return input; }

            foreach (var firstElement in input)
            {
                var tail = input.Where(e => !e.Equals(firstElement));
                var tailPermutations = GetPermutations(tail);
                foreach (var tp in tailPermutations)
                {
                    yield return tp.AddElementAtBeginning(firstElement);
                }
            }
        }

        private static IEnumerable<T> AddElementAtBeginning<T>(this IEnumerable<T> enumerable, T element)
        {
            return (new T[] { element }).Concat(enumerable);
        }
    }
}
