using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace McdaCommon
{
    public static class EnumerableRandomExtensions
    {
        public static IEnumerable<T> GetRandomElements<T>(this IEnumerable<T> enumerable, int count)
        {
            var random = new Random(0);
            var list = new List<T>(enumerable);
            for(int i = 0; i < count; i++)
            {
                int index = random.Next(0, list.Count());
                yield return list.ElementAt(index);
                list.RemoveAt(index);
            }
        }

        public static T RandomElement<T>(this IEnumerable<T> enumerable)
        {
            return enumerable.RandomElementUsing(new Random());
        }

        private static T RandomElementUsing<T>(this IEnumerable<T> enumerable, Random rand)
        {
            int index = rand.Next(0, enumerable.Count());
            return enumerable.ElementAt(index);
        }
    }
}
