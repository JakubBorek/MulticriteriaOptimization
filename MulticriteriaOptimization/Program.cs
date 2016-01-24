using ElectreIs;
using McdaCommon;
using McdaCommon.DataSources;
using Qualiflex;
using System;
using System.Collections.Generic;
using System.Diagnostics;
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
            for (int i = 1; i <= 10; i++)
            {
                var stopwatch = new Stopwatch();
                Console.WriteLine("" + i + " alternatives");
                stopwatch.Start();
                demoQualiflex(i);
                stopwatch.Stop();
                Console.WriteLine("Comparisons: " + Solver.comparisons);
                Console.WriteLine("Elapsed: " + stopwatch.Elapsed);
                Console.WriteLine();
            }
            Console.ReadKey();
        }

        static void demoQualiflex(int size)
        {
            var problem = getSampleProblem(size);
            var bestRanking = problem.SolveWithQualiflex();
            printRanking(bestRanking);
        }
        static void demoElectrIs()
        {
            var problem = getSampleProblem(100);
            var superiorityMatrix = problem.SolveWithElectreIs();
            superiorityMatrix.Visualize();
        }

        private static ProblemDefinition getSampleProblem(int alternativesCount)
        {
            var reader = new CsvReader("Data/australian.dat", ' ');
            var alternatives = reader.ReadAlternatives().Take(alternativesCount).ToList();
            var parameters = ParameterPropertiesGenerator.GenerateSampleProperties(alternatives, 0.01, 0.01);

            return new ProblemDefinition(alternatives, parameters, 0.99999);
        }
        private static void printRanking(IReadOnlyList<Alternative> ranking)
        {
            foreach (var v in ranking)
            {
                Console.Write(v.Name + " > ");
            }
            Console.WriteLine();
        }
    }
}