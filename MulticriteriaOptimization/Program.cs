using ElectreIs;
using McdaCommon;
using McdaCommon.DataSources;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Visualization;

namespace MO
{
    class Program
    {
        [STAThread]
        static void Main(string[] args)
        {
            var reader = new CsvReader("Data/australian.dat", ' ', 15);
            var alternatives = reader.ReadAlternatives().Take(40).ToList();
            var parameters = ParameterPropertiesGenerator.GenerateSampleProperties(alternatives, 0.15, 0.3);
            var problem = new ProblemDefinition(alternatives, parameters, 0.5);
            var superiorityMatrix = problem.Solve();
            superiorityMatrix.Visualize();
            Console.WriteLine(alternatives.Count);
            Console.ReadKey();
        }
    }
}