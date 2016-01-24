using McdaCommon;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace McdaCommon
{
    public class ParameterProperties
    {
        public string Name { get; }
        public double Weight { get; }
        public double WeakPreferenceThreshold { get; }
        public double StrongPreferenceThreshold { get; }
        public double VetoThreshold { get; }

        public ParameterProperties(string name, double weight, double preferenceThreshold, double vetoThreshold)
        {
            Name = name;
            Weight = weight;
            WeakPreferenceThreshold = preferenceThreshold;
            StrongPreferenceThreshold = preferenceThreshold;
            VetoThreshold = vetoThreshold;

        }
    }
}
