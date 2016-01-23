using McdaCommon;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElectreIs
{
    public class ParameterProperties
    {
        public string Name { get; }
        public double Weight { get; }
        public double PreferenceThreshold { get; }
        public double VetoThreshold { get; }

        public ParameterProperties(string name, double weight, double preferenceThreshold, double vetoThreshold)
        {
            Name = name;
            Weight = weight;
            PreferenceThreshold = preferenceThreshold;
            VetoThreshold = vetoThreshold;

        }
    }
}
