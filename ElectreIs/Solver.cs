using McdaCommon;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElectreIs
{
    class Solver
    {
        private readonly ProblemDefinition problem;
        public Solver(ProblemDefinition problem)
        {
            this.problem = problem;
        }
        public bool[,] Solve()
        {
            return computeSuperiorityMatrix();
        }

        bool[,] computeSuperiorityMatrix()
        {
            int alternativesCount = problem.Alternatives.Count;
            var matrix = new bool[alternativesCount, alternativesCount];
            for (int i = 0; i < alternativesCount; i++)
            {
                for (int j = 0; j < alternativesCount; j++)
                {
                    matrix[i, j] = isFirstBetter(problem.Alternatives[i], problem.Alternatives[j]);
                }
            }
            return matrix;
        }
        private bool isFirstBetter(Alternative first, Alternative second)
        {
            var superiorityScore = getSuperiorityScore(first, second);
            bool superior = superiorityScore > problem.SuperiorityThreshold;
            bool better = superior && !isVetoed(first, second);
            return better;
        }

        private double getSuperiorityScore(Alternative first, Alternative second)
        {
            var numerator = GetParameterEnumerable(first, second)
                .Sum(p => p.Item3.Weight * (p.Item2 - p.Item1 > p.Item3.PreferenceThreshold ? 0 : 1));
            var denominator = problem.Parameters.Sum(p => p.Weight);
            return numerator / denominator;
        }
        private bool isVetoed(Alternative first, Alternative second)
        {
            return GetParameterEnumerable(first, second).Any(pe => pe.Item2 - pe.Item1 > pe.Item3.VetoThreshold);
        }

        private IEnumerable<Tuple<double, double, ParameterProperties>> GetParameterEnumerable(Alternative first, Alternative second)
        {
            for (int i = 0; i < problem.Parameters.Count; i++)
            {
                yield return Tuple.Create(first.Values[i], second.Values[i], problem.Parameters[i]);
            }
        }

    }
}
