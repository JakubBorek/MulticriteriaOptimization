using ElectreIs;
using McdaCommon;
using McdaCommon.DataSources;
using Qualiflex;
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
            demoQualiflex();
            Console.ReadKey();
        }

        static void demoQualiflex()
        {
            var problem = getSampleProblem(7);
            var bestRanking = problem.SolveWithQualiflex();
            printRanking(bestRanking);
        }
        static void demoElectrIs()
        {
            var problem = getSampleProblem(30);
            var superiorityMatrix = problem.SolveWithElectreIs();
            superiorityMatrix.Visualize();
        }

        private static ProblemDefinition getSampleProblem(int alternativesCount)
        {
            var reader = new CsvReader("Data/australian.dat", ' ');
            var alternatives = reader.ReadAlternatives().Take(alternativesCount).ToList();
            var parameters = ParameterPropertiesGenerator.GenerateSampleProperties(alternatives, 0.15, 0.3);

            return new ProblemDefinition(alternatives, parameters, 0.5);
        }
        private static void printRanking(IReadOnlyList<Alternative> ranking)
        {
            foreach (var v in ranking)
            {
                Console.Write(v.Name + " ");
            }
            Console.WriteLine();
        }
    }
}