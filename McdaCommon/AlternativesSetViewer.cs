using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace McdaCommon
{
    public static class AlternativesSetViewer
    {
        public static void printBasicStats(IReadOnlyCollection<Alternative> alternatives)
        {
            var criteriaCount = alternatives.First().Values.Count;
            for(int i = 0; i < criteriaCount; i++)
            {
                Console.WriteLine("Criterion1 ");
                var max = alternatives.Select(alt => alt.Values[i]).Max();
                var min = alternatives.Select(alt => alt.Values[i]).Min();
                Console.Write("max: " + max + " ");
                Console.WriteLine("min: " + min);
            }
        }
        private class RunningStatsCalculator
        {
            private double max;
            private double min;

            public void process(double value)
            {

            }
        }
    }
}
