using McdaCommon;
using McdaCommon.DataSources;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MO
{
    class Program
    {
        static void Main(string[] args)
        {
            var reader = new CsvReader("Data/australian.dat", ' ', 15);
            var alternatives = reader.ReadAlternatives();
            AlternativesSetViewer.printBasicStats(alternatives);
            Console.WriteLine(alternatives.Count);
            Console.ReadKey();
        }
    }
}