using McdaCommon;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Qualiflex
{
    class Solver
    {
        private readonly ProblemDefinition problem;
        public Solver(ProblemDefinition problem)
        {
            this.problem = problem;
        }
        public IReadOnlyList<Alternative> Solve()
        {
            var permutations = problem.Alternatives.GetPermutations();
            Tuple<IEnumerable<Alternative>, double> bestRankingWithScore = new Tuple<IEnumerable<Alternative>, double>(null, Double.NegativeInfinity);
            foreach (var p in permutations)
            {
                var score = calculateScoreForRanking(p);
                if (score > bestRankingWithScore.Item2)
                {
                    bestRankingWithScore = Tuple.Create(p, score);
                }
            }
            return bestRankingWithScore.Item1.ToList();
        }
        private double calculateScoreForRanking(IEnumerable<Alternative> ranking)
        {
            if (ranking.Count() == 1) { return 0; }

            var first = ranking.First();
            var tail = ranking.Skip(1);
            var comparisonOfFirst = tail.Sum(e => calculateScoreForPair(first, e));

            return comparisonOfFirst + calculateScoreForRanking(tail);
        }
        private double calculateScoreForPair(Alternative assumedBetter, Alternative assumedWorse)
        {
            return ParametersEnumerator.Enumerate(assumedBetter, assumedWorse, problem.Parameters)
                .Sum(tr =>
                calculateWeightedScoreForParameter(tr.Item1, tr.Item2, tr.Item3));
        }

        private double calculateWeightedScoreForParameter(double assumedBetter, double assumedWorse, ParameterProperties parameter)
        {
            double diff = assumedBetter - assumedWorse;
            int sign = Math.Sign(diff);
            bool oneIsBetter = Math.Abs(sign) > parameter.WeakPreferenceThreshold;
            int notWeighted = sign * Convert.ToInt32(oneIsBetter);
            return parameter.Weight * notWeighted;
        }
    }
}
