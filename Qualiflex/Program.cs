using McdaCommon;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Qualiflex
{
    class Program
    {
        static void Main(string[] args)
        {
            var testArr = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8 };
            var t = testArr.GetRandomElements(3).ToList();
            Console.ReadKey();
        }

        static void print(IEnumerable<int> en)
        {
            foreach (var v in en)
            {
                Console.Write(v + " ");
            }
            Console.WriteLine();
        }
    }
}
