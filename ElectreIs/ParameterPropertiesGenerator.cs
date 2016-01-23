using McdaCommon;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElectreIs
{
    public static class ParameterPropertiesGenerator
    {
        public static List<ParameterProperties> GenerateSampleProperties(IReadOnlyList<Alternative> alternatives, double relativePreference, double relativeVeto)
        {
            var properties = new List<ParameterProperties>();
            var parametersCount = alternatives.First().Values.Count();
            var random = new Random();
            for (int i = 0; i < parametersCount; i++)
            {
                var max = alternatives.Max(alt => alt.Values[i]);
                var min = alternatives.Min(alt => alt.Values[i]);
                var amplitude = max - min;
                var preferenceThreshold = amplitude * relativePreference;
                var vetoThreshold = amplitude * relativeVeto;
                string name = "p" + i;
                double weight = random.NextDouble();

                properties.Add(new ParameterProperties(name, weight, preferenceThreshold, vetoThreshold));
            }
            return properties;
        }
    }
}
