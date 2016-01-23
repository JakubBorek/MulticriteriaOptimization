using McdaCommon;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElectreIs
{
    public class ProblemDefinition
    {
        public IReadOnlyList<Alternative> Alternatives { get; }
        public IReadOnlyList<ParameterProperties> Parameters { get; }
        public double SuperiorityThreshold { get; }

        public ProblemDefinition(IReadOnlyList<Alternative> alternatives, IReadOnlyList<ParameterProperties> parameters, double superiorityCoefficient)
        {
            Alternatives = new List<Alternative>(alternatives);
            Parameters = new List<ParameterProperties>(parameters);
            SuperiorityThreshold = superiorityCoefficient;
        }

        private void throwIfWrongData()
        {
            if (Alternatives.Count == 0) { throw new ArgumentException("There must be non-zero alternatives"); }
            var maxValuesCount = Alternatives.Max(alt => alt.Values.Count);
            var minValuesCount = Alternatives.Min(alt => alt.Values.Count);
            if (maxValuesCount != minValuesCount) { throw new ArgumentException("Inconsistient number of parameter values in alternatives"); }
            if (maxValuesCount != Parameters.Count) { throw new ArgumentException("Parameters count douesn't match alternatives' values count"); }
        }
    }
}
